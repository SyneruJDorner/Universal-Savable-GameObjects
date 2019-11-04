using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableData
{
    public byte[] name;
    public byte[] activeInHierarchy;
    public byte[] sTransform;// = new STransform();
    public byte[] sCamera;// = new SCamera();
    public byte[] sAudioListener;// = new SAudioListener();

    //public byte[] serializedData;
    public List<UserDefinedData> serializedScripts = new List<UserDefinedData>();
}

[System.Serializable]
public class UserDefinedData
{
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
[System.Serializable]
class SAudioListener
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public SAudioListener Serielize(AudioListener _audioListener)
    {
        SAudioListener RetSAudioListener = new SAudioListener
        {
            ExistsOnObject = (_audioListener == null) ? false : true,
            Enabled = _audioListener.enabled
        };

        return RetSAudioListener;
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
        SQuaternion RetSQuaternion = new SQuaternion
        {
            x = _quaternion.x,
            y = _quaternion.y,
            z = _quaternion.z,
            w = _quaternion.w
        };

        return RetSQuaternion;
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
        SVector4 RetSVector4 = new SVector4
        {
            x = _vector4.x,
            y = _vector4.y,
            z = _vector4.z,
            w = _vector4.w
        };

        return RetSVector4;
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
        SVector3 RetSVector3 = new SVector3
        {
            x = _vector3.x,
            y = _vector3.y,
            z = _vector3.z
        };

        return RetSVector3;
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
        SVector2 RetSVector2 = new SVector2
        {
            x = _vector2.x,
            y = _vector2.y
        };

        return RetSVector2;
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
        SColor RetSColor = new SColor
        {
            r = _color.r,
            g = _color.g,
            b = _color.b,
            a = _color.a
        };

        return RetSColor;
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
        SViewPortRect RetSViewPortRect = new SViewPortRect
        {
            x = _rect.x,
            y = _rect.y,
            w = _rect.width,
            h = _rect.height
        };

        return RetSViewPortRect;
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