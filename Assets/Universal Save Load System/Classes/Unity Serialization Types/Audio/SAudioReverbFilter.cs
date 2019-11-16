using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Audio Reverb Filter
[System.Serializable]
class SAudioReverbFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float dryLevel;
    public float room;
    public float roomHF;
    public float decayTime;
    public float decayHFRatio;
    public float reflectionsLevel;
    public float reverbLevel;
    public float reverbDelay;
    public float diffusion;
    public float density;
    public float hfReference;
    public float roomLF;
    public float lfReference;
    public float reflectionsDelay;
    public AudioReverbPreset reverbPreset;

    public SAudioReverbFilter Serielize(AudioReverbFilter _audioReverbFilter)
    {
        SAudioReverbFilter returnVal = new SAudioReverbFilter
        {
            ExistsOnObject = (_audioReverbFilter == null) ? false : true,
            Enabled = _audioReverbFilter.enabled,

            dryLevel = _audioReverbFilter.dryLevel,
            room = _audioReverbFilter.room,
            roomHF = _audioReverbFilter.roomHF,
            decayTime = _audioReverbFilter.decayTime,
            decayHFRatio = _audioReverbFilter.decayHFRatio,
            reflectionsLevel = _audioReverbFilter.reflectionsLevel,
            reverbLevel = _audioReverbFilter.reverbLevel,
            reverbDelay = _audioReverbFilter.reverbDelay,
            diffusion = _audioReverbFilter.diffusion,
            density = _audioReverbFilter.density,
            hfReference = _audioReverbFilter.hfReference,
            roomLF = _audioReverbFilter.roomLF,
            lfReference = _audioReverbFilter.lfReference,
            reflectionsDelay = _audioReverbFilter.reflectionsDelay,
            reverbPreset = _audioReverbFilter.reverbPreset,
        };

        return returnVal;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioReverbFilter _audioReverbFilter = _gameObject.GetComponent<AudioReverbFilter>();
        _audioReverbFilter.enabled = Enabled;

        _audioReverbFilter.dryLevel = dryLevel;
        _audioReverbFilter.room = room;
        _audioReverbFilter.roomHF = roomHF;
        _audioReverbFilter.decayTime = decayTime;
        _audioReverbFilter.decayHFRatio = decayHFRatio;
        _audioReverbFilter.reflectionsLevel = reflectionsLevel;
        _audioReverbFilter.reverbLevel = reverbLevel;
        _audioReverbFilter.reverbDelay = reverbDelay;
        _audioReverbFilter.diffusion = diffusion;
        _audioReverbFilter.density = density;
        _audioReverbFilter.hfReference = hfReference;
        _audioReverbFilter.lfReference = lfReference;
        _audioReverbFilter.reflectionsDelay = reflectionsDelay;
        _audioReverbFilter.reverbPreset = reverbPreset;
    }
}
#endregion
