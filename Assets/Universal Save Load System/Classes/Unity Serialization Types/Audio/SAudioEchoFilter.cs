using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Audio Echo Filter
[System.Serializable]
class SAudioEchoFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float delay;
    public float decayRatio;
    public float wetMix;
    public float dryMix;

    public SAudioEchoFilter Serielize(AudioEchoFilter _audioEchoFilter)
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

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioEchoFilter _audioEchoFilter = _gameObject.GetComponent<AudioEchoFilter>();
        _audioEchoFilter.enabled = Enabled;

        _audioEchoFilter.delay = delay;
        _audioEchoFilter.decayRatio = decayRatio;
        _audioEchoFilter.wetMix = wetMix;
        _audioEchoFilter.dryMix = dryMix;
    }
}
#endregion
