using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SGradientAlphaKey
{
    public float alpha;
    public float time;
}

[System.Serializable]
public class SGradientColorKey
{
    public SColor color = new SColor();
    public float time;
}

[System.Serializable]
public class SGradient
{
    public SGradientAlphaKey[] alphaKeys;
    public SGradientColorKey[] colorKeys;
    public GradientMode mode;
}

[System.Serializable]
public class SMinMaxGradient
{
    public SColor color = new SColor();
    public SColor colorMax = new SColor();
    public SColor colorMin = new SColor();
    public SGradient gradient = new SGradient();
    public SGradient gradientMax = new SGradient();
    public SGradient gradientMin = new SGradient();
    public ParticleSystemGradientMode mode;
}

public static class GradientExtensionMethods
{
    #region Serialization
    public static SGradient Serialize(this Gradient _gradient)
    {
        if (_gradient == null)
            return null;

        SGradient returnVal = new SGradient()
        {
            alphaKeys = _gradient.alphaKeys.Serialize(),
            colorKeys = _gradient.colorKeys.Serialize(),
            mode = _gradient.mode
        };

        return returnVal;
    }

    public static SGradient[] Serialize(this Gradient[] _gradient)
    {
        if (_gradient == null)
            return null;

        List<SGradient> returnVal = new List<SGradient>();

        for (int i = 0; i < _gradient.Length; i++)
        {
            returnVal.Add(new SGradient()
            {
                alphaKeys = _gradient[i].alphaKeys.Serialize(),
                colorKeys = _gradient[i].colorKeys.Serialize(),
                mode = _gradient[i].mode
            });
        }

        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static Gradient Deserialize(this SGradient _gradient)
    {
        if (_gradient == null)
            return null;

        Gradient returnVal = new Gradient()
        {
            alphaKeys = _gradient.alphaKeys.Deserialize(),
            colorKeys = _gradient.colorKeys.Deserialize(),
            mode = _gradient.mode
        };

        return returnVal;
    }

    public static Gradient[] Deserialize(this SGradient[] _gradient)
    {
        if (_gradient == null)
            return null;

        List<Gradient> returnVal = new List<Gradient>();

        for (int i = 0; i < _gradient.Length; i++)
        {
            returnVal.Add(new Gradient()
            {
                alphaKeys = _gradient[i].alphaKeys.Deserialize(),
                colorKeys = _gradient[i].colorKeys.Deserialize(),
                mode = _gradient[i].mode
            });
        }
        return returnVal.ToArray();
    }
    #endregion
}

public static class MinMaxGradientExtensionMethods
{
    #region Serialization
    public static SMinMaxGradient Serialize(this ParticleSystem.MinMaxGradient _minMaxGradient)
    {
        SMinMaxGradient returnVal = new SMinMaxGradient()
        {
            color = _minMaxGradient.color.Serialize(),
            colorMax = _minMaxGradient.colorMax.Serialize(),
            colorMin = _minMaxGradient.colorMin.Serialize(),
            gradient = _minMaxGradient.gradient.Serialize(),
            gradientMax = _minMaxGradient.gradientMax.Serialize(),
            gradientMin = _minMaxGradient.gradientMin.Serialize(),
            mode = _minMaxGradient.mode
        };

        return returnVal;
    }

