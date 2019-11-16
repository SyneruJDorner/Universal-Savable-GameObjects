using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class SMeshRenderer
{
    public SMesh additionalVertexStreams;
    public bool allowOcclusionWhenDynamic;
    public bool enabled;
    public HideFlags hideFlags;
    public int lightmapIndex;
    public SVector4 lightmapScaleOffset = new SVector4();
    public LightProbeUsage lightProbeUsage;
    public Material material;
    public Material[] materials;
    public MotionVectorGenerationMode motionVectorGenerationMode;
    public string name;
    public STransform probeAnchor = new STransform();
    public int realtimeLightmapIndex;
    public SVector4 realtimeLightmapScaleOffset = new SVector4();
    public ReceiveGI receiveGI;
    public bool receiveShadows;
    public ReflectionProbeUsage reflectionProbeUsage;
    public int rendererPriority;
    public uint renderingLayerMask;
    public ShadowCastingMode shadowCastingMode;
    public Material sharedMaterial;
    public Material[] sharedMaterials;
    public int sortingLayerID;
    public string sortingLayerName;
    public int sortingOrder;
}

public static class MeshRendererExtensionMethods
{
    #region Serialization
    public static SMeshRenderer Serialize(this MeshRenderer _meshRenderer)
    {
        if (_meshRenderer == null)
            return null;

        SMeshRenderer returnVal = new SMeshRenderer()
        {
            additionalVertexStreams = _meshRenderer.additionalVertexStreams.Serialize(),
            allowOcclusionWhenDynamic = _meshRenderer.allowOcclusionWhenDynamic,
            enabled = _meshRenderer.enabled,
            hideFlags = _meshRenderer.hideFlags,
            lightmapIndex = _meshRenderer.lightmapIndex,
            lightmapScaleOffset = _meshRenderer.lightmapScaleOffset.Serialize(),
            lightProbeUsage = _meshRenderer.lightProbeUsage,
            material = _meshRenderer.material,
            materials = _meshRenderer.materials,
            motionVectorGenerationMode = _meshRenderer.motionVectorGenerationMode,
            name = _meshRenderer.name,
            probeAnchor = _meshRenderer.probeAnchor.Serialize(),
            realtimeLightmapIndex = _meshRenderer.realtimeLightmapIndex,
            realtimeLightmapScaleOffset = _meshRenderer.realtimeLightmapScaleOffset.Serialize(),
            receiveGI = _meshRenderer.receiveGI,
            receiveShadows = _meshRenderer.receiveShadows,
            reflectionProbeUsage = _meshRenderer.reflectionProbeUsage,
            rendererPriority = _meshRenderer.rendererPriority,
            renderingLayerMask = _meshRenderer.renderingLayerMask,
            shadowCastingMode = _meshRenderer.shadowCastingMode,
            sharedMaterial = _meshRenderer.sharedMaterial,
            sharedMaterials = _meshRenderer.sharedMaterials,
            sortingLayerID = _meshRenderer.sortingLayerID,
            sortingLayerName = _meshRenderer.sortingLayerName,
            sortingOrder = _meshRenderer.sortingOrder,
        };

        return returnVal;
    }

