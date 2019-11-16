using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Audio Distortion Filter
[System.Serializable]
class SAudioDistortionFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float distortionLevel;

    public SAudioDistortionFilter Serielize(AudioDistortionFilter _audioDistortionFilter)
    {
        SAudioDistortionFilter returnVal = new SAudioDistortionFilter
        {
            ExistsOnObject = (_audioDistortionFilter == null) ? false : true,
            Enabled = _audioDistortionFilter.enabled,

            distortionLevel = _audioDistortionFilter.distortionLevel
        };

        return returnVal;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioDistortionFilter _audioDistortionFilter = _gameObject.GetComponent<AudioDistortionFilter>();
        _audioDistortionFilter.enabled = Enabled;

        _audioDistortionFilter.distortionLevel = distortionLevel;
    }
}
#endregion
