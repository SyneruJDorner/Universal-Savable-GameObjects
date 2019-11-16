using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class SSkinnedMeshRenderer
{
    public bool allowOcclusionWhenDynamic;
    public bool enabled;
    public bool forceMatrixRecalculationPerRender;
    public HideFlags hideFlags;
    public int lightmapIndex;
    public SVector4 lightmapScaleOffset = new SVector4();
    public LightProbeUsage lightProbeUsage;
    public Bounds localBounds;
    public Material material;
    public Material[] materials;
    public MotionVectorGenerationMode motionVectorGenerationMode;
    public string name;
    public STransform probeAnchor = new STransform();
    public SkinQuality quality;
    public int realtimeLightmapIndex;
    public SVector4 realtimeLightmapScaleOffset = new SVector4();
    public bool receiveShadows;
    public ReflectionProbeUsage reflectionProbeUsage;
    public int rendererPriority;
    public uint renderingLayerMask;
    public STransform rootBone = new STransform();
    public ShadowCastingMode shadowCastingMode;
    public Material sharedMaterial;
    public Material[] sharedMaterials;
    public SMesh sharedMesh = new SMesh();
    public bool skinnedMotionVectors;
    public int sortingLayerID;
    public string sortingLayerName;
    public int sortingOrder;
    public bool updateWhenOffscreen;
}

public static class SkinnedMeshRendererExtensionMethods
{
    #region Serialization
    public static SSkinnedMeshRenderer Serielize(this SkinnedMeshRenderer _skinnedMeshRenderer)
    {
        if (_skinnedMeshRenderer == null)
            return null;

        SSkinnedMeshRenderer returnVal = new SSkinnedMeshRenderer()
        {
            allowOcclusionWhenDynamic = _skinnedMeshRenderer.allowOcclusionWhenDynamic,
            enabled = _skinnedMeshRenderer.enabled,
            forceMatrixRecalculationPerRender = _skinnedMeshRenderer.forceMatrixRecalculationPerRender,
            hideFlags = _skinnedMeshRenderer.hideFlags,
            lightmapIndex = _skinnedMeshRenderer.lightmapIndex,
            lightmapScaleOffset = _skinnedMeshRenderer.lightmapScaleOffset.Serialize(),
            lightProbeUsage = _skinnedMeshRenderer.lightProbeUsage,
            localBounds = _skinnedMeshRenderer.localBounds,
            material = _skinnedMeshRenderer.material,
            materials = _skinnedMeshRenderer.materials,
            motionVectorGenerationMode = _skinnedMeshRenderer.motionVectorGenerationMode,
            name = _skinnedMeshRenderer.name,
            probeAnchor = _skinnedMeshRenderer.probeAnchor.Serialize(),
            quality = _skinnedMeshRenderer.quality,
            realtimeLightmapIndex = _skinnedMeshRenderer.realtimeLightmapIndex,
            realtimeLightmapScaleOffset = _skinnedMeshRenderer.realtimeLightmapScaleOffset.Serialize(),
            receiveShadows = _skinnedMeshRenderer.receiveShadows,
            reflectionProbeUsage = _skinnedMeshRenderer.reflectionProbeUsage,
            rendererPriority = _skinnedMeshRenderer.rendererPriority,
            renderingLayerMask = _skinnedMeshRenderer.renderingLayerMask,
            rootBone = _skinnedMeshRenderer.rootBone.Serialize(),
            shadowCastingMode = _skinnedMeshRenderer.shadowCastingMode,
            sharedMaterial = _skinnedMeshRenderer.sharedMaterial,
            sharedMaterials = _skinnedMeshRenderer.sharedMaterials,
            sharedMesh = _skinnedMeshRenderer.sharedMesh.Serialize(),
            skinnedMotionVectors = _skinnedMeshRenderer.skinnedMotionVectors,
            sortingLayerID = _skinnedMeshRenderer.sortingLayerID,
            sortingLayerName = _skinnedMeshRenderer.sortingLayerName,
            sortingOrder = _skinnedMeshRenderer.sortingOrder,
            updateWhenOffscreen = _skinnedMeshRenderer.updateWhenOffscreen
        };
        return returnVal;
    }

