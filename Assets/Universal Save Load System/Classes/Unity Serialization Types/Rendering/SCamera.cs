using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SCamera
{
    public bool ExistsOnObject = false;
    public bool Enabled;
    public int ClearFlag;
    public SColor BackGroundColor = new SColor();
    public int GateFitMode;
    public SVector2 SensorSize = new SVector2();
    public SVector2 LensShift = new SVector2();
    public float FocalLength;
    public SViewPortRect NormalizedViewPortRect = new SViewPortRect();
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
}

public static class CameraExtensionMethods
{
    #region Serialization
    public static SCamera Serialize(this Camera _cam)
    {
        SCamera RetSCamera = new SCamera
        {
            ExistsOnObject = (_cam == null) ? false : true,
            Enabled = _cam.enabled,
            ClearFlag = (int)_cam.clearFlags,
            BackGroundColor = _cam.backgroundColor.Serialize(),
            GateFitMode = (int)_cam.gateFit,
            SensorSize = _cam.sensorSize.Serialize(),
            LensShift = _cam.lensShift.Serialize(),
            FocalLength = _cam.focalLength,
            NormalizedViewPortRect = _cam.rect.Serialize(),
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
    #endregion

    #region Deserialization
    public static Camera Deserialize(this SCamera _cam, ref GameObject _gameObject)
    {
        if (_cam.ExistsOnObject == false)
            return null;

        Camera _Camera = _gameObject.GetComponent<Camera>();
        _Camera.enabled = _cam.Enabled;
        _Camera.clearFlags = (CameraClearFlags)_cam.ClearFlag;
        _Camera.backgroundColor = _cam.BackGroundColor.Deserialize();
        _Camera.gateFit = (Camera.GateFitMode)_cam.GateFitMode;
        _Camera.sensorSize = _cam.SensorSize.Deserialize();
        _Camera.lensShift = _cam.LensShift.Deserialize();
        _Camera.focalLength = _cam.FocalLength;
        _Camera.rect = _cam.NormalizedViewPortRect.Deserialize();
        _Camera.nearClipPlane = _cam.NearClipPlane;
        _Camera.farClipPlane = _cam.FarClipPlane;
        _Camera.fieldOfView = _cam.FieldOfView;
        _Camera.orthographic = _cam.Orthographic;
        _Camera.orthographicSize = _cam.OrthographicSize;
        _Camera.depth = _cam.Depth;
        _Camera.cullingMask = _cam.CullingMask;
        _Camera.renderingPath = (RenderingPath)_cam.RenderPath;
        _Camera.targetDisplay = _cam.TargetDisplay;
        _Camera.stereoTargetEye = (StereoTargetEyeMask)_cam.TargetEye;
        _Camera.allowHDR = _cam.HDR;
        _Camera.allowMSAA = _cam.AllowMSAA;
        _Camera.allowDynamicResolution = _cam.AllowDynamicResolution;
        _Camera.forceIntoRenderTexture = _cam.ForceIntoRT;
        _Camera.useOcclusionCulling = _cam.OcclusionCulling;
        _Camera.stereoConvergence = _cam.StereoConvergence;
        _Camera.stereoSeparation = _cam.StereoSeparation;

        return _Camera;
    }
    #endregion
}