using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

#region Line Renderer
[System.Serializable]
class SLineRenderer
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

    public SLineRenderer Serielize(LineRenderer _lineRenderer)
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

    public void Deserielize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        LineRenderer _lineRenderer = _gameObject.GetComponent<LineRenderer>();
        _lineRenderer.enabled = Enabled;

        _lineRenderer.shadowCastingMode = castShadows;
        _lineRenderer.receiveShadows = recieveShadows;
        _lineRenderer.allowOcclusionWhenDynamic = dynamicOccludee;
        _lineRenderer.motionVectorGenerationMode = motionVectors;
        _lineRenderer.lightProbeUsage = lightProbeUsage;
        _lineRenderer.reflectionProbeUsage = reflectionProbeUsage;
        _lineRenderer.renderingLayerMask = renderLayerMask;
        _lineRenderer.rendererPriority = renderPriority;
        _lineRenderer.probeAnchor = probeAnchor.Deserialize(ref _gameObject);
        _lineRenderer.useWorldSpace = useWorldSpace;
        _lineRenderer.loop = loop;
    }
}
#endregion
