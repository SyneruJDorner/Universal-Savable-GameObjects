using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAudioLowPassFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float lowpassResonanceQ;
    public SAnimationCurve customCutoffCurve = new SAnimationCurve();
}

public static class AudioLowPassFilterExtensionMethods
{
    #region Serialization
    public static SAudioLowPassFilter Serialize(this AudioLowPassFilter _audioLowPassFilter)
    {
        SAudioLowPassFilter returnVal = new SAudioLowPassFilter
        {
            ExistsOnObject = (_audioLowPassFilter == null) ? false : true,
            Enabled = _audioLowPassFilter.enabled,

            lowpassResonanceQ = _audioLowPassFilter.lowpassResonanceQ,
            customCutoffCurve = _audioLowPassFilter.customCutoffCurve.Serialize(),
        };

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static AudioLowPassFilter Deserialize(this SAudioLowPassFilter _audioLowPassFilter, ref GameObject _gameObject)
    {
        if (_audioLowPassFilter.ExistsOnObject == false)
            return null;

        AudioLowPassFilter returnVal = _gameObject.GetComponent<AudioLowPassFilter>();
        returnVal.enabled = _audioLowPassFilter.Enabled;

        returnVal.lowpassResonanceQ = _audioLowPassFilter.lowpassResonanceQ;
        returnVal.customCutoffCurve = _audioLowPassFilter.customCutoffCurve.Deserialize();
        return returnVal;
    }
    #endregion
}