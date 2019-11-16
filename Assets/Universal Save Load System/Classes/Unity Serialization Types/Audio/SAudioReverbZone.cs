using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Audio Reverb Zone
[System.Serializable]
class SAudioReverbZone
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float minDistance;
    public float maxDistance;
    public AudioReverbPreset reverbPreset;
    public int room;
    public int roomHF;
    public float decayTime;
    public float decayHFRatio;
    public int reflections;
    public float reflectionsDelay;
    public int reverb;
    public float reverbDelay;
    public float hfReference;
    public float diffusion;
    public float lfReference;
    public int roomLF;

    public SAudioReverbZone Serielize(AudioReverbZone _audioReverbZone)
    {
        SAudioReverbZone returnVal = new SAudioReverbZone
        {
            ExistsOnObject = (_audioReverbZone == null) ? false : true,
            Enabled = _audioReverbZone.enabled,

            minDistance = _audioReverbZone.minDistance,
            maxDistance = _audioReverbZone.maxDistance,
            reverbPreset = _audioReverbZone.reverbPreset,
            room = _audioReverbZone.room,
            roomHF = _audioReverbZone.roomHF,
            decayTime = _audioReverbZone.decayTime,
            decayHFRatio = _audioReverbZone.decayHFRatio,
            reflections = _audioReverbZone.reflections,
            reflectionsDelay = _audioReverbZone.reflectionsDelay,
            reverb = _audioReverbZone.reverb,
            reverbDelay = _audioReverbZone.reverbDelay,
            hfReference = _audioReverbZone.HFReference,
            diffusion = _audioReverbZone.diffusion,
            lfReference = _audioReverbZone.LFReference,
            roomLF = _audioReverbZone.roomLF
        };

        return returnVal;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioReverbZone _audioReverbZone = _gameObject.GetComponent<AudioReverbZone>();
        _audioReverbZone.enabled = Enabled;

        _audioReverbZone.minDistance = minDistance;
        _audioReverbZone.maxDistance = maxDistance;
        _audioReverbZone.reverbPreset = reverbPreset;
        _audioReverbZone.room = room;
        _audioReverbZone.roomHF = roomHF;
        _audioReverbZone.decayTime = decayTime;
        _audioReverbZone.decayHFRatio = decayHFRatio;
        _audioReverbZone.reflections = reflections;
        _audioReverbZone.reflectionsDelay = reflectionsDelay;
        _audioReverbZone.reverb = reverb;
        _audioReverbZone.reverbDelay = reverbDelay;
        _audioReverbZone.HFReference = hfReference;
        _audioReverbZone.diffusion = diffusion;
        _audioReverbZone.LFReference = lfReference;
        _audioReverbZone.roomLF = roomLF;
    }
}
#endregion
