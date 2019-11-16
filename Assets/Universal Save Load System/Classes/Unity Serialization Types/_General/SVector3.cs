using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SVector3
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
}

public static class Vector3ExtensionMethods
{
    #region Serialization
    public static SVector3 Serialize(this Vector3 _Vector3)
    {
        if (_Vector3 == null)
            return null;

        SVector3 returnVal = new SVector3
        {
            x = _Vector3.x,
            y = _Vector3.y,
            z = _Vector3.z
        };

        return returnVal;
    }

    public static SVector3[] Serialize(this Vector3[] _Vector3)
    {
        if (_Vector3 == null)
            return null;

        List<SVector3> returnVal = new List<SVector3>();

        for (int i = 0; i < _Vector3.Length; i++)
        {
            returnVal.Add(new SVector3
            {
                x = _Vector3[i].x,
                y = _Vector3[i].y,
                z = _Vector3[i].z
            });

        }

        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static Vector3 Deserialize(this SVector3 _Vector3)
    {
        Vector3 returnVal = new Vector3
        {
            x = _Vector3.x,
            y = _Vector3.y,
            z = _Vector3.z
        };

        return returnVal;
    }

    public static Vector3[] Deserialize(this SVector3[] _Vector3)
    {
        List<Vector3> returnVal = new List<Vector3>();

        for (int i = 0; i < _Vector3.Length; i++)
        {
            returnVal.Add(new Vector3
            {
                x = _Vector3[i].x,
                y = _Vector3[i].y,
                z = _Vector3[i].z
            });
        }

        return returnVal.ToArray();
    }
    #endregion
}
