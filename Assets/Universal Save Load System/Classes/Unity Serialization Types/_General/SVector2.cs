using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SVector2
{
    public float x = 0;
    public float y = 0;
}

public static class Vector2ExtensionMethods
{
    #region Serialization
    public static SVector2 Serialize(this Vector2 _vector2)
    {
        if (_vector2 == null)
            return null;

        SVector2 returnVal = new SVector2
        {
            x = _vector2.x,
            y = _vector2.y
        };

        return returnVal;
    }

    public static SVector2[] Serialize(this Vector2[] _vector2)
    {
        if (_vector2 == null)
            return null;

        List<SVector2> returnVal = new List<SVector2>();

        for (int i = 0; i < _vector2.Length; i++)
        {
            returnVal.Add(new SVector2
            {
                x = _vector2[i].x,
                y = _vector2[i].y
            });

        }

        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static Vector2 Deserialize(this SVector2 _vector2)
    {
        Vector2 returnVal = new Vector2
        {
            x = _vector2.x,
            y = _vector2.y
        };

        return returnVal;
    }

    public static Vector2[] Deserialize(this SVector2[] _vector2)
    {
        List<Vector2> returnVal = new List<Vector2>();

        for (int i = 0; i < _vector2.Length; i++)
        {
            returnVal.Add(new Vector2
            {
                x = _vector2[i].x,
                y = _vector2[i].y
            });
        }

        return returnVal.ToArray();
    }
    #endregion
}
