using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SerializableData
{
    public byte[] ID;
    public byte[] activeInHierarchy;
    public byte[] sTransform;
    public byte[] sCamera;

    #region Audio
    public byte[] sAudioChorusFilter;
    public byte[] sAudioDistortionFilter;
    public byte[] sAudioEchoFilter;
    public byte[] sAudioHighPassFilter;
    public byte[] sAudioListener;
    public byte[] sAudioLowPassFilter;
    public byte[] sAudioReverbFilter;
    public byte[] sAudioReverbZone;
    public byte[] sAudioSource;
    #endregion

    //public byte[] serializedData;
    public List<UserDefinedData> serializedScripts = new List<UserDefinedData>();

    //Children info
    public List<SerializableChildData> serializableChildData = new List<SerializableChildData>();
}

[System.Serializable]
public class SerializableChildData
{
    public byte[] rootParentID;
    public byte[] activeInHierarchy;
    public byte[] sTransform;
    public byte[] sCamera;

    #region Audio
    public byte[] sAudioChorusFilter;
    public byte[] sAudioDistortionFilter;
    public byte[] sAudioEchoFilter;
    public byte[] sAudioHighPassFilter;
    public byte[] sAudioListener;
    public byte[] sAudioLowPassFilter;
    public byte[] sAudioReverbFilter;
    public byte[] sAudioReverbZone;
    public byte[] sAudioSource;
    #endregion

    public List<UserDefinedData> serializedScripts = new List<UserDefinedData>();
}

[System.Serializable]
public class UserDefinedData
{
    public string ID;
    public string scriptName;
    public byte[] serializedData;
}

//Unity Types (Serielized)
#region Transform
[System.Serializable]
class STransform
{
    public SVector3 localPosition = new SVector3();
    public SQuaternion localRotation = new SQuaternion();
    public SVector3 localScale = new SVector3();

    public STransform Serielize(Transform _trans)
    {
        STransform RetSTransform = new STransform();

        RetSTransform.localPosition.x = _trans.localPosition.x;
        RetSTransform.localPosition.y = _trans.localPosition.y;
        RetSTransform.localPosition.z = _trans.localPosition.z;

        RetSTransform.localRotation.x = _trans.localRotation.x;
        RetSTransform.localRotation.y = _trans.localRotation.y;
        RetSTransform.localRotation.z = _trans.localRotation.z;
        RetSTransform.localRotation.w = _trans.localRotation.w;

        RetSTransform.localScale.x = _trans.localScale.x;
        RetSTransform.localScale.y = _trans.localScale.y;
        RetSTransform.localScale.z = _trans.localScale.z;

        return RetSTransform;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        _gameObject.transform.localPosition = new Vector3(localPosition.x, localPosition.y, localPosition.z);
        _gameObject.transform.localRotation = new Quaternion(localRotation.x, localRotation.y, localRotation.z, localRotation.w);
        _gameObject.transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
    }
}
#endregion

#region AR

#endregion

#region Camera
[System.Serializable]
class SCamera
{
    public bool ExistsOnObject = false;
    public bool Enabled;
    public int ClearFlag;
    public SColor BackGroundColor = new SColor();
    public int GateFitMode;
    public SVector2 SensorSize = new SVector2();
    public SVector2 LensShift = new SVector2();
    public float FocalLength;
    public SViewPortRect NormalizedViewPortRect  = new SViewPortRect();
    public float NearClipPlane;
    public float FarClipPlane;
    public float FieldOfView;
    public bool Orthographic;
    public float OrthographicSize;
    public float Depth;
    public int CullingMask;
    public int RenderPath;
    public int TargetDisplay;
    public int TargetEye;
    public bool HDR;
    public bool AllowMSAA;
    public bool AllowDynamicResolution;
    public bool ForceIntoRT;
    public bool OcclusionCulling;
    public float StereoConvergence;
    public float StereoSeparation;

