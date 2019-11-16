using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SKeyframe
{
    public float time;
    public float value;
    public float inTangent;
    public float outTangent;
    public float inWeight;
    public float outWeight;
    public WeightedMode weightedMode;
}

public static class KeyframeExtensionMethods
{
    #region Serialization
    public static SKeyframe Serialize(this Keyframe _keyframe)
    {
        SKeyframe returnVal = new SKeyframe()
        {
            time = _keyframe.time,
            value = _keyframe.value,
            inTangent = _keyframe.inTangent,
            outTangent = _keyframe.outTangent,
            inWeight = _keyframe.inWeight,
            outWeight = _keyframe.outWeight,
            weightedMode = _keyframe.weightedMode
        };

        return returnVal;
    }

    public static SKeyframe[] Serialize(this Keyframe[] _keyframes)
    {
        List<SKeyframe> returnVal = new List<SKeyframe>();

        for (int i = 0; i < _keyframes.Length; i++)
        {
            returnVal.Add(new SKeyframe()
            {
                time = _keyframes[i].time,
                value = _keyframes[i].value,
                inTangent = _keyframes[i].inTangent,
                outTangent = _keyframes[i].outTangent,
                inWeight = _keyframes[i].inWeight,
                outWeight = _keyframes[i].outWeight,
                weightedMode = _keyframes[i].weightedMode
            });
        }

        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static Keyframe Deserialize(this SKeyframe _sKeyframe)
    {
        Keyframe returnVal = new Keyframe()
        {
            time = _sKeyframe.time,
            value = _sKeyframe.value,
            inTangent = _sKeyframe.inTangent,
            outTangent = _sKeyframe.outTangent,
            inWeight = _sKeyframe.inWeight,
            outWeight = _sKeyframe.outWeight,
            weightedMode = _sKeyframe.weightedMode
        };

        return returnVal;
    }

    public static Keyframe[] Deserialize(this SKeyframe[] _sKeyframe)
    {
        List<Keyframe> returnVal = new List<Keyframe>();

        for (int i = 0; i < _sKeyframe.Length; i++)
        {
            returnVal.Add(new Keyframe()
            {
                time = _sKeyframe[i].time,
                value = _sKeyframe[i].value,
                inTangent = _sKeyframe[i].inTangent,
                outTangent = _sKeyframe[i].outTangent,
                inWeight = _sKeyframe[i].inWeight,
                outWeight = _sKeyframe[i].outWeight,
                weightedMode = _sKeyframe[i].weightedMode
            });
        }

        return returnVal.ToArray();
    }
    #endregion
}
