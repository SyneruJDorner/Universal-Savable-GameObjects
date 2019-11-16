using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

#region Line Renderer
[System.Serializable]
public class SLineRenderer
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public ShadowCastingMode castShadows;
    public bool recieveShadows;
    public bool dynamicOccludee;
    public MotionVectorGenerationMode motionVectors;
    public LightProbeUsage lightProbeUsage;
    public ReflectionProbeUsage reflectionProbeUsage;
    public uint renderLayerMask;
    public int renderPriority;
    public STransform probeAnchor = new STransform();
    public bool useWorldSpace;
    public bool loop;
}
#endregion

public static class LineRendererExtensionMethods
{
    #region Serialization
    public static SLineRenderer Serialize(this LineRenderer _lineRenderer)
    {
        SLineRenderer returnVal = new SLineRenderer
        {
            ExistsOnObject = (_lineRenderer == null) ? false : true,
            Enabled = _lineRenderer.enabled,

            castShadows = _lineRenderer.shadowCastingMode,
            recieveShadows = _lineRenderer.receiveShadows,
            dynamicOccludee = _lineRenderer.allowOcclusionWhenDynamic,
            motionVectors = _lineRenderer.motionVectorGenerationMode,
            lightProbeUsage = _lineRenderer.lightProbeUsage,
            reflectionProbeUsage = _lineRenderer.reflectionProbeUsage,
            renderLayerMask = _lineRenderer.renderingLayerMask,
            renderPriority = _lineRenderer.rendererPriority,
            probeAnchor = _lineRenderer.probeAnchor.Serialize(),
            useWorldSpace = _lineRenderer.useWorldSpace,
            loop = _lineRenderer.loop
        };

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static LineRenderer Deserialize(this SLineRenderer _lineRenderer, ref GameObject _gameObject)
    {
        if (_lineRenderer.ExistsOnObject == false)
            return null;

        LineRenderer returnVal = _gameObject.GetComponent<LineRenderer>();
        returnVal.enabled = _lineRenderer.Enabled;

        returnVal.shadowCastingMode = _lineRenderer.castShadows;
        returnVal.receiveShadows = _lineRenderer.recieveShadows;
        returnVal.allowOcclusionWhenDynamic = _lineRenderer.dynamicOccludee;
        returnVal.motionVectorGenerationMode = _lineRenderer.motionVectors;
        returnVal.lightProbeUsage = _lineRenderer.lightProbeUsage;
        returnVal.reflectionProbeUsage = _lineRenderer.reflectionProbeUsage;
        returnVal.renderingLayerMask = _lineRenderer.renderLayerMask;
        returnVal.rendererPriority = _lineRenderer.renderPriority;
        returnVal.probeAnchor = _lineRenderer.probeAnchor.Deserialize(ref _gameObject);
        returnVal.useWorldSpace = _lineRenderer.useWorldSpace;
        returnVal.loop = _lineRenderer.loop;
        return returnVal;
    }
    #endregion
}