using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Lens Flare
[System.Serializable]
class SLensFlare
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public SColor color;
    public float brightness;
    public float fadeSpeed;

    public SLensFlare Serielize(LensFlare _lensFlare)
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

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        LensFlare _lensFlare = _gameObject.GetComponent<LensFlare>();
        _lensFlare.enabled = Enabled;

        _lensFlare.color = new SColor().Deserialize();
        _lensFlare.brightness = brightness;
        _lensFlare.fadeSpeed = fadeSpeed;
    }
}
#endregion
