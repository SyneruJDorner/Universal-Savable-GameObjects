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
    System.Guid guid = System.Guid.Empty;

    // Unity's serialization system doesn't know about System.Guid, so we convert to a byte array
    // Fun fact, we tried using strings at first, but that allocated memory and was twice as slow
    [SerializeField]
    private byte[] serializedGuid;
    [SerializeField]
    public string _serializedGuid;


    public bool IsGuidAssigned()
    {
        return guid != System.Guid.Empty;
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
            guid = System.Guid.NewGuid();
            serializedGuid = guid.ToByteArray();
            _serializedGuid = guid.ToString();

#if UNITY_EDITOR
            // If we are creating a new GUID for a prefab instance of a prefab, but we have somehow lost our prefab connection
            // force a save of the modified prefab instance properties
            if (PrefabUtility.IsPartOfNonAssetPrefabInstance(this))
            {
                PrefabUtility.RecordPrefabInstancePropertyModifications(this);
            }
#endif
        }
        else if (guid == System.Guid.Empty)
        {
            // otherwise, we should set our system guid to our serialized guid
            guid = new System.Guid(serializedGuid);
        }

        // register with the GUID Manager so that other components can access this
        if (guid != System.Guid.Empty)
        {
            if (!GuidManager.Add(this))
            {
                // if registration fails, we probably have a duplicate or invalid GUID, get us a new one.
                serializedGuid = null;
                _serializedGuid = null;
                guid = System.Guid.Empty;
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
            _serializedGuid = null;
            guid = System.Guid.Empty;
        }
        else
#endif
        {
            if (guid != System.Guid.Empty)
            {
                serializedGuid = guid.ToByteArray();
                _serializedGuid = guid.ToString();
            }
        }
    }

    // On load, we can go head a restore our system guid for later use
    public void OnAfterDeserialize()
    {
        if (serializedGuid != null && serializedGuid.Length == 16)
        {
            guid = new System.Guid(serializedGuid);
        }
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
            _serializedGuid = null;
            guid = System.Guid.Empty;
        }
        else
#endif
        {
            CreateGuid();
        }
    }

    // Never return an invalid GUID
    public System.Guid GetGuid()
    {
        if (guid == System.Guid.Empty && serializedGuid != null && serializedGuid.Length == 16)
        {
            guid = new System.Guid(serializedGuid);
        }

        return guid;
    }

    // let the manager know we are gone, so other objects no longer find this
    public void OnDestroy()
    {
        GuidManager.Remove(guid);
    }
    #endregion

    /*
    #region Unique ID
    [SerializeField]
    private string guidAsString;

    private Guid _guid;
    public Guid guid
    {
        get
        {
            if (_guid == Guid.Empty ||
                 !String.IsNullOrEmpty(guidAsString))
            {
                _guid = new Guid(guidAsString);
            }
            return _guid;
        }
    }

    public void Generate()
    {
        _guid = Guid.NewGuid();
        guidAsString = guid.ToString();
    }
    #endregion
    */

    private List<UserDefinedData> serializedMonoData = new List<UserDefinedData>();
    [HideInInspector] public List<UnityEngine.Object> monoScripts = new List<UnityEngine.Object>();

    /*
    public void OnValidate()
    {
        if (String.IsNullOrEmpty(guidAsString))
            Generate();
    }

    public void Awake()
    {
        if (String.IsNullOrEmpty(guidAsString))
            Generate();
    }
    */

    public List<UserDefinedData> Serialize(GameObject providedObject)
    {
        monoScripts = providedObject.GetComponents<MonoBehaviour>().ToList<UnityEngine.Object>();

        foreach (UnityEngine.Object script in monoScripts)
        {
            var type = Type.GetType(script.GetType().ToString());
            Debug.Log(type + " on item " + script.name);
            object item = Convert.ChangeType(script, type);
            serializedMonoData.Add(new UserDefinedData() { gameObjectName = script.name, scriptName = type.ToString(), serializedData = UniversalSerializedPersistenceSystem.SerializeMonoObject(item)});
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
        UniversalSerializedPersistenceSystem.QueueItemToSave(gameObject);
    }

    public void UniLoad()
    {
        UniversalSerializedPersistenceSystem.QueueItemToLoad(gameObject);
    }

    public void SaveMessage()
    {
        //Debug.Log("Preparing to save: " + gameObject.name);
    }
}