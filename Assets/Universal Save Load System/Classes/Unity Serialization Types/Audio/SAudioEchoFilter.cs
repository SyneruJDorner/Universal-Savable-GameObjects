using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAudioEchoFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float delay;
    public float decayRatio;
    public float wetMix;
    public float dryMix;
}

public static class AudioEchoFilterExtensionMethods
{
    #region Serialization
    public static SAudioEchoFilter Serialize(this AudioEchoFilter _audioEchoFilter)
    {
        SAudioEchoFilter returnVal = new SAudioEchoFilter
        {
            ExistsOnObject = (_audioEchoFilter == null) ? false : true,
            Enabled = _audioEchoFilter.enabled,

            delay = _audioEchoFilter.delay,
            decayRatio = _audioEchoFilter.decayRatio,
            wetMix = _audioEchoFilter.wetMix,
            dryMix = _audioEchoFilter.dryMix
        };

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static void Deserialize(this SAudioEchoFilter _audioEchoFilter, ref GameObject _gameObject)
    {
        if (_audioEchoFilter.ExistsOnObject == false)
            return;

        AudioEchoFilter returnVal = _gameObject.GetComponent<AudioEchoFilter>();
        returnVal.enabled = _audioEchoFilter.Enabled;

        returnVal.delay = _audioEchoFilter.delay;
        returnVal.decayRatio = _audioEchoFilter.decayRatio;
        returnVal.wetMix = _audioEchoFilter.wetMix;
        returnVal.dryMix = _audioEchoFilter.dryMix;
    }
    #endregion
}