﻿using System.Collections;
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

    public static string fileName = "PersistentDataSave.json";
    public static string streamingAssetPath = Application.streamingAssetsPath;
    private static string FilePath => Path.Combine(streamingAssetPath, fileName);

    private static SerializableDataSet serializableDataSet = new SerializableDataSet();
    private static List<QueuedItem> gameObjectsDataSet = new List<QueuedItem>();

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
    public static void QueueItemToSave(GameObject saveObject, string serializedGuid)
    {
        Camera cam;

        SerializableData serializableData = new SerializableData();

        #region Serilaize Object
        #region Serialize Unity classes and types
        serializableData.ID = Serialize(serializedGuid);
        serializableData.activeInHierarchy = Serialize(saveObject.activeInHierarchy);
        serializableData.sTransform = Serialize(new STransform().Serielize(saveObject.transform));
        serializableData.sCamera = (cam = saveObject.GetComponent<Camera>()) != null ? Serialize(new SCamera().Serielize(cam)) : null;

        #region Audio
        #region Audio Variables
        AudioChorusFilter audioChorusFilter;
        AudioDistortionFilter audioDistortionFilter;
        AudioEchoFilter audioEchoFilter;
        AudioHighPassFilter audioHighPassFilter;
        AudioListener audioListener;
        AudioLowPassFilter audioLowPassFilter;
        AudioReverbFilter audioReverbFilter;
        AudioReverbZone audioReverbZone;
        AudioSource audioSource;
        #endregion

        serializableData.sAudioChorusFilter = (audioChorusFilter = saveObject.GetComponent<AudioChorusFilter>()) != null ? Serialize(new SAudioChorusFilter().Serielize(audioChorusFilter)) : null;
        serializableData.sAudioDistortionFilter = (audioDistortionFilter = saveObject.GetComponent<AudioDistortionFilter>()) != null ? Serialize(new SAudioDistortionFilter().Serielize(audioDistortionFilter)) : null;
        serializableData.sAudioEchoFilter = (audioEchoFilter = saveObject.GetComponent<AudioEchoFilter>()) != null ? Serialize(new SAudioEchoFilter().Serielize(audioEchoFilter)) : null;
        serializableData.sAudioHighPassFilter = (audioHighPassFilter = saveObject.GetComponent<AudioHighPassFilter>()) != null ? Serialize(new SAudioHighPassFilter().Serielize(audioHighPassFilter)) : null;
        serializableData.sAudioListener = (audioListener = saveObject.GetComponent<AudioListener>()) != null ? Serialize(new SAudioListener().Serielize(audioListener)) : null;
        serializableData.sAudioLowPassFilter = (audioLowPassFilter = saveObject.GetComponent<AudioLowPassFilter>()) != null ? Serialize(new SAudioLowPassFilter().Serielize(audioLowPassFilter)) : null;
        serializableData.sAudioReverbFilter = (audioReverbFilter = saveObject.GetComponent<AudioReverbFilter>()) != null ? Serialize(new SAudioReverbFilter().Serielize(audioReverbFilter)) : null;
        serializableData.sAudioReverbZone = (audioReverbZone = saveObject.GetComponent<AudioReverbZone>()) != null ? Serialize(new SAudioReverbZone().Serielize(audioReverbZone)) : null;
        serializableData.sAudioSource = (audioSource = saveObject.GetComponent<AudioSource>()) != null ? Serialize(new SAudioSource().Serielize(audioSource)) : null;
        #endregion
        #endregion

        #region Serialize User Defined Classes
        MonoBehaviour[] saveableScripts = saveObject.GetComponents<MonoBehaviour>();

        foreach (var monoItem in saveableScripts)
        {
            if (monoItem is IUniversalSerializedPersistenceSystem == false)
                continue;

            System.Type thisType = monoItem.GetType();
            MethodInfo theMethod = thisType.GetMethod("Serialize");
            object[] parameters = new object[1] { saveObject };
            serializableData.serializedScripts = (List<UserDefinedData>)theMethod.Invoke(monoItem, parameters);
            break;
        }
        #endregion
        #endregion

        #region Serilaize Objects Children
        SerializeAllChildren(serializedGuid, saveObject.transform, saveObject.transform, ref serializableData);
        #endregion

        serializableDataSet.data.Add(serializableData);
        saveObject.BroadcastMessage("SaveMessage", SendMessageOptions.DontRequireReceiver);
    }

    private static void SerializeAllChildren(string serializedGuid, Transform rootParent, Transform parent, ref SerializableData serializableData)
    {
        foreach (Transform t in parent)
        {
            GameObject saveObject = t.gameObject;
            SerializableChildData serializableChildData = new SerializableChildData();

            Camera cam;

            #region Serialize Unity classes and types
            serializableChildData.rootParentID = Serialize(serializedGuid);
            serializableChildData.activeInHierarchy = Serialize(saveObject.activeInHierarchy);
            serializableChildData.sTransform = Serialize(new STransform().Serielize(saveObject.transform));
            serializableChildData.sCamera = (cam = saveObject.GetComponent<Camera>()) != null ? Serialize(new SCamera().Serielize(cam)) : null;

            #region Audio
            #region Audio Variables
            AudioChorusFilter audioChorusFilter;
            AudioDistortionFilter audioDistortionFilter;
            AudioEchoFilter audioEchoFilter;
            AudioHighPassFilter audioHighPassFilter;
            AudioListener audioListener;
            AudioLowPassFilter audioLowPassFilter;
            AudioReverbFilter audioReverbFilter;
            AudioReverbZone audioReverbZone;
            AudioSource audioSource;
            #endregion

            serializableChildData.sAudioChorusFilter = (audioChorusFilter = saveObject.GetComponent<AudioChorusFilter>()) != null ? Serialize(new SAudioChorusFilter().Serielize(audioChorusFilter)) : null;
            serializableChildData.sAudioDistortionFilter = (audioDistortionFilter = saveObject.GetComponent<AudioDistortionFilter>()) != null ? Serialize(new SAudioDistortionFilter().Serielize(audioDistortionFilter)) : null;
            serializableChildData.sAudioEchoFilter = (audioEchoFilter = saveObject.GetComponent<AudioEchoFilter>()) != null ? Serialize(new SAudioEchoFilter().Serielize(audioEchoFilter)) : null;
            serializableChildData.sAudioHighPassFilter = (audioHighPassFilter = saveObject.GetComponent<AudioHighPassFilter>()) != null ? Serialize(new SAudioHighPassFilter().Serielize(audioHighPassFilter)) : null;
            serializableChildData.sAudioListener = (audioListener = saveObject.GetComponent<AudioListener>()) != null ? Serialize(new SAudioListener().Serielize(audioListener)) : null;
            serializableChildData.sAudioLowPassFilter = (audioLowPassFilter = saveObject.GetComponent<AudioLowPassFilter>()) != null ? Serialize(new SAudioLowPassFilter().Serielize(audioLowPassFilter)) : null;
            serializableChildData.sAudioReverbFilter = (audioReverbFilter = saveObject.GetComponent<AudioReverbFilter>()) != null ? Serialize(new SAudioReverbFilter().Serielize(audioReverbFilter)) : null;
            serializableChildData.sAudioReverbZone = (audioReverbZone = saveObject.GetComponent<AudioReverbZone>()) != null ? Serialize(new SAudioReverbZone().Serielize(audioReverbZone)) : null;
            serializableChildData.sAudioSource = (audioSource = saveObject.GetComponent<AudioSource>()) != null ? Serialize(new SAudioSource().Serielize(audioSource)) : null;
            #endregion
            #endregion

            #region Serialize User Defined Classes
            MonoBehaviour[] saveableScripts = parent.GetComponents<MonoBehaviour>();

            foreach (var monoItem in saveableScripts)
            {
                if (monoItem is IUniversalSerializedPersistenceSystem == false)
                    continue;

                System.Type thisType = monoItem.GetType();
                MethodInfo theMethod = thisType.GetMethod("Serialize");
                object[] parameters = new object[1] { saveObject };
                serializableChildData.serializedScripts = (List<UserDefinedData>)theMethod.Invoke(monoItem, parameters);
                break;
            }
            #endregion

            serializableData.serializableChildData.Add(serializableChildData);
            SerializeAllChildren(serializedGuid, rootParent, t, ref serializableData);
        }
    }

    public static void Save()
    {
        Debug.Log("Saving...");
        string jsonData = JsonUtility.ToJson(serializableDataSet);

        if (!Directory.Exists(streamingAssetPath))
            Directory.CreateDirectory(streamingAssetPath);

        File.WriteAllText(FilePath, jsonData);
        serializableDataSet.data.Clear();
        Debug.Log("Save was successful!");
    }

    public static void QueueItemToLoad(GameObject saveObject, string serializedGuid)
    {
        gameObjectsDataSet.Add(new QueuedItem() { ID = serializedGuid, saveObject = saveObject });
        saveObject.BroadcastMessage("SaveMessage", SendMessageOptions.DontRequireReceiver);
    }

    public static void Load()
    {
        Debug.Log("Loading...");

        serializableDataSet.data.Clear();
        JsonUtility.FromJsonOverwrite(File.ReadAllText(FilePath), serializableDataSet);

        for (int i = 0; i < serializableDataSet.data.Count; i++)
        {
            for (int j = 0; j < gameObjectsDataSet.Count; j++)
            {
                QueuedItem queuedItem = gameObjectsDataSet[j];

                string sID = (string)Deserialize(serializableDataSet.data[i].ID);

                if (queuedItem.ID == sID)
                {
                    #region Deserialize Unity classes and types
                    #region Deserialize transform
                    STransform sTrans = (STransform)Deserialize(serializableDataSet.data[i].sTransform);
                    sTrans.Deserielize(ref queuedItem.saveObject);
                    #endregion

                    #region Deserialize Camera
                    if (serializableDataSet.data[i].sCamera.Length > 0)
                    {
                        SCamera sCamera = (SCamera)Deserialize(serializableDataSet.data[i].sCamera);
                        sCamera.Deserielize(ref queuedItem.saveObject);
                    }
                    #endregion

                    #region Deserialize Audio
                    if (serializableDataSet.data[i].sAudioChorusFilter.Length > 0)
                    {
                        SAudioChorusFilter sAudioChorusFilter = (SAudioChorusFilter)Deserialize(serializableDataSet.data[i].sAudioChorusFilter);
                        sAudioChorusFilter.Deserielize(ref queuedItem.saveObject);
                    }

                    if (serializableDataSet.data[i].sAudioDistortionFilter.Length > 0)
                    {
                        SAudioDistortionFilter sAudioDistortionFilter = (SAudioDistortionFilter)Deserialize(serializableDataSet.data[i].sAudioDistortionFilter);
                        sAudioDistortionFilter.Deserielize(ref queuedItem.saveObject);
                    }

                    if (serializableDataSet.data[i].sAudioEchoFilter.Length > 0)
                    {
                        SAudioEchoFilter sAudioEchoFilter = (SAudioEchoFilter)Deserialize(serializableDataSet.data[i].sAudioEchoFilter);
                        sAudioEchoFilter.Deserielize(ref queuedItem.saveObject);
                    }

                    if (serializableDataSet.data[i].sAudioHighPassFilter.Length > 0)
                    {
                        SAudioHighPassFilter sAudioHighPassFilter = (SAudioHighPassFilter)Deserialize(serializableDataSet.data[i].sAudioHighPassFilter);
                        sAudioHighPassFilter.Deserielize(ref queuedItem.saveObject);
                    }

                    if (serializableDataSet.data[i].sAudioListener.Length > 0)
                    {
                        SAudioListener sAudioListener = (SAudioListener)Deserialize(serializableDataSet.data[i].sAudioListener);
                        sAudioListener.Deserielize(ref queuedItem.saveObject);
                    }

                    if (serializableDataSet.data[i].sAudioLowPassFilter.Length > 0)
                    {
                        SAudioLowPassFilter sAudioLowPassFilter = (SAudioLowPassFilter)Deserialize(serializableDataSet.data[i].sAudioLowPassFilter);
                        sAudioLowPassFilter.Deserielize(ref queuedItem.saveObject);
                    }

                    if (serializableDataSet.data[i].sAudioReverbFilter.Length > 0)
                    {
                        SAudioReverbFilter sAudioReverbFilter = (SAudioReverbFilter)Deserialize(serializableDataSet.data[i].sAudioReverbFilter);
                        sAudioReverbFilter.Deserielize(ref queuedItem.saveObject);
                    }

                    if (serializableDataSet.data[i].sAudioReverbZone.Length > 0)
                    {
                        SAudioReverbZone sAudioReverbZone = (SAudioReverbZone)Deserialize(serializableDataSet.data[i].sAudioReverbZone);
                        sAudioReverbZone.Deserielize(ref queuedItem.saveObject);
                    }

                    if (serializableDataSet.data[i].sAudioSource.Length > 0)
                    {
                        SAudioSource sAudioSource = (SAudioSource)Deserialize(serializableDataSet.data[i].sAudioSource);
                        sAudioSource.Deserielize(ref queuedItem.saveObject);
                    }
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
                    DeserializeAllChildren(queuedItem.saveObject.transform, queuedItem.saveObject.transform, serializableDataSet.data[i], ref childIndex);
                    #endregion

                    gameObjectsDataSet.RemoveAt(j);
                    break;
                }
            }
        }

        serializableDataSet.data.Clear(); ;
        gameObjectsDataSet.Clear();

        Debug.Log("Load was successful!");
    }

    private static void DeserializeAllChildren(Transform rootParent, Transform parent, SerializableData serializableData, ref int childIndex)
    {
        foreach (Transform t in parent)
        {
            SerializableChildData serializableChildData  = serializableData.serializableChildData[++childIndex];
            GameObject currentObj = t.gameObject;

            #region Deserialize Unity classes and types
            #region Deserialize transform
            STransform sTrans = (STransform)Deserialize(serializableChildData.sTransform);
            sTrans.Deserielize(ref currentObj);
            #endregion

            #region Deserialize Camera
            if (serializableChildData.sCamera.Length > 0)
            {
                SCamera sCamera = (SCamera)Deserialize(serializableChildData.sCamera);
                sCamera.Deserielize(ref currentObj);
            }
            #endregion

            #region Deserialize Audio Listener
            if (serializableChildData.sAudioListener.Length > 0)
            {
                SAudioListener sAudioListener = (SAudioListener)Deserialize(serializableChildData.sAudioListener);
                sAudioListener.Deserielize(ref currentObj);
            }
            #endregion
            #endregion

            #region Deserialize User Defined Classes
            MonoBehaviour[] saveableScripts = parent.gameObject.GetComponents<MonoBehaviour>();

            foreach (var monoItem in saveableScripts)
            {
                if (monoItem is IUniversalSerializedPersistenceSystem == false)
                    continue;

                System.Type thisType = monoItem.GetType();
                MethodInfo theMethod = thisType.GetMethod("Deserialize");
                object[] param = new object[2] {
                    serializableChildData.serializedScripts,
                    currentObj
                };

                theMethod.Invoke(monoItem, param);
                break;
            }
            #endregion

            #region Deserialize All Children
            DeserializeAllChildren(rootParent, t, serializableData, ref childIndex);
            #endregion
        }
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
