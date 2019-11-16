using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAudioReverbFilter
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
}

public static class AudioReverbFilterExtensionMethods
{
    #region Serialization
    public static SAudioReverbFilter Serialize(this AudioReverbFilter _audioReverbFilter)
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
    #endregion

    #region Deserialization
    public static AudioReverbFilter Deserialize(this SAudioReverbFilter _audioReverbFilter, ref GameObject _gameObject)
    {
        if (_audioReverbFilter.ExistsOnObject == false)
            return null;

        AudioReverbFilter returnVal = _gameObject.GetComponent<AudioReverbFilter>();
        returnVal.enabled = _audioReverbFilter.Enabled;

        returnVal.dryLevel = _audioReverbFilter.dryLevel;
        returnVal.room = _audioReverbFilter.room;
        returnVal.roomHF = _audioReverbFilter.roomHF;
        returnVal.decayTime = _audioReverbFilter.decayTime;
        returnVal.decayHFRatio = _audioReverbFilter.decayHFRatio;
        returnVal.reflectionsLevel = _audioReverbFilter.reflectionsLevel;
        returnVal.reverbLevel = _audioReverbFilter.reverbLevel;
        returnVal.reverbDelay = _audioReverbFilter.reverbDelay;
        returnVal.diffusion = _audioReverbFilter.diffusion;
        returnVal.density = _audioReverbFilter.density;
        returnVal.hfReference = _audioReverbFilter.hfReference;
        returnVal.lfReference = _audioReverbFilter.lfReference;
        returnVal.reflectionsDelay = _audioReverbFilter.reflectionsDelay;
        returnVal.reverbPreset = _audioReverbFilter.reverbPreset;
        return returnVal;
    }
    #endregion
}