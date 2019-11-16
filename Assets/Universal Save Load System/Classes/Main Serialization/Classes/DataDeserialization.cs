using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

public class DataDeserialization
{
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

    public static void DeserializeMonoObject(byte[] data, object obj)
    {
        string deserializedData = (string)Deserialize(data);
        JsonUtility.FromJsonOverwrite(deserializedData, obj);
    }
}
