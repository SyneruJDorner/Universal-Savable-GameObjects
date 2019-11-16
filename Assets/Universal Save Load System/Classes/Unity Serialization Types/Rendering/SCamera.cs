using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public SCamera Serielize(Camera _cam)
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

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        Camera _Camera = _gameObject.GetComponent<Camera>();
        _Camera.enabled = Enabled;
        _Camera.clearFlags = (CameraClearFlags)ClearFlag;
        _Camera.backgroundColor = BackGroundColor.Deserialize();
        _Camera.gateFit = (Camera.GateFitMode)GateFitMode;
        _Camera.sensorSize = SensorSize.Deserialize();
        _Camera.lensShift = LensShift.Deserialize();
        _Camera.focalLength = FocalLength;
        _Camera.rect = NormalizedViewPortRect.Deserialize();
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
