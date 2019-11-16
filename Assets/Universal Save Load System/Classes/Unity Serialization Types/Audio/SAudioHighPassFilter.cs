using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Audio High Pass Filter
[System.Serializable]
class SAudioHighPassFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float cutoffFrequency;
    public float highpassResonanceQ;

    public SAudioHighPassFilter Serielize(AudioHighPassFilter _audioHighPassFilter)
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

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioHighPassFilter _audioHighPassFilter = _gameObject.GetComponent<AudioHighPassFilter>();
        _audioHighPassFilter.enabled = Enabled;

        _audioHighPassFilter.cutoffFrequency = cutoffFrequency;
        _audioHighPassFilter.highpassResonanceQ = highpassResonanceQ;
    }
}
#endregion
