using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAudioChorusFilter
{
    public bool existsOnObject = false;
    public bool enabled;

    public float dryMix;
    public float wetMix1;
    public float wetMix2;
    public float wetMix3;
    public float delay;
    public float rate;
    public float depth;
}

public static class AudioChorusFilterExtensionMethods
{
    #region Serialization
    public static SAudioChorusFilter Serialize(this AudioChorusFilter _audioChorusFilter)
    {
        SAudioChorusFilter returnVal = new SAudioChorusFilter
        {
            existsOnObject = (_audioChorusFilter == null) ? false : true,
            enabled = _audioChorusFilter.enabled,

            dryMix = _audioChorusFilter.dryMix,
            wetMix1 = _audioChorusFilter.wetMix1,
            wetMix2 = _audioChorusFilter.wetMix2,
            wetMix3 = _audioChorusFilter.wetMix3,
            delay = _audioChorusFilter.delay,
            rate = _audioChorusFilter.rate,
            depth = _audioChorusFilter.depth
        };

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static AudioChorusFilter Deserialize(this SAudioChorusFilter _audioChorusFilter, ref GameObject _providedObject)
    {
        AudioChorusFilter returnVal = _providedObject.GetComponent<AudioChorusFilter>();
        returnVal.enabled = _audioChorusFilter.enabled;

        returnVal.dryMix = _audioChorusFilter.dryMix;
        returnVal.wetMix1 = _audioChorusFilter.wetMix1;
        returnVal.wetMix2 = _audioChorusFilter.wetMix2;
        returnVal.wetMix3 = _audioChorusFilter.wetMix3;
        returnVal.delay = _audioChorusFilter.delay;
        returnVal.rate = _audioChorusFilter.rate;
        returnVal.depth = _audioChorusFilter.depth;

        return returnVal;
    }
    #endregion
}