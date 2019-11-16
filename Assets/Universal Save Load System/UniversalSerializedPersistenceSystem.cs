using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

[System.Serializable]
public class SerializableDataSet
{
    public List<SerializableData> data = new List<SerializableData>();
}

[System.Serializable]
class UniversalSerializedPersistenceSystem : MonoBehaviour
{
    #region Singleton Access
    private static UniversalSerializedPersistenceSystem instance;//Use of a singleton here, needs to be static in order for other scripts to access it.

    public static UniversalSerializedPersistenceSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<UniversalSerializedPersistenceSystem>();
            }

            return instance;
        }
    }
    #endregion

    #region Variables
    public bool SaveData = false;
    public bool LoadData = false;

    public static string fileName = "PersistentDataSave";
    public static string fileFormat = "JDD";
    public static string streamingAssetPath = Application.streamingAssetsPath;
    private static string FilePath => Path.Combine(streamingAssetPath, fileName);

    [HideInInspector] public static SerializableDataSet serializableDataSet = new SerializableDataSet();
    [HideInInspector] public static List<QueuedItem> gameObjectsDataSet = new List<QueuedItem>();

    public List<object> saveableItems = new List<object>();

    [System.Serializable]
    public struct QueuedItem
    {
        public string ID;
        public GameObject saveObject;
    }
    #endregion

    #region Update
    public void Update()
    {
        if (SaveData == true)
        {
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

            foreach (GameObject go in allObjects)
                go.BroadcastMessage("UniSave", SendMessageOptions.DontRequireReceiver);

            Save();
            SaveData = false;
        }

        if (LoadData == true)
        {
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

            foreach (GameObject go in allObjects)
                go.BroadcastMessage("UniLoad", SendMessageOptions.DontRequireReceiver);

            Load();
            LoadData = false;
        }
    }
    #endregion

    #region Save Load Zone
    public static void Save()
    {
        Debug.Log("Saving...");
        string jsonData = JsonUtility.ToJson(serializableDataSet);

        if (!Directory.Exists(streamingAssetPath))
            Directory.CreateDirectory(streamingAssetPath);

        File.WriteAllText(FilePath, jsonData);
        serializableDataSet.data.Clear();
        CryptographyInfo.Encrypt(FilePath, fileFormat);

        Debug.Log("Save was successful!");
    }

    public static void Load()
    {
        Debug.Log("Loading...");

        serializableDataSet.data.Clear();
        CryptographyInfo.Decrypt(FilePath, fileFormat);

        Debug.Log(FilePath);

        JsonUtility.FromJsonOverwrite(File.ReadAllText(FilePath), serializableDataSet);

        for (int i = 0; i < serializableDataSet.data.Count; i++)
        {
            for (int j = 0; j < gameObjectsDataSet.Count; j++)
            {
                QueuedItem queuedItem = gameObjectsDataSet[j];

                string sID = (string)DataDeserialization.Deserialize(serializableDataSet.data[i].ID);

                Debug.Log("Comparing ID: " + queuedItem.ID + " to sID: " + sID);

                if (queuedItem.ID == sID)
                {
                    Debug.Log("Loading on item: " + queuedItem.saveObject.name + " with an ID of: " + queuedItem.ID);

                    #region Deserialize Unity classes and types
                    #region Deserialize transform
                    ((STransform)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sTransform)).Deserialize(ref queuedItem.saveObject);
                    #endregion

                    #region Deserialize Camera
                    if (serializableDataSet.data[i].unitySerializableData.sCamera.Length > 0)
                        ((SCamera)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sCamera)).Deserialize(ref queuedItem.saveObject);
                    #endregion

                    #region Deserialize Audio
                    if (serializableDataSet.data[i].unitySerializableData.sAudioChorusFilter.Length > 0)
                        ((SAudioChorusFilter)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sAudioChorusFilter)).Deserialize(ref queuedItem.saveObject);

                    if (serializableDataSet.data[i].unitySerializableData.sAudioDistortionFilter.Length > 0)
                    {
                        SAudioDistortionFilter sAudioDistortionFilter = (SAudioDistortionFilter)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sAudioDistortionFilter);
                        sAudioDistortionFilter.Deserialize(ref queuedItem.saveObject);
                    }

                    if (serializableDataSet.data[i].unitySerializableData.sAudioEchoFilter.Length > 0)
                        ((SAudioEchoFilter)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sAudioEchoFilter)).Deserialize(ref queuedItem.saveObject);

                    if (serializableDataSet.data[i].unitySerializableData.sAudioHighPassFilter.Length > 0)
                        ((SAudioHighPassFilter)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sAudioHighPassFilter)).Deserialize(ref queuedItem.saveObject);

                    if (serializableDataSet.data[i].unitySerializableData.sAudioListener.Length > 0)
 
                        ((SAudioListener)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sAudioListener)).Deserialize(ref queuedItem.saveObject);


                    if (serializableDataSet.data[i].unitySerializableData.sAudioLowPassFilter.Length > 0)
                        ((SAudioLowPassFilter)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sAudioLowPassFilter)).Deserialize(ref queuedItem.saveObject);


                    if (serializableDataSet.data[i].unitySerializableData.sAudioReverbFilter.Length > 0)
                        ((SAudioReverbFilter)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sAudioReverbFilter)).Deserialize(ref queuedItem.saveObject);


                    if (serializableDataSet.data[i].unitySerializableData.sAudioReverbZone.Length > 0)
                        ((SAudioReverbZone)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sAudioReverbZone)).Deserialize(ref queuedItem.saveObject);


                    if (serializableDataSet.data[i].unitySerializableData.sAudioSource.Length > 0)
                        ((SAudioSource)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sAudioSource)).Deserialize(ref queuedItem.saveObject);

                    #endregion

                    #region Deserialize Effects
                    if (serializableDataSet.data[i].unitySerializableData.sLensFlare.Length > 0)
                        ((SLensFlare)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sLensFlare)).Deserialize(ref queuedItem.saveObject);

                    if (serializableDataSet.data[i].unitySerializableData.sLineRenderer.Length > 0)
                        ((SLineRenderer)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sLineRenderer)).Deserialize(ref queuedItem.saveObject);

                    if (serializableDataSet.data[i].unitySerializableData.sParticleSystem.Length > 0)
                        ((SParticleSystem)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sParticleSystem)).Deserialize(ref queuedItem.saveObject);

                    if (serializableDataSet.data[i].unitySerializableData.sProjector.Length > 0)
                        ((SProjector)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sProjector)).Deserialize(ref queuedItem.saveObject);

                    if (serializableDataSet.data[i].unitySerializableData.sTrailRenderer.Length > 0)
                        ((STrailRenderer)DataDeserialization.Deserialize(serializableDataSet.data[i].unitySerializableData.sTrailRenderer)).Deserialize(ref queuedItem.saveObject);
                    #endregion
                    #endregion

                    #region Deserialize User Defined Classes
                    MonoBehaviour[] saveableScripts = queuedItem.saveObject.GetComponents<MonoBehaviour>();

                    foreach (var monoItem in saveableScripts)
                    {
                        if (monoItem is IUniversalSerializedPersistenceSystem == false)
                            continue;

                        System.Type thisType = monoItem.GetType();
                        MethodInfo theMethod = thisType.GetMethod("Deserialize");
                        object[] param = new object[2] {
                            serializableDataSet.data[i].serializedScripts,
                            queuedItem.saveObject
                        };

                        theMethod.Invoke(monoItem, param);
                        break;
                    }
                    #endregion

                    #region Deserialize All Children
                    int childIndex = -1;
                    QueueData.DequeueAllChildren(queuedItem.saveObject.transform, queuedItem.saveObject.transform, serializableDataSet.data[i], ref childIndex);
                    #endregion

                    gameObjectsDataSet.RemoveAt(j);
                    break;
                }
            }
        }

        serializableDataSet.data.Clear(); ;
        gameObjectsDataSet.Clear();
        CryptographyInfo.Encrypt(FilePath, fileFormat);

        Debug.Log("Load was successful!");
    }
    #endregion
}
