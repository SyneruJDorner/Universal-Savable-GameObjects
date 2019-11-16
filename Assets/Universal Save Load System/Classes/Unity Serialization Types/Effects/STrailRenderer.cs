using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

[System.Serializable]
public class STrailRenderer
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public LineAlignment alignment;
    public bool allowOcclusionWhenDynamic;
    public bool autodestruct;
    public SGradient colorGradient;
    public bool emitting;
    public SColor endColor;
    public float endWidth;
    //public bool forceRenderingOff;
    public bool generateLightingData;
    public HideFlags hideFlags;
    public int lightmapIndex;
    public SVector4 lightmapScaleOffset;
    public LightProbeUsage lightProbeUsage;
    //public Material material;
    //public Material[] materials;
    public float minVertexDistance;
    public MotionVectorGenerationMode motionVectorGenerationMode;
    public string name;
    public int numCapVertices;
    public int numCornerVertices;
    //public STransform probeAnchor;
    //public RayTracingMode rayTracingMode;
    public int realtimeLightmapIndex;
    public SVector4 realtimeLightmapScaleOffset;
    public bool receiveShadows;
    public ReflectionProbeUsage reflectionProbeUsage;
    public int rendererPriority;
    public uint renderingLayerMask;
    public float shadowBias;
    public ShadowCastingMode shadowCastingMode;
    //public Material sharedMaterial;
    //public Material[] sharedMaterials;
    public int sortingLayerID;
    public string sortingLayerName;
    public int sortingOrder;
    public SColor startColor;
    public float startWidth;
    public LineTextureMode textureMode;
    public float time;
    public SAnimationCurve widthCurve;
    public float widthMultiplier;

    public void Test()
    {

    }
}