    public static SGradient[] Serialize(this Gradient[] _gradient)
    {
        List<SGradient> returnVal = new List<SGradient>();

        for (int i = 0; i < _gradient.Length; i++)
        {
            returnVal.Add(new SGradient()
            {
                alphaKeys = _gradient[i].alphaKeys.Serialize(),
                colorKeys = _gradient[i].colorKeys.Serialize(),
                mode = _gradient[i].mode
            });
        }

        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static ParticleSystem.MinMaxGradient Deserialize(this SMinMaxGradient _minMaxGradient)
    {
        ParticleSystem.MinMaxGradient returnVal = new ParticleSystem.MinMaxGradient()
        {
            color = _minMaxGradient.color.Deserialize(),
            colorMax = _minMaxGradient.colorMax.Deserialize(),
            colorMin = _minMaxGradient.colorMin.Deserialize(),
            gradient = _minMaxGradient.gradient.Deserialize(),
            gradientMax = _minMaxGradient.gradientMax.Deserialize(),
            gradientMin = _minMaxGradient.gradientMin.Deserialize(),
            mode = _minMaxGradient.mode
        };

        return returnVal;
    }

    public static Gradient[] Deserialize(this SGradient[] _gradient)
    {
        List<Gradient> returnVal = new List<Gradient>();

        for (int i = 0; i < _gradient.Length; i++)
        {
            returnVal.Add(new Gradient()
            {
                alphaKeys = _gradient[i].alphaKeys.Deserialize(),
                colorKeys = _gradient[i].colorKeys.Deserialize(),
                mode = _gradient[i].mode
            });
        }
        return returnVal.ToArray();
    }
    #endregion
}

public static class GradientAlphaKeyExtensionMethods
{
    #region Serialization
    public static SGradientAlphaKey Serialize(this GradientAlphaKey _gradientAlphaKey)
    {
        SGradientAlphaKey returnVal = new SGradientAlphaKey()
        {
            alpha = _gradientAlphaKey.alpha,
            time = _gradientAlphaKey.time
        };

        return returnVal;
    }

    public static SGradientAlphaKey[] Serialize(this GradientAlphaKey[] _gradientAlphaKey)
    {
        List<SGradientAlphaKey> returnVal = new List<SGradientAlphaKey>();

        for (int i = 0; i < _gradientAlphaKey.Length; i++)
        {
            returnVal.Add(new SGradientAlphaKey()
            {
                alpha = _gradientAlphaKey[i].alpha,
                time = _gradientAlphaKey[i].time
            });
        }


        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static GradientAlphaKey Deserialize(this SGradientAlphaKey _gradientAlphaKey)
    {
        GradientAlphaKey returnVal = new GradientAlphaKey()
        {
            alpha = _gradientAlphaKey.alpha,
            time = _gradientAlphaKey.time
        };

        return returnVal;
    }

    public static GradientAlphaKey[] Deserialize(this SGradientAlphaKey[] _gradientAlphaKey)
    {
        List<GradientAlphaKey> returnVal = new List<GradientAlphaKey>();

        for (int i = 0; i < _gradientAlphaKey.Length; i++)
        {
            returnVal.Add(new GradientAlphaKey()
            {
                alpha = _gradientAlphaKey[i].alpha,
                time = _gradientAlphaKey[i].time
            });
        }
        return returnVal.ToArray();
    }
    #endregion
}

public static class GradientColorKeyExtensionMethods
{
    #region Serialization
    public static SGradientColorKey Serialize(this GradientColorKey _gradientColorKey)
    {
        SGradientColorKey returnVal = new SGradientColorKey()
        {
            color = _gradientColorKey.color.Serialize(),
            time = _gradientColorKey.time
        };

        return returnVal;
    }

    public static SGradientColorKey[] Serialize(this GradientColorKey[] _gradientColorKey)
    {
        List<SGradientColorKey> returnVal = new List<SGradientColorKey>();

        for (int i = 0; i < _gradientColorKey.Length; i++)
        {
            returnVal.Add(new SGradientColorKey()
            {
                color = _gradientColorKey[i].color.Serialize(),
                time = _gradientColorKey[i].time
            });
        }


        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static GradientColorKey Deserialize(this SGradientColorKey _gradientColorKey)
    {
        GradientColorKey returnVal = new GradientColorKey()
        {
            color = _gradientColorKey.color.Deserialize(),
            time = _gradientColorKey.time
        };

        return returnVal;
    }

    public static GradientColorKey[] Deserialize(this SGradientColorKey[] _gradientColorKey)
    {
        List<GradientColorKey> returnVal = new List<GradientColorKey>();

        for (int i = 0; i < _gradientColorKey.Length; i++)
        {
            returnVal.Add(new GradientColorKey()
            {
                color = _gradientColorKey[i].color.Deserialize(),
                time = _gradientColorKey[i].time
            });
        }
        return returnVal.ToArray();
    }
    #endregion
}