using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class DataSerialization
{
    public static byte[] Serialize(object obj)
    {
        Debug.Log(obj);
        BinaryFormatter bf = new BinaryFormatter();
        using (var ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }

    public static byte[] SerializeMonoObject(object obj)
    {
        string data = JsonUtility.ToJson(obj);
        return Serialize(data);
    }
}
