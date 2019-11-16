using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SColor
{
    public float r = 0;
    public float g = 0;
    public float b = 0;
    public float a = 0;
}

public static class ColorExtensionMethods
{
    #region Serialization
    public static SColor Serialize(this Color _color)
    {
        if (_color == null)
            return null;

        SColor returnVal = new SColor
        {
            r = _color.r,
            g = _color.g,
            b = _color.b,
            a = _color.a
        };

        return returnVal;
    }

    public static SColor[] Serialize(this Color[] _color)
    {
        if (_color == null)
            return null;

        List<SColor> returnVal = new List<SColor>();

        for (int i = 0; i < _color.Length; i++)
        {
            returnVal.Add(new SColor
            {
                r = _color[i].r,
                g = _color[i].g,
                b = _color[i].b,
                a = _color[i].a
            });
        }


        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static Color Deserialize(this SColor _color)
    {
        Color returnVal = new Color
        {
            r = _color.r,
            g = _color.g,
            b = _color.b,
            a = _color.a
        };
        return returnVal;
    }

    public static Color[] Deserialize(this SColor[] _color)
    {
        List<Color> returnVal = new List<Color>();

        for (int i = 0; i < _color.Length; i++)
        {
            returnVal.Add(new Color
            {
                r = _color[i].r,
                g = _color[i].g,
                b = _color[i].b,
                a = _color[i].a
            });
        }
        return returnVal.ToArray();
    }
    #endregion
}
