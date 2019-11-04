using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[System.Serializable]
class SavableGameObject : MonoBehaviour, IUniversalSerializedPersistenceSystem
{
    private List<UserDefinedData> serializedMonoData = new List<UserDefinedData>();
    [HideInInspector] public List<UnityEngine.Object> monoScripts = new List<UnityEngine.Object>();

    public List<UserDefinedData> Serialize()
    {
        monoScripts = gameObject.GetComponents<MonoBehaviour>().ToList<UnityEngine.Object>();

        foreach (UnityEngine.Object script in monoScripts)
        {
            var type = Type.GetType(script.GetType().ToString());
            object item = Convert.ChangeType(script, type);
            serializedMonoData.Add(new UserDefinedData() { scriptName = type.ToString(), serializedData = UniversalSerializedPersistenceSystem.SerializeMonoObject(item)});
        }

        monoScripts.Clear();
        return serializedMonoData;
    }

    public void Deserialize(List<UserDefinedData> serializedMonoData)
    {
        monoScripts = gameObject.GetComponents<MonoBehaviour>().ToList<UnityEngine.Object>();

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
        Debug.Log("Preparing to save: " + gameObject.name);
    }
}