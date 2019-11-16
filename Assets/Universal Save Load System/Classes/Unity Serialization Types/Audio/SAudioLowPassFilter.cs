using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Audio Low Pass Filter
[System.Serializable]
class SAudioLowPassFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float lowpassResonanceQ;
    public AnimationCurve customCutoffCurve;

    public SAudioLowPassFilter Serielize(AudioLowPassFilter _audioLowPassFilter)
    {
        SAudioLowPassFilter returnVal = new SAudioLowPassFilter
        {
            ExistsOnObject = (_audioLowPassFilter == null) ? false : true,
            Enabled = _audioLowPassFilter.enabled,

            lowpassResonanceQ = _audioLowPassFilter.lowpassResonanceQ,
            customCutoffCurve = _audioLowPassFilter.customCutoffCurve,
        };

        return returnVal;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioLowPassFilter _audioLowPassFilter = _gameObject.GetComponent<AudioLowPassFilter>();
        _audioLowPassFilter.enabled = Enabled;

        _audioLowPassFilter.lowpassResonanceQ = lowpassResonanceQ;
        _audioLowPassFilter.customCutoffCurve = customCutoffCurve;
    }
}
#endregion