    public static SMeshRenderer[] Serialize(this MeshRenderer[] _meshRenderer)
    {
        if (_meshRenderer == null)
            return null;

        List<SMeshRenderer> returnVal = new List<SMeshRenderer>();

        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            returnVal.Add(new SMeshRenderer()
            {
                additionalVertexStreams = _meshRenderer[i].additionalVertexStreams.Serialize(),
                allowOcclusionWhenDynamic = _meshRenderer[i].allowOcclusionWhenDynamic,
                enabled = _meshRenderer[i].enabled,
                hideFlags = _meshRenderer[i].hideFlags,
                lightmapIndex = _meshRenderer[i].lightmapIndex,
                lightmapScaleOffset = _meshRenderer[i].lightmapScaleOffset.Serialize(),
                lightProbeUsage = _meshRenderer[i].lightProbeUsage,
                material = _meshRenderer[i].material,
                materials = _meshRenderer[i].materials,
                motionVectorGenerationMode = _meshRenderer[i].motionVectorGenerationMode,
                name = _meshRenderer[i].name,
                probeAnchor = _meshRenderer[i].probeAnchor.Serialize(),
                realtimeLightmapIndex = _meshRenderer[i].realtimeLightmapIndex,
                realtimeLightmapScaleOffset = _meshRenderer[i].realtimeLightmapScaleOffset.Serialize(),
                receiveGI = _meshRenderer[i].receiveGI,
                receiveShadows = _meshRenderer[i].receiveShadows,
                reflectionProbeUsage = _meshRenderer[i].reflectionProbeUsage,
                rendererPriority = _meshRenderer[i].rendererPriority,
                renderingLayerMask = _meshRenderer[i].renderingLayerMask,
                shadowCastingMode = _meshRenderer[i].shadowCastingMode,
                sharedMaterial = _meshRenderer[i].sharedMaterial,
                sharedMaterials = _meshRenderer[i].sharedMaterials,
                sortingLayerID = _meshRenderer[i].sortingLayerID,
                sortingLayerName = _meshRenderer[i].sortingLayerName,
                sortingOrder = _meshRenderer[i].sortingOrder,
            });
        }

        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static MeshRenderer Deserialize(this SMeshRenderer _meshRenderer)
    {
        if (_meshRenderer == null)
            return null;

        MeshRenderer returnVal = new MeshRenderer()
        {
            additionalVertexStreams = _meshRenderer.additionalVertexStreams.Deserialize(),
            allowOcclusionWhenDynamic = _meshRenderer.allowOcclusionWhenDynamic,
            enabled = _meshRenderer.enabled,
            hideFlags = _meshRenderer.hideFlags,
            lightmapIndex = _meshRenderer.lightmapIndex,
            lightmapScaleOffset = _meshRenderer.lightmapScaleOffset.Deserialize(),
            lightProbeUsage = _meshRenderer.lightProbeUsage,
            material = _meshRenderer.material,
            materials = _meshRenderer.materials,
            motionVectorGenerationMode = _meshRenderer.motionVectorGenerationMode,
            name = _meshRenderer.name,
            probeAnchor = _meshRenderer.probeAnchor.Deserialize(),
            realtimeLightmapIndex = _meshRenderer.realtimeLightmapIndex,
            realtimeLightmapScaleOffset = _meshRenderer.realtimeLightmapScaleOffset.Deserialize(),
            receiveGI = _meshRenderer.receiveGI,
            receiveShadows = _meshRenderer.receiveShadows,
            reflectionProbeUsage = _meshRenderer.reflectionProbeUsage,
            rendererPriority = _meshRenderer.rendererPriority,
            renderingLayerMask = _meshRenderer.renderingLayerMask,
            shadowCastingMode = _meshRenderer.shadowCastingMode,
            sharedMaterial = _meshRenderer.sharedMaterial,
            sharedMaterials = _meshRenderer.sharedMaterials,
            sortingLayerID = _meshRenderer.sortingLayerID,
            sortingLayerName = _meshRenderer.sortingLayerName,
            sortingOrder = _meshRenderer.sortingOrder,
        };

        

        return returnVal;
    }

    public static MeshRenderer[] Deserialize(this SMeshRenderer[] _meshRenderer)
    {
        if (_meshRenderer == null)
            return null;

        List<MeshRenderer> returnVal = new List<MeshRenderer>();

        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            returnVal.Add(new MeshRenderer()
            {
                additionalVertexStreams = _meshRenderer[i].additionalVertexStreams.Deserialize(),
                allowOcclusionWhenDynamic = _meshRenderer[i].allowOcclusionWhenDynamic,
                enabled = _meshRenderer[i].enabled,
                hideFlags = _meshRenderer[i].hideFlags,
                lightmapIndex = _meshRenderer[i].lightmapIndex,
                lightmapScaleOffset = _meshRenderer[i].lightmapScaleOffset.Deserialize(),
                lightProbeUsage = _meshRenderer[i].lightProbeUsage,
                material = _meshRenderer[i].material,
                materials = _meshRenderer[i].materials,
                motionVectorGenerationMode = _meshRenderer[i].motionVectorGenerationMode,
                name = _meshRenderer[i].name,
                probeAnchor = _meshRenderer[i].probeAnchor.Deserialize(),
                realtimeLightmapIndex = _meshRenderer[i].realtimeLightmapIndex,
                realtimeLightmapScaleOffset = _meshRenderer[i].realtimeLightmapScaleOffset.Deserialize(),
                receiveGI = _meshRenderer[i].receiveGI,
                receiveShadows = _meshRenderer[i].receiveShadows,
                reflectionProbeUsage = _meshRenderer[i].reflectionProbeUsage,
                rendererPriority = _meshRenderer[i].rendererPriority,
                renderingLayerMask = _meshRenderer[i].renderingLayerMask,
                shadowCastingMode = _meshRenderer[i].shadowCastingMode,
                sharedMaterial = _meshRenderer[i].sharedMaterial,
                sharedMaterials = _meshRenderer[i].sharedMaterials,
                sortingLayerID = _meshRenderer[i].sortingLayerID,
                sortingLayerName = _meshRenderer[i].sortingLayerName,
                sortingOrder = _meshRenderer[i].sortingOrder,
            });
        }

        return returnVal.ToArray();
    }
    #endregion
}