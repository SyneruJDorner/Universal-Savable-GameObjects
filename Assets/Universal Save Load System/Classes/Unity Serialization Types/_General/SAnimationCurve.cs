using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAnimationCurve
{
    public SKeyframe[] keys;
    public WrapMode postWrapMode;
    public WrapMode preWrapMode;
}

[System.Serializable]
public class SMinMaxCurve
{
    public float constant;
    public float constantMax;
    public float constantMin;
    public SAnimationCurve curve = new SAnimationCurve();
    public SAnimationCurve curveMax = new SAnimationCurve();
    public SAnimationCurve curveMin = new SAnimationCurve();
    public float curveMultiplier;
    public ParticleSystemCurveMode mode;
}

public static class AnimationCurveExtensionMethods
{
    #region Serialization
    public static SAnimationCurve Serialize(this AnimationCurve _animationCurve)
    {
        if (_animationCurve == null)
            return null;

        SAnimationCurve returnVal = new SAnimationCurve()
        {
            keys = _animationCurve.keys.Serialize(),
            postWrapMode = _animationCurve.postWrapMode,
            preWrapMode = _animationCurve.preWrapMode
        };

        return returnVal;
    }

    public static SAnimationCurve[] Serialize(this AnimationCurve[] _animationCurve)
    {
        if (_animationCurve == null)
            return null;

        List<SAnimationCurve> returnVal = new List<SAnimationCurve>();

        for (int i = 0; i < _animationCurve.Length; i++)
        {
            returnVal.Add(new SAnimationCurve()
            {
                keys = _animationCurve[i].keys.Serialize(),
                postWrapMode = _animationCurve[i].postWrapMode,
                preWrapMode = _animationCurve[i].preWrapMode
            });
        }

        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static AnimationCurve Deserialize(this SAnimationCurve _animationCurve)
    {
        if (_animationCurve == null)
            return null;

        AnimationCurve returnVal = new AnimationCurve()
        {
            keys = _animationCurve.keys.Deserialize(),
            postWrapMode = _animationCurve.postWrapMode,
            preWrapMode = _animationCurve.preWrapMode
        };

        return returnVal;
    }

    public static AnimationCurve[] Deserialize(this SAnimationCurve[] _animationCurve)
    {
        if (_animationCurve == null)
            return null;

        List<AnimationCurve> returnVal = new List<AnimationCurve>();

        for (int i = 0; i < _animationCurve.Length; i++)
        {
            returnVal.Add(new AnimationCurve()
            {
                keys = _animationCurve[i].keys.Deserialize(),
                postWrapMode = _animationCurve[i].postWrapMode,
                preWrapMode = _animationCurve[i].preWrapMode
            });
        }

        return returnVal.ToArray();
    }
    #endregion
}

public static class MinMaxCurveExtensionMethods
{
    #region Serialization
    public static SMinMaxCurve Serialize(this ParticleSystem.MinMaxCurve _minMaxCurve)
    {
        SMinMaxCurve returnVal = new SMinMaxCurve
        {
            constant = _minMaxCurve.constant,
            constantMax = _minMaxCurve.constantMax,
            constantMin = _minMaxCurve.constantMin,
            curve = _minMaxCurve.curve.Serialize(),
            curveMax = _minMaxCurve.curveMax.Serialize(),
            curveMin = _minMaxCurve.curveMin.Serialize(),
            curveMultiplier = _minMaxCurve.curveMultiplier,
            mode = _minMaxCurve.mode
        };

        return returnVal;
    }

    public static SMinMaxCurve[] Serialize(this ParticleSystem.MinMaxCurve[] _minMaxCurve)
    {
        List<SMinMaxCurve> returnVal = new List<SMinMaxCurve>();

        for (int i = 0; i < _minMaxCurve.Length; i++)
        {
            returnVal.Add(new SMinMaxCurve
            {
                constant = _minMaxCurve[i].constant,
                constantMax = _minMaxCurve[i].constantMax,
                constantMin = _minMaxCurve[i].constantMin,
                curve = _minMaxCurve[i].curve.Serialize(),
                curveMax = _minMaxCurve[i].curveMax.Serialize(),
                curveMin = _minMaxCurve[i].curveMin.Serialize(),
                curveMultiplier = _minMaxCurve[i].curveMultiplier,
                mode = _minMaxCurve[i].mode
            });
        }

        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static ParticleSystem.MinMaxCurve Deserialize(this SMinMaxCurve _minMaxCurve)
    {
        ParticleSystem.MinMaxCurve returnVal = new ParticleSystem.MinMaxCurve
        {
            constant = _minMaxCurve.constant,
            constantMax = _minMaxCurve.constantMax,
            constantMin = _minMaxCurve.constantMin,
            curve = _minMaxCurve.curve.Deserialize(),
            curveMax = _minMaxCurve.curveMax.Deserialize(),
            curveMin = _minMaxCurve.curveMin.Deserialize(),
            curveMultiplier = _minMaxCurve.curveMultiplier,
            mode = _minMaxCurve.mode
        };

        return returnVal;
    }

    public static ParticleSystem.MinMaxCurve[] Deserialize(this SMinMaxCurve[] _minMaxCurve)
    {
        List<ParticleSystem.MinMaxCurve> returnVal = new List<ParticleSystem.MinMaxCurve>();

        for (int i = 0; i < _minMaxCurve.Length; i++)
        {
            returnVal.Add(new ParticleSystem.MinMaxCurve
            {
                constant = _minMaxCurve[i].constant,
                constantMax = _minMaxCurve[i].constantMax,
                constantMin = _minMaxCurve[i].constantMin,
                curve = _minMaxCurve[i].curve.Deserialize(),
                curveMax = _minMaxCurve[i].curveMax.Deserialize(),
                curveMin = _minMaxCurve[i].curveMin.Deserialize(),
                curveMultiplier = _minMaxCurve[i].curveMultiplier,
                mode = _minMaxCurve[i].mode
            });
        }


        return returnVal.ToArray();
    }
    #endregion
}