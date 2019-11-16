using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAudioListener
{
    public bool ExistsOnObject = false;
    public bool Enabled;
}

public static class AudioListenerExtensionMethods
{
    #region Serialization
    public static SAudioListener Serialize(this AudioListener _audioListener)
    {
        SAudioListener returnVal = new SAudioListener
        {
            ExistsOnObject = (_audioListener == null) ? false : true,
            Enabled = _audioListener.enabled
        };

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static AudioListener Deserialize(this SAudioListener _audioListener, ref GameObject _gameObject)
    {
        if (_audioListener.ExistsOnObject == false)
            return null;

        AudioListener returnVal = _gameObject.GetComponent<AudioListener>();
        returnVal.enabled = _audioListener.Enabled;
        return returnVal;
    }
    #endregion
}