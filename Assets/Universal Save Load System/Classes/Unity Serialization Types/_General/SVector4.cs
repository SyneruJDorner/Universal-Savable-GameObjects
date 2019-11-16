using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SVector4
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public float w = 0;
}


public static class Vector4ExtensionMethods
{
    #region Serialization
    public static SVector4 Serialize(this Vector4 _Vector4)
    {
        if (_Vector4 == null)
            return null;

        SVector4 returnVal = new SVector4
        {
            x = _Vector4.x,
            y = _Vector4.y,
            z = _Vector4.z,
            w = _Vector4.w
        };

        return returnVal;
    }

    public static SVector4[] Serialize(this Vector4[] _Vector4)
    {
        if (_Vector4 == null)
            return null;

        List<SVector4> returnVal = new List<SVector4>();

        for (int i = 0; i < _Vector4.Length; i++)
        {
            returnVal.Add(new SVector4
            {
                x = _Vector4[i].x,
                y = _Vector4[i].y,
                z = _Vector4[i].z,
                w = _Vector4[i].w
            });

        }

        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static Vector4 Deserialize(this SVector4 _Vector4)
    {
        Vector4 returnVal = new Vector4
        {
            x = _Vector4.x,
            y = _Vector4.y,
            z = _Vector4.z,
            w = _Vector4.w
        };

        return returnVal;
    }

    public static Vector4[] Deserialize(this SVector4[] _Vector4)
    {
        List<Vector4> returnVal = new List<Vector4>();

        for (int i = 0; i < _Vector4.Length; i++)
        {
            returnVal.Add(new Vector4
            {
                x = _Vector4[i].x,
                y = _Vector4[i].y,
                z = _Vector4[i].z,
                w = _Vector4[i].w
            });
        }

        return returnVal.ToArray();
    }
    #endregion
}