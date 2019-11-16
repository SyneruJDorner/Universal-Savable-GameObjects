using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Audio Source
[System.Serializable]
class SAudioSource
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
    public AnimationCurve rolloffCustomCurve;
    public AnimationCurve panLevelCustomCurve;
    public AnimationCurve spreadCustomCurve;
    public AnimationCurve reverbZoneMixCustomCurve;

    public SAudioSource Serielize(AudioSource _audioSource)
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
            rolloffCustomCurve = _audioSource.GetCustomCurve(AudioSourceCurveType.CustomRolloff),
            panLevelCustomCurve = _audioSource.GetCustomCurve(AudioSourceCurveType.SpatialBlend),
            spreadCustomCurve = _audioSource.GetCustomCurve(AudioSourceCurveType.Spread),
            reverbZoneMixCustomCurve = _audioSource.GetCustomCurve(AudioSourceCurveType.ReverbZoneMix)
        };

        return returnVal;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioSource _audioSource = _gameObject.GetComponent<AudioSource>();
        _audioSource.enabled = Enabled;

        //_audioSource.outputAudioMixerGroup = outputAudioMixerGroup;
        //_audioSource.clip = audioClip;
        _audioSource.playOnAwake = playOnAwake;
        _audioSource.volume = volume;
        _audioSource.pitch = pitch;
        _audioSource.loop = loop;
        _audioSource.mute = mute;
        _audioSource.spatialize = spatialize;
        _audioSource.spatializePostEffects = spatializePostEffect;
        _audioSource.priority = priority;
        _audioSource.dopplerLevel = dopplerLevel;
        _audioSource.minDistance = minDistance;
        _audioSource.maxDistance = maxDistance;
        _audioSource.panStereo = pan2D;
        _audioSource.rolloffMode = rolloffMode;
        _audioSource.bypassEffects = bypassEffects;
        _audioSource.bypassListenerEffects = bypassListenerEffects;
        _audioSource.bypassReverbZones = bypassReverbZones;
        _audioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, rolloffCustomCurve);
        _audioSource.SetCustomCurve(AudioSourceCurveType.SpatialBlend, panLevelCustomCurve);
        _audioSource.SetCustomCurve(AudioSourceCurveType.Spread, spreadCustomCurve);
        _audioSource.SetCustomCurve(AudioSourceCurveType.ReverbZoneMix, reverbZoneMixCustomCurve);
    }
}
#endregion
