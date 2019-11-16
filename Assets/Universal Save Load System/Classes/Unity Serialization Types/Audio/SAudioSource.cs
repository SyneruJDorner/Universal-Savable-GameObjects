using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAudioSource
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    //public AudioMixerGroup outputAudioMixerGroup;
    //public AudioClip audioClip;
    public bool playOnAwake;
    public float volume;
    public float pitch;
    public bool loop;
    public bool mute;
    public bool spatialize;
    public bool spatializePostEffect;
    public int priority;
    public float dopplerLevel;
    public float minDistance;
    public float maxDistance;
    public float pan2D;
    public AudioRolloffMode rolloffMode;
    public bool bypassEffects;
    public bool bypassListenerEffects;
    public bool bypassReverbZones;
    public SAnimationCurve rolloffCustomCurve = new SAnimationCurve();
    public SAnimationCurve panLevelCustomCurve = new SAnimationCurve();
    public SAnimationCurve spreadCustomCurve = new SAnimationCurve();
    public SAnimationCurve reverbZoneMixCustomCurve = new SAnimationCurve();
}

public static class AudioSourceExtensionMethods
{
    #region Serialization
    public static SAudioSource Serialize(this AudioSource _audioSource)
    {
        SAudioSource returnVal = new SAudioSource
        {
            ExistsOnObject = (_audioSource == null) ? false : true,
            Enabled = _audioSource.enabled,

            //outputAudioMixerGroup = _audioSource.outputAudioMixerGroup,
            //audioClip = _audioSource.clip,
            playOnAwake = _audioSource.playOnAwake,
            volume = _audioSource.volume,
            pitch = _audioSource.pitch,
            loop = _audioSource.loop,
            mute = _audioSource.mute,
            spatialize = _audioSource.spatialize,
            spatializePostEffect = _audioSource.spatializePostEffects,
            priority = _audioSource.priority,
            dopplerLevel = _audioSource.dopplerLevel,
            minDistance = _audioSource.minDistance,
            maxDistance = _audioSource.maxDistance,
            pan2D = _audioSource.panStereo,
            rolloffMode = _audioSource.rolloffMode,
            bypassEffects = _audioSource.bypassEffects,
            bypassListenerEffects = _audioSource.bypassListenerEffects,
            bypassReverbZones = _audioSource.bypassReverbZones,
            rolloffCustomCurve = _audioSource.GetCustomCurve(AudioSourceCurveType.CustomRolloff).Serialize(),
            panLevelCustomCurve = _audioSource.GetCustomCurve(AudioSourceCurveType.SpatialBlend).Serialize(),
            spreadCustomCurve = _audioSource.GetCustomCurve(AudioSourceCurveType.Spread).Serialize(),
            reverbZoneMixCustomCurve = _audioSource.GetCustomCurve(AudioSourceCurveType.ReverbZoneMix).Serialize()
        };

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static AudioSource Deserialize(this SAudioSource _audioSource, ref GameObject _gameObject)
    {
        if (_audioSource.ExistsOnObject == false)
            return null;

        AudioSource returnVal = _gameObject.GetComponent<AudioSource>();
        returnVal.enabled = _audioSource.Enabled;

        //returnVal.outputAudioMixerGroup = _audioSource.outputAudioMixerGroup;
        //returnVal.clip = _audioSource.audioClip;
        returnVal.playOnAwake = _audioSource.playOnAwake;
        returnVal.volume = _audioSource.volume;
        returnVal.pitch = _audioSource.pitch;
        returnVal.loop = _audioSource.loop;
        returnVal.mute = _audioSource.mute;
        returnVal.spatialize = _audioSource.spatialize;
        returnVal.spatializePostEffects = _audioSource.spatializePostEffect;
        returnVal.priority = _audioSource.priority;
        returnVal.dopplerLevel = _audioSource.dopplerLevel;
        returnVal.minDistance = _audioSource.minDistance;
        returnVal.maxDistance = _audioSource.maxDistance;
        returnVal.panStereo = _audioSource.pan2D;
        returnVal.rolloffMode = _audioSource.rolloffMode;
        returnVal.bypassEffects = _audioSource.bypassEffects;
        returnVal.bypassListenerEffects = _audioSource.bypassListenerEffects;
        returnVal.bypassReverbZones = _audioSource.bypassReverbZones;
        returnVal.SetCustomCurve(AudioSourceCurveType.CustomRolloff, _audioSource.rolloffCustomCurve.Deserialize());
        returnVal.SetCustomCurve(AudioSourceCurveType.SpatialBlend, _audioSource.panLevelCustomCurve.Deserialize());
        returnVal.SetCustomCurve(AudioSourceCurveType.Spread, _audioSource.spreadCustomCurve.Deserialize());
        returnVal.SetCustomCurve(AudioSourceCurveType.ReverbZoneMix, _audioSource.reverbZoneMixCustomCurve.Deserialize());
        return returnVal;
    }
    #endregion
}