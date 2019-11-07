using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.Experimental.SceneManagement;
#endif

[System.Serializable]
[ExecuteInEditMode, DisallowMultipleComponent]
public class SavableGameObject : MonoBehaviour, IUniversalSerializedPersistenceSystem
{
    #region Unique ID
    // System guid we use for comparison and generation
    Guid guid = Guid.Empty;

    // Unity's serialization system doesn't know about Guid, so we convert to a string
    [SerializeField]
    public string serializedGuid;

    public bool IsGuidAssigned()
    {
        return guid != Guid.Empty;
    }


    // When de-serializing or creating this component, we want to either restore our serialized GUID
    // or create a new one.
    void CreateGuid()
    {
        // if our serialized data is invalid, then we are a new object and need a new GUID
        if (serializedGuid == null || serializedGuid.Length != 16)
        {
#if UNITY_EDITOR
            // if in editor, make sure we aren't a prefab of some kind
            if (IsAssetOnDisk())
            {
                return;
            }
            Undo.RecordObject(this, "Added GUID");
#endif
            guid = Guid.NewGuid();
            serializedGuid = guid.ToString();

#if UNITY_EDITOR
            // If we are creating a new GUID for a prefab instance of a prefab, but we have somehow lost our prefab connection
            // force a save of the modified prefab instance properties
            if (PrefabUtility.IsPartOfNonAssetPrefabInstance(this))
            {
                PrefabUtility.RecordPrefabInstancePropertyModifications(this);
            }
#endif
        }
        else if (guid == Guid.Empty)
        {
            // otherwise, we should set our system guid to our serialized guid
            guid = new Guid(serializedGuid);
        }

        // register with the GUID Manager so that other components can access this
        if (guid != Guid.Empty)
        {
            if (!GuidManager.Add(this))
            {
                // if registration fails, we probably have a duplicate or invalid GUID, get us a new one.
                serializedGuid = null;
                guid = Guid.Empty;
                CreateGuid();
            }
        }
    }

#if UNITY_EDITOR
    private bool IsEditingInPrefabMode()
    {
        if (EditorUtility.IsPersistent(this))
        {
            // if the game object is stored on disk, it is a prefab of some kind, despite not returning true for IsPartOfPrefabAsset =/
            return true;
        }
        else
        {
            // If the GameObject is not persistent let's determine which stage we are in first because getting Prefab info depends on it
            var mainStage = StageUtility.GetMainStageHandle();
            var currentStage = StageUtility.GetStageHandle(gameObject);
            if (currentStage != mainStage)
            {
                var prefabStage = PrefabStageUtility.GetPrefabStage(gameObject);
                if (prefabStage != null)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool IsAssetOnDisk()
    {
        return PrefabUtility.IsPartOfPrefabAsset(this) || IsEditingInPrefabMode();
    }
#endif

    // We cannot allow a GUID to be saved into a prefab, and we need to convert to byte[]
    public void OnBeforeSerialize()
    {
#if UNITY_EDITOR
        // This lets us detect if we are a prefab instance or a prefab asset.
        // A prefab asset cannot contain a GUID since it would then be duplicated when instanced.
        if (IsAssetOnDisk())
        {
            serializedGuid = null;
            guid = Guid.Empty;
        }
        else
#endif
        {
            if (guid != Guid.Empty)
            {
                serializedGuid = guid.ToString();
            }
        }
    }

    // On load, we can go head a restore our system guid for later use
    public void OnAfterDeserialize()
    {
        if (serializedGuid != null && serializedGuid.Length == 16)
            guid = new Guid(serializedGuid);
    }

    void Awake()
    {
        CreateGuid();
    }

    void OnValidate()
    {
#if UNITY_EDITOR
        // similar to on Serialize, but gets called on Copying a Component or Applying a Prefab
        // at a time that lets us detect what we are
        if (IsAssetOnDisk())
        {
            serializedGuid = null;
            guid = Guid.Empty;
        }
        else
#endif
        {
            CreateGuid();
        }
    }

    // Never return an invalid GUID
    public Guid GetGuid()
    {
        if (guid == Guid.Empty && serializedGuid != null && serializedGuid.Length == 16)
        {
            guid = new Guid(serializedGuid);
        }

        return guid;
    }

    // let the manager know we are gone, so other objects no longer find this
    public void OnDestroy()
    {
        GuidManager.Remove(guid);
    }
    #endregion

    private List<UserDefinedData> serializedMonoData = new List<UserDefinedData>();
    [HideInInspector] public List<UnityEngine.Object> monoScripts = new List<UnityEngine.Object>();

    public List<UserDefinedData> Serialize(GameObject providedObject)
    {
        monoScripts = providedObject.GetComponents<MonoBehaviour>().ToList<UnityEngine.Object>();

        foreach (UnityEngine.Object script in monoScripts)
        {
            var type = Type.GetType(script.GetType().ToString());
            object item = Convert.ChangeType(script, type);
            serializedMonoData.Add(new UserDefinedData() { ID = serializedGuid, scriptName = type.ToString(), serializedData = UniversalSerializedPersistenceSystem.SerializeMonoObject(item)});
        }

        monoScripts.Clear();

        return serializedMonoData;
    }

    public void Deserialize(List<UserDefinedData> serializedMonoData, GameObject providedObject)
    {
        monoScripts = providedObject.GetComponents<MonoBehaviour>().ToList<UnityEngine.Object>();

        foreach (var data in serializedMonoData)
        {
            foreach (UnityEngine.Object script in monoScripts)
            {
                var type = Type.GetType(script.GetType().ToString());
                object item = Convert.ChangeType(script, type);

                if (type.ToString() == data.scriptName)
                {
                    UniversalSerializedPersistenceSystem.DeserializeMonoObject(data.serializedData, item);
                    break;
                }
            }
        }

        monoScripts.Clear();
    }

    public void UniSave()
    {
        UniversalSerializedPersistenceSystem.QueueItemToSave(gameObject, serializedGuid);
    }

    public void UniLoad()
    {
        UniversalSerializedPersistenceSystem.QueueItemToLoad(gameObject, serializedGuid);
    }

    public void SaveMessage()
    {
        //Debug.Log("Preparing to save: " + gameObject.name);
    }
}