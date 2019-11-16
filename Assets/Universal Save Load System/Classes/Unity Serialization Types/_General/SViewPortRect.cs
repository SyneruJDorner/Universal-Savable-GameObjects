using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SViewPortRect
{
    public float x = 0;
    public float y = 0;
    public float w = 0;
    public float h = 0;
}

public static class ViewPortRectExtensionMethods
{
    #region Serialization
    public static SViewPortRect Serialize(this Rect _rect)
    {
        if (_rect == null)
            return null;

        SViewPortRect returnVal = new SViewPortRect
        {
            x = _rect.x,
            y = _rect.y,
            w = _rect.width,
            h = _rect.height
        };

        return returnVal;
    }

    public static SViewPortRect[] Serialize(this Rect[] _rect)
    {
        if (_rect == null)
            return null;

        List<SViewPortRect> returnVal = new List<SViewPortRect>();

        for (int i = 0; i < _rect.Length; i++)
        {
            returnVal.Add(new SViewPortRect
            {
                x = _rect[i].x,
                y = _rect[i].y,
                w = _rect[i].width,
                h = _rect[i].height
            });
        }

        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static Rect Deserialize(this SViewPortRect _rect)
    {
        Rect returnVal = new Rect
        {
            x = _rect.x,
            y = _rect.y,
            width = _rect.w,
            height = _rect.h
        };

        return returnVal;
    }

    public static Rect[] Deserialize(this SViewPortRect[] _rect)
    {
        List<Rect> returnVal = new List<Rect>();

        for (int i = 0; i < _rect.Length; i++)
        {
            returnVal.Add(new Rect
            {
                x = _rect[i].x,
                y = _rect[i].y,
                width = _rect[i].w,
                height = _rect[i].h
            });
        }


        return returnVal.ToArray();
    }
    #endregion
}
