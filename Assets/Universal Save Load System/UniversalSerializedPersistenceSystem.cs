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

    private static string fileName = "PersistentDataSave.json";
    private static string FilePath => Path.Combine(Application.streamingAssetsPath, fileName);

    private static SerializableDataSet serializableDataSet = new SerializableDataSet();
    private static List<GameObject> gameObjectsDataSet = new List<GameObject>();

    public List<object> saveableItems = new List<object>();
    #endregion

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

    #region Save Load Zone
    public static void QueueItemToSave(GameObject saveObject)
    {
        Camera cam;
        AudioListener audioListener;

        SerializableData serializableData = new SerializableData();

        #region Serialize Unity classes and types
        serializableData.name = Serialize(saveObject.name);
        serializableData.activeInHierarchy = Serialize(saveObject.activeInHierarchy);
        serializableData.sTransform = Serialize(new STransform().Serielize(saveObject.transform));
        serializableData.sCamera = (cam = saveObject.GetComponent<Camera>()) != null ? Serialize(new SCamera().Serielize(cam)) : null;
        serializableData.sAudioListener = (audioListener = saveObject.GetComponent<AudioListener>()) != null ? Serialize(new SAudioListener().Serielize(audioListener)) : null;
        #endregion

        #region Serialize User Defined Classes
        MonoBehaviour[] saveableScripts = saveObject.GetComponents<MonoBehaviour>();

        foreach (var monoItem in saveableScripts)
        {
            if (monoItem is IUniversalSerializedPersistenceSystem == false)
                continue;

            System.Type thisType = monoItem.GetType();
            MethodInfo theMethod = thisType.GetMethod("Serialize");

            serializableData.serializedScripts = (List<UserDefinedData>)theMethod.Invoke(monoItem, null);
            break;
        }
        #endregion

        serializableDataSet.data.Add(serializableData);
        saveObject.BroadcastMessage("SaveMessage", SendMessageOptions.DontRequireReceiver);
    }

    public static void Save()
    {
        Debug.Log("Saving...");
        string jsonData = JsonUtility.ToJson(serializableDataSet);
        File.WriteAllText(FilePath, jsonData);
        serializableDataSet.data.Clear();
        Debug.Log("Save was successful!");
    }

    public static void QueueItemToLoad(GameObject saveObject)
    {
        gameObjectsDataSet.Add(saveObject);
        saveObject.BroadcastMessage("SaveMessage", SendMessageOptions.DontRequireReceiver);
    }

    public static void Load()
    {
        Debug.Log("Loading...");

        serializableDataSet.data.Clear();
        JsonUtility.FromJsonOverwrite(File.ReadAllText(FilePath), serializableDataSet);

        for (int i = 0; i < serializableDataSet.data.Count; i++)
        {
            string sName = (string)Deserialize(serializableDataSet.data[i].name);

            for (int j = 0; j < gameObjectsDataSet.Count; j++)
            {
                GameObject currentObj = gameObjectsDataSet[j];

                if (currentObj.name == sName)
                {
                    #region Deserialize Unity classes and types
                    #region Deserialize transform
                    STransform sTrans = (STransform)Deserialize(serializableDataSet.data[i].sTransform);
                    sTrans.Deserielize(ref currentObj);
                    #endregion

                    #region Deserialize Camera
                    if (serializableDataSet.data[i].sCamera.Length > 0)
                    {
                        SCamera sCamera = (SCamera)Deserialize(serializableDataSet.data[i].sCamera);
                        sCamera.Deserielize(ref currentObj);
                    }
                    #endregion

                    #region Deserialize Audio Listener
                    if (serializableDataSet.data[i].sAudioListener.Length > 0)
                    {
                        SAudioListener sAudioListener = (SAudioListener)Deserialize(serializableDataSet.data[i].sAudioListener);
                        sAudioListener.Deserielize(ref currentObj);
                    }
                    #endregion
                    #endregion

                    #region Deserialize User Defined Classes
                    MonoBehaviour[] saveableScripts = currentObj.GetComponents<MonoBehaviour>();

                    foreach (var monoItem in saveableScripts)
                    {
                        if (monoItem is IUniversalSerializedPersistenceSystem == false)
                            continue;

                        System.Type thisType = monoItem.GetType();
                        MethodInfo theMethod = thisType.GetMethod("Deserialize");
                        object[] param = new object[1] {
                            serializableDataSet.data[i].serializedScripts
                        };

                        theMethod.Invoke(monoItem, param);
                        break;
                    }
                    #endregion
                }
            }
        }

        serializableDataSet.data.Clear(); ;
        gameObjectsDataSet.Clear();

        Debug.Log("Load was successful!");
    }
    #endregion

    #region Serialize/Deserialize Zone
    public static byte[] Serialize(object obj)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (var ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }

    public static object Deserialize(byte[] arrBytes)
    {
        using (var memStream = new MemoryStream())
        {
            var binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            var obj = binForm.Deserialize(memStream);
            return obj;
        }
    }

    public static byte[] SerializeMonoObject(object obj)
    {
        string data = JsonUtility.ToJson(obj);
        return Serialize(data);
    }

    public static void DeserializeMonoObject(byte[] data, object obj)
    {
        string deserializedData = (string)Deserialize(data);
        JsonUtility.FromJsonOverwrite(deserializedData, obj);
    }
    #endregion
}
