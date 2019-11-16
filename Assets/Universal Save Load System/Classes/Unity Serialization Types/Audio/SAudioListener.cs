using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Audio Listener
[System.Serializable]
class SAudioListener
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public SAudioListener Serielize(AudioListener _audioListener)
    {
        SAudioListener returnVal = new SAudioListener
        {
            ExistsOnObject = (_audioListener == null) ? false : true,
            Enabled = _audioListener.enabled
        };

        return returnVal;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioListener _audioListener = _gameObject.GetComponent<AudioListener>();
        _audioListener.enabled = Enabled;
    }
}
#endregion