    public SCamera Serielize(Camera _cam)
    {
        SCamera RetSCamera = new SCamera
        {
            ExistsOnObject = (_cam == null) ? false : true,
            Enabled = _cam.enabled,
            ClearFlag = (int)_cam.clearFlags,
            BackGroundColor = new SColor().Serielize(_cam.backgroundColor),
            GateFitMode = (int)_cam.gateFit,
            SensorSize = new SVector2().Serielize(_cam.sensorSize),
            LensShift = new SVector2().Serielize(_cam.lensShift),
            FocalLength = _cam.focalLength,
            NormalizedViewPortRect = new SViewPortRect().Serielize(_cam.rect),
            NearClipPlane = _cam.nearClipPlane,
            FarClipPlane = _cam.farClipPlane,
            FieldOfView = _cam.fieldOfView,
            Orthographic = _cam.orthographic,
            OrthographicSize = _cam.orthographicSize,
            Depth = _cam.depth,
            CullingMask = _cam.cullingMask,
            RenderPath = (int)_cam.renderingPath,
            TargetDisplay = _cam.targetDisplay,
            TargetEye = (int)_cam.stereoTargetEye,
            HDR = _cam.allowHDR,
            AllowMSAA = _cam.allowMSAA,
            AllowDynamicResolution = _cam.allowDynamicResolution,
            ForceIntoRT = _cam.forceIntoRenderTexture,
            OcclusionCulling = _cam.useOcclusionCulling,
            StereoConvergence = _cam.stereoConvergence,
            StereoSeparation = _cam.stereoSeparation
        };

        return RetSCamera;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        Camera _Camera = _gameObject.GetComponent<Camera>();
        _Camera.enabled = Enabled;
        _Camera.clearFlags = (CameraClearFlags)ClearFlag;
        _Camera.backgroundColor = BackGroundColor.Deserielize();
        _Camera.gateFit = (Camera.GateFitMode)GateFitMode;
        _Camera.sensorSize = SensorSize.Deserielize();
        _Camera.lensShift = LensShift.Deserielize();
        _Camera.focalLength = FocalLength;
        _Camera.rect = NormalizedViewPortRect.Deserielize();
        _Camera.nearClipPlane = NearClipPlane;
        _Camera.farClipPlane = FarClipPlane;
        _Camera.fieldOfView = FieldOfView;
        _Camera.orthographic = Orthographic;
        _Camera.orthographicSize = OrthographicSize;
        _Camera.depth = Depth;
        _Camera.cullingMask = CullingMask;
        _Camera.renderingPath = (RenderingPath)RenderPath;
        _Camera.targetDisplay = TargetDisplay;
        _Camera.stereoTargetEye = (StereoTargetEyeMask)TargetEye;
        _Camera.allowHDR = HDR;
        _Camera.allowMSAA = AllowMSAA;
        _Camera.allowDynamicResolution = AllowDynamicResolution;
        _Camera.forceIntoRenderTexture = ForceIntoRT;
        _Camera.useOcclusionCulling = OcclusionCulling;
        _Camera.stereoConvergence = StereoConvergence;
        _Camera.stereoSeparation = StereoSeparation;
    }
}
#endregion

#region Audio

#region Audio Chorus Filter
[System.Serializable]
class SAudioChorusFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float DryMix;
    public float WetMix1;
    public float WetMix2;
    public float WetMix3;
    public float Delay;
    public float Rate;
    public float Depth;

    public SAudioChorusFilter Serielize(AudioChorusFilter _audioChorusFilter)
    {
        SAudioChorusFilter returnVal = new SAudioChorusFilter
        {
            ExistsOnObject = (_audioChorusFilter == null) ? false : true,
            Enabled = _audioChorusFilter.enabled,

            DryMix = _audioChorusFilter.dryMix,
            WetMix1 = _audioChorusFilter.wetMix1,
            WetMix2 = _audioChorusFilter.wetMix2,
            WetMix3 = _audioChorusFilter.wetMix3,
            Delay = _audioChorusFilter.delay,
            Rate = _audioChorusFilter.rate,
            Depth = _audioChorusFilter.depth
        };

        return returnVal;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioChorusFilter _audioChorusFilter = _gameObject.GetComponent<AudioChorusFilter>();
        _audioChorusFilter.enabled = Enabled;

        _audioChorusFilter.dryMix = DryMix;
        _audioChorusFilter.wetMix1 = WetMix1;
        _audioChorusFilter.wetMix2 = WetMix2;
        _audioChorusFilter.wetMix3 = WetMix3;
        _audioChorusFilter.delay = Delay;
        _audioChorusFilter.rate = Rate;
        _audioChorusFilter.depth = Depth;
    }
}
#endregion

