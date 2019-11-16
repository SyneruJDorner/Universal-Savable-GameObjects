using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAudioReverbZone
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
}

public static class AudioReverbZoneExtensionMethods
{
    #region Serialization
    public static SAudioReverbZone Serialize(this AudioReverbZone _audioReverbZone)
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
    #endregion

    #region Deserialization
    public static AudioReverbZone Deserialize(this SAudioReverbZone _audioReverbZone, ref GameObject _gameObject)
    {
        if (_audioReverbZone.ExistsOnObject == false)
            return null;

        AudioReverbZone returnVal = _gameObject.GetComponent<AudioReverbZone>();
        returnVal.enabled = _audioReverbZone.Enabled;

        returnVal.minDistance = _audioReverbZone.minDistance;
        returnVal.maxDistance = _audioReverbZone.maxDistance;
        returnVal.reverbPreset = _audioReverbZone.reverbPreset;
        returnVal.room = _audioReverbZone.room;
        returnVal.roomHF = _audioReverbZone.roomHF;
        returnVal.decayTime = _audioReverbZone.decayTime;
        returnVal.decayHFRatio = _audioReverbZone.decayHFRatio;
        returnVal.reflections = _audioReverbZone.reflections;
        returnVal.reflectionsDelay = _audioReverbZone.reflectionsDelay;
        returnVal.reverb = _audioReverbZone.reverb;
        returnVal.reverbDelay = _audioReverbZone.reverbDelay;
        returnVal.HFReference = _audioReverbZone.hfReference;
        returnVal.diffusion = _audioReverbZone.diffusion;
        returnVal.LFReference = _audioReverbZone.lfReference;
        returnVal.roomLF = _audioReverbZone.roomLF;
        return returnVal;
    }
    #endregion
}