    public static SSkinnedMeshRenderer[] Serielize(this SkinnedMeshRenderer[] _skinnedMeshRenderer)
    {
        if (_skinnedMeshRenderer == null)
            return null;

        List<SSkinnedMeshRenderer> returnVal = new List<SSkinnedMeshRenderer>();

        for (int i = 0; i < _skinnedMeshRenderer.Length; i++)
        {
            returnVal.Add(new SSkinnedMeshRenderer()
            {
                allowOcclusionWhenDynamic = _skinnedMeshRenderer[i].allowOcclusionWhenDynamic,
                enabled = _skinnedMeshRenderer[i].enabled,
                forceMatrixRecalculationPerRender = _skinnedMeshRenderer[i].forceMatrixRecalculationPerRender,
                hideFlags = _skinnedMeshRenderer[i].hideFlags,
                lightmapIndex = _skinnedMeshRenderer[i].lightmapIndex,
                lightmapScaleOffset = _skinnedMeshRenderer[i].lightmapScaleOffset.Serialize(),
                lightProbeUsage = _skinnedMeshRenderer[i].lightProbeUsage,
                localBounds = _skinnedMeshRenderer[i].localBounds,
                material = _skinnedMeshRenderer[i].material,
                materials = _skinnedMeshRenderer[i].materials,
                motionVectorGenerationMode = _skinnedMeshRenderer[i].motionVectorGenerationMode,
                name = _skinnedMeshRenderer[i].name,
                probeAnchor = _skinnedMeshRenderer[i].probeAnchor.Serialize(),
                quality = _skinnedMeshRenderer[i].quality,
                realtimeLightmapIndex = _skinnedMeshRenderer[i].realtimeLightmapIndex,
                realtimeLightmapScaleOffset = _skinnedMeshRenderer[i].realtimeLightmapScaleOffset.Serialize(),
                receiveShadows = _skinnedMeshRenderer[i].receiveShadows,
                reflectionProbeUsage = _skinnedMeshRenderer[i].reflectionProbeUsage,
                rendererPriority = _skinnedMeshRenderer[i].rendererPriority,
                renderingLayerMask = _skinnedMeshRenderer[i].renderingLayerMask,
                rootBone = _skinnedMeshRenderer[i].rootBone.Serialize(),
                shadowCastingMode = _skinnedMeshRenderer[i].shadowCastingMode,
                sharedMaterial = _skinnedMeshRenderer[i].sharedMaterial,
                sharedMaterials = _skinnedMeshRenderer[i].sharedMaterials,
                sharedMesh = _skinnedMeshRenderer[i].sharedMesh.Serialize(),
                skinnedMotionVectors = _skinnedMeshRenderer[i].skinnedMotionVectors,
                sortingLayerID = _skinnedMeshRenderer[i].sortingLayerID,
                sortingLayerName = _skinnedMeshRenderer[i].sortingLayerName,
                sortingOrder = _skinnedMeshRenderer[i].sortingOrder,
                updateWhenOffscreen = _skinnedMeshRenderer[i].updateWhenOffscreen
            });
        }
        
        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static SkinnedMeshRenderer Deserialize(this SSkinnedMeshRenderer _skinnedMeshRenderer)
    {
        if (_skinnedMeshRenderer == null)
            return null;

        SkinnedMeshRenderer returnVal = new SkinnedMeshRenderer()
        {
            allowOcclusionWhenDynamic = _skinnedMeshRenderer.allowOcclusionWhenDynamic,
            enabled = _skinnedMeshRenderer.enabled,
            forceMatrixRecalculationPerRender = _skinnedMeshRenderer.forceMatrixRecalculationPerRender,
            hideFlags = _skinnedMeshRenderer.hideFlags,
            lightmapIndex = _skinnedMeshRenderer.lightmapIndex,
            lightmapScaleOffset = _skinnedMeshRenderer.lightmapScaleOffset.Deserialize(),
            lightProbeUsage = _skinnedMeshRenderer.lightProbeUsage,
            localBounds = _skinnedMeshRenderer.localBounds,
            material = _skinnedMeshRenderer.material,
            materials = _skinnedMeshRenderer.materials,
            motionVectorGenerationMode = _skinnedMeshRenderer.motionVectorGenerationMode,
            name = _skinnedMeshRenderer.name,
            probeAnchor = _skinnedMeshRenderer.probeAnchor.Deserialize(),
            quality = _skinnedMeshRenderer.quality,
            realtimeLightmapIndex = _skinnedMeshRenderer.realtimeLightmapIndex,
            realtimeLightmapScaleOffset = _skinnedMeshRenderer.realtimeLightmapScaleOffset.Deserialize(),
            receiveShadows = _skinnedMeshRenderer.receiveShadows,
            reflectionProbeUsage = _skinnedMeshRenderer.reflectionProbeUsage,
            rendererPriority = _skinnedMeshRenderer.rendererPriority,
            renderingLayerMask = _skinnedMeshRenderer.renderingLayerMask,
            rootBone = _skinnedMeshRenderer.rootBone.Deserialize(),
            shadowCastingMode = _skinnedMeshRenderer.shadowCastingMode,
            sharedMaterial = _skinnedMeshRenderer.sharedMaterial,
            sharedMaterials = _skinnedMeshRenderer.sharedMaterials,
            sharedMesh = _skinnedMeshRenderer.sharedMesh.Deserialize(),
            skinnedMotionVectors = _skinnedMeshRenderer.skinnedMotionVectors,
            sortingLayerID = _skinnedMeshRenderer.sortingLayerID,
            sortingLayerName = _skinnedMeshRenderer.sortingLayerName,
            sortingOrder = _skinnedMeshRenderer.sortingOrder,
            updateWhenOffscreen = _skinnedMeshRenderer.updateWhenOffscreen
        };

        return returnVal;
    }

    public static SkinnedMeshRenderer[] Deserialize(this SSkinnedMeshRenderer[] _skinnedMeshRenderer)
    {
        if (_skinnedMeshRenderer == null)
            return null;

        List<SkinnedMeshRenderer> returnVal = new List<SkinnedMeshRenderer>();

        for (int i = 0; i < _skinnedMeshRenderer.Length; i++)
        {
            returnVal.Add(new SkinnedMeshRenderer()
            {
                allowOcclusionWhenDynamic = _skinnedMeshRenderer[i].allowOcclusionWhenDynamic,
                enabled = _skinnedMeshRenderer[i].enabled,
                forceMatrixRecalculationPerRender = _skinnedMeshRenderer[i].forceMatrixRecalculationPerRender,
                hideFlags = _skinnedMeshRenderer[i].hideFlags,
                lightmapIndex = _skinnedMeshRenderer[i].lightmapIndex,
                lightmapScaleOffset = _skinnedMeshRenderer[i].lightmapScaleOffset.Deserialize(),
                lightProbeUsage = _skinnedMeshRenderer[i].lightProbeUsage,
                localBounds = _skinnedMeshRenderer[i].localBounds,
                material = _skinnedMeshRenderer[i].material,
                materials = _skinnedMeshRenderer[i].materials,
                motionVectorGenerationMode = _skinnedMeshRenderer[i].motionVectorGenerationMode,
                name = _skinnedMeshRenderer[i].name,
                probeAnchor = _skinnedMeshRenderer[i].probeAnchor.Deserialize(),
                quality = _skinnedMeshRenderer[i].quality,
                realtimeLightmapIndex = _skinnedMeshRenderer[i].realtimeLightmapIndex,
                realtimeLightmapScaleOffset = _skinnedMeshRenderer[i].realtimeLightmapScaleOffset.Deserialize(),
                receiveShadows = _skinnedMeshRenderer[i].receiveShadows,
                reflectionProbeUsage = _skinnedMeshRenderer[i].reflectionProbeUsage,
                rendererPriority = _skinnedMeshRenderer[i].rendererPriority,
                renderingLayerMask = _skinnedMeshRenderer[i].renderingLayerMask,
                rootBone = _skinnedMeshRenderer[i].rootBone.Deserialize(),
                shadowCastingMode = _skinnedMeshRenderer[i].shadowCastingMode,
                sharedMaterial = _skinnedMeshRenderer[i].sharedMaterial,
                sharedMaterials = _skinnedMeshRenderer[i].sharedMaterials,
                sharedMesh = _skinnedMeshRenderer[i].sharedMesh.Deserialize(),
                skinnedMotionVectors = _skinnedMeshRenderer[i].skinnedMotionVectors,
                sortingLayerID = _skinnedMeshRenderer[i].sortingLayerID,
                sortingLayerName = _skinnedMeshRenderer[i].sortingLayerName,
                sortingOrder = _skinnedMeshRenderer[i].sortingOrder,
                updateWhenOffscreen = _skinnedMeshRenderer[i].updateWhenOffscreen
            });
        }

        return returnVal.ToArray();
    }
    #endregion
}