using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Lens Flare
[System.Serializable]
public class SLensFlare
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public SColor color;
    public float brightness;
    public float fadeSpeed;
}
#endregion

public static class LensFlareExtensionMethods
{
    #region Serialization
    public static SLensFlare Serialize(this LensFlare _lensFlare)
    {
        SLensFlare returnVal = new SLensFlare
        {
            ExistsOnObject = (_lensFlare == null) ? false : true,
            Enabled = _lensFlare.enabled,

            color = _lensFlare.color.Serialize(),
            brightness = _lensFlare.brightness,
            fadeSpeed = _lensFlare.fadeSpeed
        };

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static LensFlare Deserialize(this SLensFlare _lensFlare, ref GameObject _gameObject)
    {
        if (_lensFlare.ExistsOnObject == false)
            return null;

        LensFlare returnVal = _gameObject.GetComponent<LensFlare>();
        returnVal.enabled = _lensFlare.Enabled;

        returnVal.color = new SColor().Deserialize();
        returnVal.brightness = _lensFlare.brightness;
        returnVal.fadeSpeed = _lensFlare.fadeSpeed;
        return returnVal;
    }
    #endregion
}