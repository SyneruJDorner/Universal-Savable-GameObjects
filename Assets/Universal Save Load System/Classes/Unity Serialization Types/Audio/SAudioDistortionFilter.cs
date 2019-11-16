using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAudioDistortionFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float distortionLevel;
}

public static class AudioDistortionFilterExtensionMethods
{
    #region Serialization
    public static SAudioDistortionFilter Serialize(this AudioDistortionFilter _audioDistortionFilter)
    {
        SAudioDistortionFilter returnVal = new SAudioDistortionFilter
        {
            ExistsOnObject = (_audioDistortionFilter == null) ? false : true,
            Enabled = _audioDistortionFilter.enabled,

            distortionLevel = _audioDistortionFilter.distortionLevel
        };

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static AudioDistortionFilter Deserialize(this SAudioDistortionFilter _audioDistortionFilter, ref GameObject _gameObject)
    {
        if (_audioDistortionFilter.ExistsOnObject == false)
            return null;

        AudioDistortionFilter returnVal = _gameObject.GetComponent<AudioDistortionFilter>();
        returnVal.enabled = _audioDistortionFilter.Enabled;

        returnVal.distortionLevel = _audioDistortionFilter.distortionLevel;
        return returnVal;
    }
    #endregion
}