public static class TrailRendererExtensionMethods
{
    #region Serialization
    public static STrailRenderer Serialize(this TrailRenderer _trailRenderer)
    {
        if (_trailRenderer == null)
            return null;

        STrailRenderer returnVal = new STrailRenderer
        {
            ExistsOnObject = (_trailRenderer == null) ? false : true,
            Enabled = _trailRenderer.enabled,

            alignment = _trailRenderer.alignment,
            allowOcclusionWhenDynamic = _trailRenderer.allowOcclusionWhenDynamic,
            autodestruct = _trailRenderer.autodestruct,
            colorGradient = _trailRenderer.colorGradient.Serialize(),
            emitting = _trailRenderer.emitting,
            endColor = _trailRenderer.endColor.Serialize(),
            endWidth = _trailRenderer.endWidth,
            //forceRenderingOff = _trailRenderer.forceRenderingOff,
            generateLightingData = _trailRenderer.generateLightingData,
            hideFlags = _trailRenderer.hideFlags,
            lightmapIndex = _trailRenderer.lightmapIndex,
            lightmapScaleOffset = _trailRenderer.lightmapScaleOffset.Serialize(),
            lightProbeUsage = _trailRenderer.lightProbeUsage,
            //material = _trailRenderer.material,
            //materials = _trailRenderer.materials,
            minVertexDistance = _trailRenderer.minVertexDistance,
            motionVectorGenerationMode = _trailRenderer.motionVectorGenerationMode,
            name = _trailRenderer.name,
            numCapVertices = _trailRenderer.numCapVertices,
            numCornerVertices = _trailRenderer.numCornerVertices,
            //probeAnchor = _trailRenderer.probeAnchor.Serialize(),
            //rayTracingMode = _trailRenderer.rayTracingMode,
            realtimeLightmapIndex = _trailRenderer.realtimeLightmapIndex,
            realtimeLightmapScaleOffset = _trailRenderer.realtimeLightmapScaleOffset.Serialize(),
            receiveShadows = _trailRenderer.receiveShadows,
            reflectionProbeUsage = _trailRenderer.reflectionProbeUsage,
            rendererPriority = _trailRenderer.rendererPriority,
            renderingLayerMask = _trailRenderer.renderingLayerMask,
            shadowBias = _trailRenderer.shadowBias,
            shadowCastingMode = _trailRenderer.shadowCastingMode,
            //sharedMaterial = _trailRenderer.sharedMaterial,
            //sharedMaterials = _trailRenderer.sharedMaterials,
            sortingLayerID = _trailRenderer.sortingLayerID,
            sortingLayerName = _trailRenderer.sortingLayerName,
            sortingOrder = _trailRenderer.sortingOrder,
            startColor = _trailRenderer.startColor.Serialize(),
            startWidth = _trailRenderer.startWidth,
            textureMode = _trailRenderer.textureMode,
            time = _trailRenderer.time,
            widthCurve = _trailRenderer.widthCurve.Serialize(),
            widthMultiplier = _trailRenderer.widthMultiplier,
        };

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static TrailRenderer Deserialize(this STrailRenderer _trailRenderer, ref GameObject _gameObject)
    {
        if (_trailRenderer.ExistsOnObject == false)
            return null;

        TrailRenderer returnVal = _gameObject.GetComponent<TrailRenderer>();
        returnVal.enabled = _trailRenderer.Enabled;

        returnVal.alignment = _trailRenderer.alignment;
        returnVal.allowOcclusionWhenDynamic = _trailRenderer.allowOcclusionWhenDynamic;
        returnVal.autodestruct = _trailRenderer.autodestruct;
        returnVal.colorGradient = _trailRenderer.colorGradient.Deserialize();
        returnVal.emitting = _trailRenderer.emitting;
        returnVal.endColor = _trailRenderer.endColor.Deserialize();
        returnVal.endWidth = _trailRenderer.endWidth;
        //returnVal.forceRenderingOff = _trailRenderer.forceRenderingOff;
        returnVal.generateLightingData = _trailRenderer.generateLightingData;
        returnVal.hideFlags = _trailRenderer.hideFlags;
        returnVal.lightmapIndex = _trailRenderer.lightmapIndex;
        returnVal.lightmapScaleOffset = _trailRenderer.lightmapScaleOffset.Deserialize();
        returnVal.lightProbeUsage = _trailRenderer.lightProbeUsage;
        //returnVal.material = _trailRenderer.material;
        //returnVal.materials = _trailRenderer.materials;
        returnVal.minVertexDistance = _trailRenderer.minVertexDistance;
        returnVal.motionVectorGenerationMode = _trailRenderer.motionVectorGenerationMode;
        returnVal.name = _trailRenderer.name;
        returnVal.numCapVertices = _trailRenderer.numCapVertices;
        returnVal.numCornerVertices = _trailRenderer.numCornerVertices;
        //returnVal.probeAnchor = _trailRenderer.probeAnchor.Deserialize();
        //returnVal.rayTracingMode = _trailRenderer.rayTracingMode;
        returnVal.realtimeLightmapIndex = _trailRenderer.realtimeLightmapIndex;
        returnVal.realtimeLightmapScaleOffset = _trailRenderer.realtimeLightmapScaleOffset.Deserialize();
        returnVal.receiveShadows = _trailRenderer.receiveShadows;
        returnVal.reflectionProbeUsage = _trailRenderer.reflectionProbeUsage;
        returnVal.rendererPriority = _trailRenderer.rendererPriority;
        returnVal.renderingLayerMask = _trailRenderer.renderingLayerMask;
        returnVal.shadowBias = _trailRenderer.shadowBias;
        returnVal.shadowCastingMode = _trailRenderer.shadowCastingMode;
        //returnVal.sharedMaterial = _trailRenderer.sharedMaterial;
        //returnVal.sharedMaterials = _trailRenderer.sharedMaterials;
        returnVal.sortingLayerID = _trailRenderer.sortingLayerID;
        returnVal.sortingLayerName = _trailRenderer.sortingLayerName;
        returnVal.sortingOrder = _trailRenderer.sortingOrder;
        returnVal.startColor = _trailRenderer.startColor.Deserialize();
        returnVal.startWidth = _trailRenderer.startWidth;
        returnVal.textureMode = _trailRenderer.textureMode;
        returnVal.time = _trailRenderer.time;
        returnVal.widthCurve = _trailRenderer.widthCurve.Deserialize();
        returnVal.widthMultiplier = _trailRenderer.widthMultiplier;

        return returnVal;
    }
    #endregion
}