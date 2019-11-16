using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAudioHighPassFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float cutoffFrequency;
    public float highpassResonanceQ;
}

public static class AudioHighPassFilterExtensionMethods
{
    #region Serialization
    public static SAudioHighPassFilter Serialize(this AudioHighPassFilter _audioHighPassFilter)
    {
        SAudioHighPassFilter returnVal = new SAudioHighPassFilter
        {
            ExistsOnObject = (_audioHighPassFilter == null) ? false : true,
            Enabled = _audioHighPassFilter.enabled,

            cutoffFrequency = _audioHighPassFilter.cutoffFrequency,
            highpassResonanceQ = _audioHighPassFilter.highpassResonanceQ,
        };

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static AudioHighPassFilter Deserialize(this SAudioHighPassFilter _audioHighPassFilter, ref GameObject _gameObject)
    {
        if (_audioHighPassFilter.ExistsOnObject == false)
            return null;

        AudioHighPassFilter returnVal = _gameObject.GetComponent<AudioHighPassFilter>();
        returnVal.enabled = _audioHighPassFilter.Enabled;

        returnVal.cutoffFrequency = _audioHighPassFilter.cutoffFrequency;
        returnVal.highpassResonanceQ = _audioHighPassFilter.highpassResonanceQ;
        return returnVal;
    }
    #endregion
}