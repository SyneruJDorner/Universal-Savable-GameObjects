using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SQuaternion
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public float w = 0;
}

public static class QuaternionExtensionMethods
{
    #region Serialization
    public static SQuaternion Serialize(this Quaternion _quaternion)
    {
        if (_quaternion == null)
            return null;

        SQuaternion returnVal = new SQuaternion
        {
            x = _quaternion.x,
            y = _quaternion.y,
            z = _quaternion.z,
            w = _quaternion.w
        };

        return returnVal;
    }

    public static SQuaternion[] Serialize(this Quaternion[] _quaternion)
    {
        if (_quaternion == null)
            return null;

        List<SQuaternion> returnVal = new List<SQuaternion>();

        for (int i = 0; i < _quaternion.Length; i++)
        {
            returnVal.Add(new SQuaternion
            {
                x = _quaternion[i].x,
                y = _quaternion[i].y,
                z = _quaternion[i].z,
                w = _quaternion[i].w
            });
        }
        return returnVal.ToArray();
    }
    #endregion

    #region Serialization
    public static Quaternion Deserialize(this SQuaternion _quaternion)
    {
        Quaternion returnVal = new Quaternion
        {
            x = _quaternion.x,
            y = _quaternion.y,
            z = _quaternion.z,
            w = _quaternion.w
        };

        return returnVal;
    }

    public static Quaternion[] Deserialize(this SQuaternion[] _quaternion)
    {
        List<Quaternion> returnVal = new List<Quaternion>();

        for (int i = 0; i < _quaternion.Length; i++)
        {
            returnVal.Add(new Quaternion
            {
                x = _quaternion[i].x,
                y = _quaternion[i].y,
                z = _quaternion[i].z,
                w = _quaternion[i].w
            });
        }

        return returnVal.ToArray();
    }
    #endregion
}