#region Audio Distortion Filter
[System.Serializable]
class SAudioDistortionFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float distortionLevel;

    public SAudioDistortionFilter Serielize(AudioDistortionFilter _audioDistortionFilter)
    {
        SAudioDistortionFilter returnVal = new SAudioDistortionFilter
        {
            ExistsOnObject = (_audioDistortionFilter == null) ? false : true,
            Enabled = _audioDistortionFilter.enabled,

            distortionLevel = _audioDistortionFilter.distortionLevel
        };

        return returnVal;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioDistortionFilter _audioDistortionFilter = _gameObject.GetComponent<AudioDistortionFilter>();
        _audioDistortionFilter.enabled = Enabled;

        _audioDistortionFilter.distortionLevel = distortionLevel;
    }
}
#endregion

#region Audio Echo Filter
[System.Serializable]
class SAudioEchoFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float delay;
    public float decayRatio;
    public float wetMix;
    public float dryMix;

    public SAudioEchoFilter Serielize(AudioEchoFilter _audioEchoFilter)
    {
        SAudioEchoFilter returnVal = new SAudioEchoFilter
        {
            ExistsOnObject = (_audioEchoFilter == null) ? false : true,
            Enabled = _audioEchoFilter.enabled,

            delay = _audioEchoFilter.delay,
            decayRatio = _audioEchoFilter.decayRatio,
            wetMix = _audioEchoFilter.wetMix,
            dryMix = _audioEchoFilter.dryMix
        };

        return returnVal;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioEchoFilter _audioEchoFilter = _gameObject.GetComponent<AudioEchoFilter>();
        _audioEchoFilter.enabled = Enabled;

        _audioEchoFilter.delay = delay;
        _audioEchoFilter.decayRatio = decayRatio;
        _audioEchoFilter.wetMix = wetMix;
        _audioEchoFilter.dryMix = dryMix;
    }
}
#endregion

#region Audio High Pass Filter
[System.Serializable]
class SAudioHighPassFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float cutoffFrequency;
    public float highpassResonanceQ;

    public SAudioHighPassFilter Serielize(AudioHighPassFilter _audioHighPassFilter)
    {
        SAudioHighPassFilter returnVal = new SAudioHighPassFilter
        {
            ExistsOnObject = (_audioHighPassFilter == null) ? false : true,
            Enabled = _audioHighPassFilter.enabled,

            cutoffFrequency = _audioHighPassFilter.cutoffFrequency,
            highpassResonanceQ = _audioHighPassFilter.highpassResonanceQ,
        };

        return returnVal;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioHighPassFilter _audioHighPassFilter = _gameObject.GetComponent<AudioHighPassFilter>();
        _audioHighPassFilter.enabled = Enabled;

        _audioHighPassFilter.cutoffFrequency = cutoffFrequency;
        _audioHighPassFilter.highpassResonanceQ = highpassResonanceQ;
    }
}
#endregion

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

#region Audio Low Pass Filter
[System.Serializable]
class SAudioLowPassFilter
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float lowpassResonanceQ;
    public AnimationCurve customCutoffCurve;

    public SAudioLowPassFilter Serielize(AudioLowPassFilter _audioLowPassFilter)
    {
        SAudioLowPassFilter returnVal = new SAudioLowPassFilter
        {
            ExistsOnObject = (_audioLowPassFilter == null) ? false : true,
            Enabled = _audioLowPassFilter.enabled,

            lowpassResonanceQ = _audioLowPassFilter.lowpassResonanceQ,
            customCutoffCurve = _audioLowPassFilter.customCutoffCurve,
        };

        return returnVal;
    }

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        AudioLowPassFilter _audioLowPassFilter = _gameObject.GetComponent<AudioLowPassFilter>();
        _audioLowPassFilter.enabled = Enabled;

        _audioLowPassFilter.lowpassResonanceQ = lowpassResonanceQ;
        _audioLowPassFilter.customCutoffCurve = customCutoffCurve;
    }
}
#endregion

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

#endregion

#region General
[System.Serializable]
class SQuaternion
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public float w = 0;

    public SQuaternion Serielize(Quaternion _quaternion)
    {
        SQuaternion returnVal = new SQuaternion
        {
            x = _quaternion.x,
            y = _quaternion.y,
            z = _quaternion.z,
            w = _quaternion.w
        };

        return returnVal;
    }

    public Quaternion Deserielize()
    {
        Quaternion _quaternion = new Quaternion
        {
            x = this.x,
            y = this.y,
            z = this.z,
            w = this.w
        };

        return _quaternion;
    }
}

[System.Serializable]
class SVector4
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public float w = 0;

    public SVector4 Serielize(Vector4 _vector4)
    {
        SVector4 returnVal = new SVector4
        {
            x = _vector4.x,
            y = _vector4.y,
            z = _vector4.z,
            w = _vector4.w
        };

        return returnVal;
    }

    public Vector4 Deserielize()
    {
        Vector4 _vector4 = new Vector4
        {
            x = this.x,
            y = this.y,
            z = this.z,
            w = this.w
        };

        return _vector4;
    }
}

[System.Serializable]
class SVector3
{
    public float x = 0;
    public float y = 0;
    public float z = 0;

    public SVector3 Serielize(Vector3 _vector3)
    {
        SVector3 returnVal = new SVector3
        {
            x = _vector3.x,
            y = _vector3.y,
            z = _vector3.z
        };

        return returnVal;
    }

    public Vector3 Deserielize()
    {
        Vector3 _vector3 = new Vector3
        {
            x = this.x,
            y = this.y,
            z = this.z
        };

        return _vector3;
    }
}

[System.Serializable]
class SVector2
{
    public float x = 0;
    public float y = 0;

    public SVector2 Serielize(Vector2 _vector2)
    {
        SVector2 returnVal = new SVector2
        {
            x = _vector2.x,
            y = _vector2.y
        };

        return returnVal;
    }

    public Vector2 Deserielize()
    {
        Vector2 _vector2 = new Vector2
        {
            x = this.x,
            y = this.y
        };

        return _vector2;
    }
}

[System.Serializable]
class SColor
{
    public float r = 0;
    public float g = 0;
    public float b = 0;
    public float a = 0;

    public SColor Serielize(Color _color)
    {
        SColor returnVal = new SColor
        {
            r = _color.r,
            g = _color.g,
            b = _color.b,
            a = _color.a
        };

        return returnVal;
    }

    public Color Deserielize()
    {
        Color _color = new Color
        {
            r = r,
            g = g,
            b = b,
            a = a
        };
        return _color;
    }
}

[System.Serializable]
class SViewPortRect
{
    public float x = 0;
    public float y = 0;
    public float w = 0;
    public float h = 0;

    public SViewPortRect Serielize(Rect _rect)
    {
        SViewPortRect returnVal = new SViewPortRect
        {
            x = _rect.x,
            y = _rect.y,
            w = _rect.width,
            h = _rect.height
        };

        return returnVal;
    }

    public Rect Deserielize()
    {
        Rect _rect = new Rect
        {
            x = this.x,
            y = this.y,
            width = this.w,
            height = this.h
        };

        return _rect;
    }
}
#endregion