using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

#region Particle System
[System.Serializable]
public class SParticleSystem
{
    #region variables
    public bool ExistsOnObject = false;

    [System.Serializable]
    public class P_MainModule
    {
        public ParticleSystemCullingMode cullingMode;
        public STransform customSimulationSpace = new STransform();
        public float duration;
        public ParticleSystemEmitterVelocityMode emitterVelocityMode;
        public float flipRotation;
        public SMinMaxCurve gravityModifier = new SMinMaxCurve();
        public float gravityModifierMultiplier;
        public bool loop;
        public int maxParticles;
        public bool playOnAwake;
        public bool prewarm;
        public SVector2 ringBufferLoopRange = new SVector2();
        public ParticleSystemRingBufferMode ringBufferMode;
        public ParticleSystemScalingMode scalingMode;
        public ParticleSystemSimulationSpace simulationSpace;
        public float simulationSpeed;
        public SMinMaxGradient startColor = new SMinMaxGradient();
        public SMinMaxCurve startDelay = new SMinMaxCurve();
        public float startDelayMultiplier;
        public SMinMaxCurve startLifetime = new SMinMaxCurve();
        public float startLifetimeMultiplier;
        public SMinMaxCurve startRotation = new SMinMaxCurve();
        public bool startRotation3D;
        public float startRotationMultiplier;
        public SMinMaxCurve startRotationX = new SMinMaxCurve();
        public float startRotationXMultiplier;
        public SMinMaxCurve startRotationY = new SMinMaxCurve();
        public float startRotationYMultiplier;
        public SMinMaxCurve startRotationZ = new SMinMaxCurve();
        public float startRotationZMultiplier;
        public SMinMaxCurve startSize = new SMinMaxCurve();
        public bool startSize3D;
        public float startSizeMultiplier;
        public SMinMaxCurve startSizeX = new SMinMaxCurve();
        public float startSizeXMultiplier;
        public SMinMaxCurve startSizeY = new SMinMaxCurve();
        public float startSizeYMultiplier;
        public SMinMaxCurve startSizeZ = new SMinMaxCurve();
        public float startSizeZMultiplier;
        public SMinMaxCurve startSpeed = new SMinMaxCurve();
        public float startSpeedMultiplier;
        public ParticleSystemStopAction stopAction;
        public bool useUnscaledTime;
    }

    [System.Serializable]
    public class P_EmissionModule
    {
        public int burstCount;
        public bool enabled;
        public SMinMaxCurve rateOverDistance = new SMinMaxCurve();
        public float rateOverDistanceMultiplier;
        public SMinMaxCurve rateOverTime = new SMinMaxCurve();
        public float rateOverTimeMultiplier;
        //public List<ParticleSystem.Burst> bursts = new List<ParticleSystem.Burst>();

            /*
        public void SerializeBursts(ParticleSystem.EmissionModule emissionModule)
        {
            for (int i = 0; i < emissionModule.burstCount; i++)
            {
                bursts.Add(emissionModule.GetBurst(i));
            }
        }

        public void DeserializeBursts(ref ParticleSystem.EmissionModule emissionModule)
        {
            for (int i = 0; i < burstCount; i++)
            {
                emissionModule.SetBurst(i, bursts[i]);
            }
        }
        */
    }

    [System.Serializable]
    public class P_ShapeModule
    {
        public bool alignToDirection;
        public float angle;
        public float arc;
        public ParticleSystemShapeMultiModeValue arcMode;
        public SMinMaxCurve arcSpeed = new SMinMaxCurve();
        public float arcSpeedMultiplier;
        public float arcSpread;
        public SVector3 box = new SVector3();
        public SVector3 boxThickness = new SVector3();
        public float donutRadius;
        public bool enabled;
        public float length;
        public SMesh mesh = new SMesh();
        public int meshMaterialIndex;
        public SMeshRenderer meshRenderer = new SMeshRenderer();
        public ParticleSystemMeshShapeType meshShapeType;
        public ParticleSystemShapeMultiModeValue meshSpawnMode;
        public SMinMaxCurve meshSpawnSpeed = new SMinMaxCurve();
        public float meshSpawnSpeedMultiplier;
        public float meshSpawnSpread;
        public float normalOffset;
        public SVector3 position = new SVector3();
        public float radius;
        public ParticleSystemShapeMultiModeValue radiusMode;
        public SMinMaxCurve radiusSpeed = new SMinMaxCurve();
        public float radiusSpeedMultiplier;
        public float radiusSpread;
        public float radiusThickness;
        public float randomDirectionAmount;
        public float randomPositionAmount;
        public SVector3 rotation = new SVector3();
        public SVector3 scale = new SVector3();
        public ParticleSystemShapeType shapeType;
        public SSkinnedMeshRenderer skinnedMeshRenderer = new SSkinnedMeshRenderer();
        public float sphericalDirectionAmount;
        //public Sprite sprite;
        //public SpriteRenderer spriteRenderer;
        //public Texture2D texture;
        public bool textureAlphaAffectsParticles;
        public bool textureBilinearFiltering;
        public ParticleSystemShapeTextureChannel textureClipChannel;
        public float textureClipThreshold;
        public bool textureColorAffectsParticles;
        public int textureUVChannel;
        public bool useMeshColors;
        public bool useMeshMaterialIndex;
    }

    [System.Serializable]
    public class P_VelocityOverLifetimeModule
    {
        public bool enabled;
        public SMinMaxCurve orbitalOffsetX = new SMinMaxCurve();
        public float orbitalOffsetXMultiplier;
        public SMinMaxCurve orbitalOffsetY = new SMinMaxCurve();
        public float orbitalOffsetYMultiplier;
        public SMinMaxCurve orbitalOffsetZ = new SMinMaxCurve();
        public float orbitalOffsetZMultiplier;
        public SMinMaxCurve orbitalX = new SMinMaxCurve();
        public float orbitalXMultiplier;
        public SMinMaxCurve orbitalY = new SMinMaxCurve();
        public float orbitalYMultiplier;
        public SMinMaxCurve orbitalZ = new SMinMaxCurve();
        public float orbitalZMultiplier;
        public SMinMaxCurve radial = new SMinMaxCurve();
        public float radialMultiplier;
        public ParticleSystemSimulationSpace space;
        public SMinMaxCurve speedModifier = new SMinMaxCurve();
        public float speedModifierMultiplier;
        public SMinMaxCurve x = new SMinMaxCurve();
        public float xMultiplier;
        public SMinMaxCurve y = new SMinMaxCurve();
        public float yMultiplier;
        public SMinMaxCurve z = new SMinMaxCurve();
        public float zMultiplier;
    }

    [System.Serializable]
    public class P_NoiseModule
    {
        public bool damping;
        public bool enabled;
        public float frequency;
        public int octaveCount;
        public float octaveMultiplier;
        public float octaveScale;
        public SMinMaxCurve positionAmount = new SMinMaxCurve();
        public ParticleSystemNoiseQuality quality;
        public SMinMaxCurve remap = new SMinMaxCurve();
        public bool remapEnabled;
        public float remapMultiplier;
        public SMinMaxCurve remapX = new SMinMaxCurve();
        public float remapXMultiplier;
        public SMinMaxCurve remapY = new SMinMaxCurve();
        public float remapYMultiplier;
        public SMinMaxCurve remapZ = new SMinMaxCurve();
        public float remapZMultiplier;
        public SMinMaxCurve rotationAmount = new SMinMaxCurve();
        public SMinMaxCurve scrollSpeed = new SMinMaxCurve();
        public float scrollSpeedMultiplier;
        public bool separateAxes;
        public SMinMaxCurve sizeAmount = new SMinMaxCurve();
        public SMinMaxCurve strength = new SMinMaxCurve();
        public float strengthMultiplier;
        public SMinMaxCurve strengthX = new SMinMaxCurve();
        public float strengthXMultiplier;
        public SMinMaxCurve strengthY = new SMinMaxCurve();
        public float strengthYMultiplier;
        public SMinMaxCurve strengthZ = new SMinMaxCurve();
        public float strengthZMultiplier;
    }

    [System.Serializable]
    public class P_LimitVelocityOverLifetimeModule
    {
        public float dampen;
        public SMinMaxCurve drag = new SMinMaxCurve();
        public float dragMultiplier;
        public bool enabled;
        public SMinMaxCurve limit = new SMinMaxCurve();
        public float limitMultiplier;
        public SMinMaxCurve limitX = new SMinMaxCurve();
        public float limitXMultiplier;
        public SMinMaxCurve limitY = new SMinMaxCurve();
        public float limitYMultiplier;
        public SMinMaxCurve limitZ = new SMinMaxCurve();
        public float limitZMultiplier;
        public bool multiplyDragByParticleSize;
        public bool multiplyDragByParticleVelocity;
        public bool separateAxes;
        public ParticleSystemSimulationSpace space;
    }

    [System.Serializable]
    public class P_InheritVelocityModule
    {
        public SMinMaxCurve curve = new SMinMaxCurve();
        public float curveMultiplier;
        public bool enabled;
        public ParticleSystemInheritVelocityMode mode;
    }

    [System.Serializable]
    public class P_ForceOverLifetimeModule
    {
        public bool enabled;
        public bool randomized;
        public ParticleSystemSimulationSpace space;
        public SMinMaxCurve x = new SMinMaxCurve();
        public float xMultiplier;
        public SMinMaxCurve y = new SMinMaxCurve();
        public float yMultiplier;
        public SMinMaxCurve z = new SMinMaxCurve();
        public float zMultiplier;
    }

    [System.Serializable]
    public class P_ColourOverLifetimeModule
    {
        public SMinMaxGradient color = new SMinMaxGradient();
        public bool enabled;
    }

    [System.Serializable]
    public class P_ColorBySpeedModule
    {
        public SMinMaxGradient color = new SMinMaxGradient();
        public bool enabled;
        public SVector2 range = new SVector2();
    }

    [System.Serializable]
    public class P_SizeOverLifetime
    {
        public bool enabled;
        public bool separateAxes;
        public SMinMaxCurve size = new SMinMaxCurve();
        public float sizeMultiplier;
        public SMinMaxCurve x = new SMinMaxCurve();
        public float xMultiplier;
        public SMinMaxCurve y = new SMinMaxCurve();
        public float yMultiplier;
        public SMinMaxCurve z = new SMinMaxCurve();
        public float zMultiplier;
    }

    [System.Serializable]
    public class P_SizeBySpeedModule
    {
        public bool enabled;
        public SVector2 range = new SVector2();
        public bool separateAxes;
        public SMinMaxCurve size = new SMinMaxCurve();
        public float sizeMultiplier;
        public SMinMaxCurve x = new SMinMaxCurve();
        public float xMultiplier;
        public SMinMaxCurve y = new SMinMaxCurve();
        public float yMultiplier;
        public SMinMaxCurve z = new SMinMaxCurve();
        public float zMultiplier;
    }

    [System.Serializable]
    public class P_RotationOverLifetimeModule
    {
        public bool enabled;
        public bool separateAxes;
        public SMinMaxCurve x = new SMinMaxCurve();
        public float xMultiplier;
        public SMinMaxCurve y = new SMinMaxCurve();
        public float yMultiplier;
        public SMinMaxCurve z = new SMinMaxCurve();
        public float zMultiplier;
    }

    [System.Serializable]
    public class P_RotationBySpeedModule
    {
        public bool enabled;
        public SVector2 range = new SVector2();
        public SMinMaxCurve x = new SMinMaxCurve();
        public float xMultiplier;
        public SMinMaxCurve y = new SMinMaxCurve();
        public float yMultiplier;
        public SMinMaxCurve z = new SMinMaxCurve();
        public float zMultiplier;
    }

    [System.Serializable]
    public class P_ExternalForcesModule
    {
        public bool enabled;
        public int influenceCount;
        public ParticleSystemGameObjectFilter influenceFilter;
        public int influenceMask;
        public float multiplier;
        public SMinMaxCurve multiplierCurve = new SMinMaxCurve();
    }

    [System.Serializable]
    public class P_CollisionModule
    {
        public SMinMaxCurve bounce = new SMinMaxCurve();
        public float bounceMultiplier;
        public float colliderForce;
        public int collidesWith;
        public SMinMaxCurve dampen = new SMinMaxCurve();
        public float dampenMultiplier;
        public bool enabled;
        public bool enableDynamicColliders;
        public SMinMaxCurve lifetimeLoss = new SMinMaxCurve();
        public float lifetimeLossMultiplier;
        public int maxCollisionShapes;
        public float maxKillSpeed;
        public int maxPlaneCount;
        public float minKillSpeed;
        public ParticleSystemCollisionMode mode;
        public bool multiplyColliderForceByCollisionAngle;
        public bool multiplyColliderForceByParticleSize;
        public bool multiplyColliderForceByParticleSpeed;
        public ParticleSystemCollisionQuality quality;
        public float radiusScale;
        public bool sendCollisionMessages;
        public ParticleSystemCollisionType type;
        public float voxelSize;
    }

    [System.Serializable]
    public class P_TriggerModule
    {
        public bool enabled;
        public ParticleSystemOverlapAction enter;
        public ParticleSystemOverlapAction exit;
        public ParticleSystemOverlapAction inside;
        public int maxColliderCount;
        public ParticleSystemOverlapAction outside;
        public float radiusScale;
    }

    [System.Serializable]
    public class P_SubEmittersModule
    {
        public bool enabled;
        public int subEmittersCount;
        /*
        public List<SParticleSystem> subEmmiters = new List<SParticleSystem>();

        public void SerializeSubEmitters(ParticleSystem.SubEmittersModule subEmmiter)
        {
            for (int i = 0; i < subEmmiter.subEmittersCount; i++)
            {
                subEmmiters.Add(new SParticleSystem().Serielize(subEmmiter.GetSubEmitterSystem(i)));
            }
        }

        public void DeserializeSubEmitters(ref ParticleSystem.SubEmittersModule subEmmiter)
        {
            for (int i = 0; i < subEmittersCount; i++)
            {
                subEmmiter.SetSubEmitterSystem(i, subEmmiters[i].Deserielize());
            }
        }
        */
    }

    [System.Serializable]
    public class P_TextureSheetAnimationModule
    {
        public ParticleSystemAnimationType animation;
        public int cycleCount;
        public bool enabled;
        public float fps;
        public SMinMaxCurve frameOverTime = new SMinMaxCurve();
        public float frameOverTimeMultiplier;
        public ParticleSystemAnimationMode mode;
        public int numTilesX;
        public int numTilesY;
        public int rowIndex;
        public ParticleSystemAnimationRowMode rowMode;
        public SVector2 speedRange = new SVector2();
        public int spriteCount;
        public SMinMaxCurve startFrame = new SMinMaxCurve();
        public float startFrameMultiplier;
        public ParticleSystemAnimationTimeMode timeMode;
        public UVChannelFlags uvChannelMask;
    }

    [System.Serializable]
    public class P_LightsModule
    {
        public bool alphaAffectsIntensity;
        public bool enabled;
        public SMinMaxCurve intensity = new SMinMaxCurve();
        public float intensityMultiplier;
        //public Light light;
        public int maxLights;
        public SMinMaxCurve range = new SMinMaxCurve();
        public float rangeMultiplier;
        public float ratio;
        public bool sizeAffectsRange;
        public bool useParticleColor;
        public bool useRandomDistribution;
    }

    [System.Serializable]
    public class P_TrailsModule
    {
        public bool attachRibbonsToTransform;
        public SMinMaxGradient colorOverLifetime = new SMinMaxGradient();
        public SMinMaxGradient colorOverTrail = new SMinMaxGradient();
        public bool dieWithParticles;
        public bool enabled;
        public bool generateLightingData;
        public bool inheritParticleColor;
        public SMinMaxCurve lifetime = new SMinMaxCurve();
        public float lifetimeMultiplier;
        public float minVertexDistance;
        public ParticleSystemTrailMode mode;
        public float ratio;
        public int ribbonCount;
        public float shadowBias;
        public bool sizeAffectsLifetime;
        public bool sizeAffectsWidth;
        public bool splitSubEmitterRibbons;
        public ParticleSystemTrailTextureMode textureMode;
        public SMinMaxCurve widthOverTrail = new SMinMaxCurve();
        public float widthOverTrailMultiplier;
        public bool worldSpace;
    }

    [System.Serializable]
    public class P_CustomDataModule
    {
        public bool enabled;
    }

    //public SParticleSystem returnVal = new SParticleSystem();
    public P_MainModule pMain = new P_MainModule();
    public P_EmissionModule pEmission = new P_EmissionModule();
    public P_ShapeModule pShapeModule = new P_ShapeModule();
    public P_VelocityOverLifetimeModule pVelocityOverLifetimeModule = new P_VelocityOverLifetimeModule();
    public P_NoiseModule pNoiseModule = new P_NoiseModule();
    public P_LimitVelocityOverLifetimeModule pLimitVelocityOverLifetimeModule = new P_LimitVelocityOverLifetimeModule();
    public P_InheritVelocityModule pInheritVelocityModule = new P_InheritVelocityModule();
    public P_ForceOverLifetimeModule pForceOverLifetimeModule = new P_ForceOverLifetimeModule();
    public P_ColourOverLifetimeModule pColourOverLifetimeModule = new P_ColourOverLifetimeModule();
    public P_ColorBySpeedModule pColorBySpeedModule = new P_ColorBySpeedModule();
    public P_SizeOverLifetime pSizeOverLifetime = new P_SizeOverLifetime();
    public P_SizeBySpeedModule pSizeBySpeedModule = new P_SizeBySpeedModule();
    public P_RotationOverLifetimeModule pRotationOverLifetimeModule = new P_RotationOverLifetimeModule();
    public P_RotationBySpeedModule pRotationBySpeedModule = new P_RotationBySpeedModule();
    public P_ExternalForcesModule pExternalForcesModule = new P_ExternalForcesModule();
    public P_CollisionModule pCollisionModule = new P_CollisionModule();
    public P_TriggerModule pTriggerModule = new P_TriggerModule();
    public P_SubEmittersModule pSubEmittersModule = new P_SubEmittersModule();
    public P_TextureSheetAnimationModule pTextureSheetAnimationModule = new P_TextureSheetAnimationModule();
    public P_LightsModule pLightsModule = new P_LightsModule();
    public P_TrailsModule pTrailsModule = new P_TrailsModule();
    public P_CustomDataModule pCustomDataModule = new P_CustomDataModule();
    #endregion
}
#endregion

public static class ParticleSystemExtensionMethods
{
    #region Serialize
    public static SParticleSystem Serialize(this ParticleSystem _particleSystem)
    {
        if (_particleSystem == null)
            return null;

        SParticleSystem returnVal = new SParticleSystem();
        returnVal.ExistsOnObject = (_particleSystem == null) ? false : true;

        #region Main Module
        returnVal.pMain = new SParticleSystem.P_MainModule()
        {
            cullingMode = _particleSystem.main.cullingMode,
            customSimulationSpace = _particleSystem.main.customSimulationSpace.Serialize(),
            duration = _particleSystem.main.duration,
            emitterVelocityMode = _particleSystem.main.emitterVelocityMode,
            flipRotation = _particleSystem.main.flipRotation,
            gravityModifier = _particleSystem.main.gravityModifier.Serialize(),
            gravityModifierMultiplier = _particleSystem.main.gravityModifierMultiplier,
            loop = _particleSystem.main.loop,
            maxParticles = _particleSystem.main.maxParticles,
            playOnAwake = _particleSystem.main.playOnAwake,
            prewarm = _particleSystem.main.prewarm,
            ringBufferLoopRange = _particleSystem.main.ringBufferLoopRange.Serialize(),
            ringBufferMode = _particleSystem.main.ringBufferMode,
            scalingMode = _particleSystem.main.scalingMode,
            simulationSpace = _particleSystem.main.simulationSpace,
            simulationSpeed = _particleSystem.main.simulationSpeed,
            startColor = _particleSystem.main.startColor.Serialize(),
            startDelay = _particleSystem.main.startDelay.Serialize(),
            startDelayMultiplier = _particleSystem.main.startDelayMultiplier,
            startLifetime = _particleSystem.main.startLifetime.Serialize(),
            startLifetimeMultiplier = _particleSystem.main.startLifetimeMultiplier,
            startRotation = _particleSystem.main.startRotation.Serialize(),
            startRotation3D = _particleSystem.main.startRotation3D,
            startRotationMultiplier = _particleSystem.main.startRotationMultiplier,
            startRotationX = _particleSystem.main.startRotationX.Serialize(),
            startRotationXMultiplier = _particleSystem.main.startRotationXMultiplier,
            startRotationY = _particleSystem.main.startRotationY.Serialize(),
            startRotationYMultiplier = _particleSystem.main.startRotationYMultiplier,
            startRotationZ = _particleSystem.main.startRotationZ.Serialize(),
            startRotationZMultiplier = _particleSystem.main.startRotationZMultiplier,
            startSize = _particleSystem.main.startSize.Serialize(),
            startSize3D = _particleSystem.main.startSize3D,
            startSizeMultiplier = _particleSystem.main.startSizeMultiplier,
            startSizeX = _particleSystem.main.startSizeX.Serialize(),
            startSizeXMultiplier = _particleSystem.main.startSizeXMultiplier,
            startSizeY = _particleSystem.main.startSizeY.Serialize(),
            startSizeYMultiplier = _particleSystem.main.startSizeYMultiplier,
            startSizeZ = _particleSystem.main.startSizeZ.Serialize(),
            startSizeZMultiplier = _particleSystem.main.startSizeZMultiplier,
            startSpeed = _particleSystem.main.startSpeed.Serialize(),
            startSpeedMultiplier = _particleSystem.main.startSpeedMultiplier,
            stopAction = _particleSystem.main.stopAction,
            useUnscaledTime = _particleSystem.main.useUnscaledTime,
        };
        #endregion

        #region Emission Module
        returnVal.pEmission = new SParticleSystem.P_EmissionModule()
        {
            burstCount = _particleSystem.emission.burstCount,
            enabled = _particleSystem.emission.enabled,
            rateOverDistance = _particleSystem.emission.rateOverDistance.Serialize(),
            rateOverDistanceMultiplier = _particleSystem.emission.rateOverDistanceMultiplier,
            rateOverTime = _particleSystem.emission.rateOverTime.Serialize(),
            rateOverTimeMultiplier = _particleSystem.emission.rateOverTimeMultiplier
            //bursts = _particleSystem.emission.GetBurst(0),
        };
        //returnVal.pEmission.SerializeBursts(_particleSystem.emission);
        #endregion

        #region Shape Module
        returnVal.pShapeModule = new SParticleSystem.P_ShapeModule()
        {
            alignToDirection = _particleSystem.shape.alignToDirection,
            angle = _particleSystem.shape.angle,
            arc = _particleSystem.shape.arc,
            arcMode = _particleSystem.shape.arcMode,
            arcSpeed = _particleSystem.shape.arcSpeed.Serialize(),
            arcSpeedMultiplier = _particleSystem.shape.arcSpeedMultiplier,
            arcSpread = _particleSystem.shape.arcSpread,
            box = _particleSystem.shape.scale.Serialize(),
            boxThickness = _particleSystem.shape.boxThickness.Serialize(),
            donutRadius = _particleSystem.shape.donutRadius,
            enabled = _particleSystem.shape.enabled,
            length = _particleSystem.shape.length,
            mesh = _particleSystem.shape.mesh.Serialize(),
            meshMaterialIndex = _particleSystem.shape.meshMaterialIndex,
            meshRenderer = _particleSystem.shape.meshRenderer.Serialize(),
            meshShapeType = _particleSystem.shape.meshShapeType,
            meshSpawnMode = _particleSystem.shape.meshSpawnMode,
            meshSpawnSpeed = _particleSystem.shape.meshSpawnSpeed.Serialize(),
            meshSpawnSpeedMultiplier = _particleSystem.shape.meshSpawnSpeedMultiplier,
            meshSpawnSpread = _particleSystem.shape.meshSpawnSpread,
            normalOffset = _particleSystem.shape.normalOffset,
            position = _particleSystem.shape.position.Serialize(),
            radius = _particleSystem.shape.radius,
            radiusMode = _particleSystem.shape.radiusMode,
            radiusSpeed = _particleSystem.shape.radiusSpeed.Serialize(),
            radiusSpeedMultiplier = _particleSystem.shape.radiusSpeedMultiplier,
            radiusSpread = _particleSystem.shape.radiusSpread,
            radiusThickness = _particleSystem.shape.radiusThickness,
            randomDirectionAmount = _particleSystem.shape.randomDirectionAmount,
            randomPositionAmount = _particleSystem.shape.randomPositionAmount,
            rotation = _particleSystem.shape.rotation.Serialize(),
            scale = _particleSystem.shape.scale.Serialize(),
            shapeType = _particleSystem.shape.shapeType,
            skinnedMeshRenderer = _particleSystem.shape.skinnedMeshRenderer.Serielize(),
            sphericalDirectionAmount = _particleSystem.shape.sphericalDirectionAmount,
            //sprite = _particleSystem.shape.sprite,
            //spriteRenderer = _particleSystem.shape.spriteRenderer,
            //texture = _particleSystem.shape.texture,
            textureAlphaAffectsParticles = _particleSystem.shape.textureAlphaAffectsParticles,
            textureBilinearFiltering = _particleSystem.shape.textureBilinearFiltering,
            textureClipChannel = _particleSystem.shape.textureClipChannel,
            textureClipThreshold = _particleSystem.shape.textureClipThreshold,
            textureColorAffectsParticles = _particleSystem.shape.textureColorAffectsParticles,
            textureUVChannel = _particleSystem.shape.textureUVChannel,
            useMeshColors = _particleSystem.shape.useMeshColors,
            useMeshMaterialIndex = _particleSystem.shape.useMeshMaterialIndex
        };
        #endregion

        #region Velocity over Lifetime Module
        returnVal.pVelocityOverLifetimeModule = new SParticleSystem.P_VelocityOverLifetimeModule()
        {
            enabled = _particleSystem.velocityOverLifetime.enabled,
            orbitalOffsetX = _particleSystem.velocityOverLifetime.orbitalOffsetX.Serialize(),
            orbitalOffsetXMultiplier = _particleSystem.velocityOverLifetime.orbitalOffsetXMultiplier,
            orbitalOffsetY = _particleSystem.velocityOverLifetime.orbitalOffsetY.Serialize(),
            orbitalOffsetYMultiplier = _particleSystem.velocityOverLifetime.orbitalOffsetYMultiplier,
            orbitalOffsetZ = _particleSystem.velocityOverLifetime.orbitalOffsetZ.Serialize(),
            orbitalOffsetZMultiplier = _particleSystem.velocityOverLifetime.orbitalOffsetZMultiplier,
            orbitalX = _particleSystem.velocityOverLifetime.orbitalX.Serialize(),
            orbitalXMultiplier = _particleSystem.velocityOverLifetime.orbitalXMultiplier,
            orbitalY = _particleSystem.velocityOverLifetime.orbitalY.Serialize(),
            orbitalYMultiplier = _particleSystem.velocityOverLifetime.orbitalYMultiplier,
            orbitalZ = _particleSystem.velocityOverLifetime.orbitalZ.Serialize(),
            orbitalZMultiplier = _particleSystem.velocityOverLifetime.orbitalZMultiplier,
            radial = _particleSystem.velocityOverLifetime.radial.Serialize(),
            radialMultiplier = _particleSystem.velocityOverLifetime.radialMultiplier,
            space = _particleSystem.velocityOverLifetime.space,
            speedModifier = _particleSystem.velocityOverLifetime.speedModifier.Serialize(),
            speedModifierMultiplier = _particleSystem.velocityOverLifetime.speedModifierMultiplier,
            x = _particleSystem.velocityOverLifetime.x.Serialize(),
            xMultiplier = _particleSystem.velocityOverLifetime.xMultiplier,
            y = _particleSystem.velocityOverLifetime.y.Serialize(),
            yMultiplier = _particleSystem.velocityOverLifetime.yMultiplier,
            z = _particleSystem.velocityOverLifetime.z.Serialize(),
            zMultiplier = _particleSystem.velocityOverLifetime.zMultiplier
        };
        #endregion

        #region Noise Module
        returnVal.pNoiseModule = new SParticleSystem.P_NoiseModule()
        {
            damping = _particleSystem.noise.damping,
            enabled = _particleSystem.noise.enabled,
            frequency = _particleSystem.noise.frequency,
            octaveCount = _particleSystem.noise.octaveCount,
            octaveMultiplier = _particleSystem.noise.octaveMultiplier,
            octaveScale = _particleSystem.noise.octaveScale,
            positionAmount = _particleSystem.noise.positionAmount.Serialize(),
            quality = _particleSystem.noise.quality,
            remap = _particleSystem.noise.remap.Serialize(),
            remapEnabled = _particleSystem.noise.remapEnabled,
            remapMultiplier = _particleSystem.noise.remapMultiplier,
            remapX = _particleSystem.noise.remapX.Serialize(),
            remapXMultiplier = _particleSystem.noise.remapXMultiplier,
            remapY = _particleSystem.noise.remapY.Serialize(),
            remapYMultiplier = _particleSystem.noise.remapYMultiplier,
            remapZ = _particleSystem.noise.remapZ.Serialize(),
            remapZMultiplier = _particleSystem.noise.remapZMultiplier,
            rotationAmount = _particleSystem.noise.rotationAmount.Serialize(),
            scrollSpeed = _particleSystem.noise.scrollSpeed.Serialize(),
            scrollSpeedMultiplier = _particleSystem.noise.scrollSpeedMultiplier,
            separateAxes = _particleSystem.noise.separateAxes,
            sizeAmount = _particleSystem.noise.sizeAmount.Serialize(),
            strength = _particleSystem.noise.strength.Serialize(),
            strengthMultiplier = _particleSystem.noise.strengthMultiplier,
            strengthX = _particleSystem.noise.strengthX.Serialize(),
            strengthXMultiplier = _particleSystem.noise.strengthXMultiplier,
            strengthY = _particleSystem.noise.strengthY.Serialize(),
            strengthYMultiplier = _particleSystem.noise.strengthYMultiplier,
            strengthZ = _particleSystem.noise.strengthZ.Serialize(),
            strengthZMultiplier = _particleSystem.noise.strengthZMultiplier
        };
        #endregion

        #region Limit Velocity OverLifetime Module
        returnVal.pLimitVelocityOverLifetimeModule = new SParticleSystem.P_LimitVelocityOverLifetimeModule()
        {
            dampen = _particleSystem.limitVelocityOverLifetime.dampen,
            drag = _particleSystem.limitVelocityOverLifetime.drag.Serialize(),
            dragMultiplier = _particleSystem.limitVelocityOverLifetime.dragMultiplier,
            enabled = _particleSystem.limitVelocityOverLifetime.enabled,
            limit = _particleSystem.limitVelocityOverLifetime.limit.Serialize(),
            limitMultiplier = _particleSystem.limitVelocityOverLifetime.limitMultiplier,
            limitX = _particleSystem.limitVelocityOverLifetime.limitX.Serialize(),
            limitXMultiplier = _particleSystem.limitVelocityOverLifetime.limitXMultiplier,
            limitY = _particleSystem.limitVelocityOverLifetime.limitY.Serialize(),
            limitYMultiplier = _particleSystem.limitVelocityOverLifetime.limitYMultiplier,
            limitZ = _particleSystem.limitVelocityOverLifetime.limitZ.Serialize(),
            limitZMultiplier = _particleSystem.limitVelocityOverLifetime.limitZMultiplier,
            multiplyDragByParticleSize = _particleSystem.limitVelocityOverLifetime.multiplyDragByParticleSize,
            multiplyDragByParticleVelocity = _particleSystem.limitVelocityOverLifetime.multiplyDragByParticleVelocity,
            separateAxes = _particleSystem.limitVelocityOverLifetime.separateAxes,
            space = _particleSystem.limitVelocityOverLifetime.space
        };
        #endregion

        #region Inherit Velocity Module
        returnVal.pInheritVelocityModule = new SParticleSystem.P_InheritVelocityModule()
        {
            curve = _particleSystem.inheritVelocity.curve.Serialize(),
            curveMultiplier = _particleSystem.inheritVelocity.curveMultiplier,
            enabled = _particleSystem.inheritVelocity.enabled,
            mode = _particleSystem.inheritVelocity.mode
        };
        #endregion

        #region Force Over Lifetime Module
        returnVal.pForceOverLifetimeModule = new SParticleSystem.P_ForceOverLifetimeModule()
        {
            enabled = _particleSystem.forceOverLifetime.enabled,
            randomized = _particleSystem.forceOverLifetime.randomized,
            space = _particleSystem.forceOverLifetime.space,
            x = _particleSystem.forceOverLifetime.x.Serialize(),
            xMultiplier = _particleSystem.forceOverLifetime.xMultiplier,
            y = _particleSystem.forceOverLifetime.y.Serialize(),
            yMultiplier = _particleSystem.forceOverLifetime.yMultiplier,
            z = _particleSystem.forceOverLifetime.z.Serialize(),
            zMultiplier = _particleSystem.forceOverLifetime.zMultiplier
        };
        #endregion

        #region Color Over Lifetime Module
        returnVal.pColourOverLifetimeModule = new SParticleSystem.P_ColourOverLifetimeModule()
        {
            color = _particleSystem.colorOverLifetime.color.Serialize(),
            enabled = _particleSystem.colorOverLifetime.enabled
        };
        #endregion

        #region Color By Speed Module
        returnVal.pColorBySpeedModule = new SParticleSystem.P_ColorBySpeedModule()
        {
            color = _particleSystem.colorBySpeed.color.Serialize(),
            enabled = _particleSystem.colorBySpeed.enabled,
            range = _particleSystem.colorBySpeed.range.Serialize()
        };
        #endregion

        #region Size Over Lifetime Module
        returnVal.pSizeOverLifetime = new SParticleSystem.P_SizeOverLifetime()
        {
            enabled = _particleSystem.sizeOverLifetime.enabled,
            separateAxes = _particleSystem.sizeOverLifetime.separateAxes,
            size = _particleSystem.sizeOverLifetime.size.Serialize(),
            sizeMultiplier = _particleSystem.sizeOverLifetime.sizeMultiplier,
            x = _particleSystem.sizeOverLifetime.x.Serialize(),
            xMultiplier = _particleSystem.sizeOverLifetime.xMultiplier,
            y = _particleSystem.sizeOverLifetime.y.Serialize(),
            yMultiplier = _particleSystem.sizeOverLifetime.yMultiplier,
            z = _particleSystem.sizeOverLifetime.z.Serialize(),
            zMultiplier = _particleSystem.sizeOverLifetime.zMultiplier
        };
        #endregion

        #region Size By Speed Module
        returnVal.pSizeBySpeedModule = new SParticleSystem.P_SizeBySpeedModule()
        {
            enabled = _particleSystem.sizeBySpeed.enabled,
            range = _particleSystem.sizeBySpeed.range.Serialize(),
            separateAxes = _particleSystem.sizeBySpeed.separateAxes,
            size = _particleSystem.sizeBySpeed.size.Serialize(),
            sizeMultiplier = _particleSystem.sizeBySpeed.sizeMultiplier,
            x = _particleSystem.sizeBySpeed.x.Serialize(),
            xMultiplier = _particleSystem.sizeBySpeed.xMultiplier,
            y = _particleSystem.sizeBySpeed.y.Serialize(),
            yMultiplier = _particleSystem.sizeBySpeed.yMultiplier,
            z = _particleSystem.sizeBySpeed.z.Serialize(),
            zMultiplier = _particleSystem.sizeBySpeed.zMultiplier
        };
        #endregion

        #region Rotation Over Lifetime Module
        returnVal.pRotationOverLifetimeModule = new SParticleSystem.P_RotationOverLifetimeModule()
        {
            enabled = _particleSystem.rotationOverLifetime.enabled,
            separateAxes = _particleSystem.rotationOverLifetime.separateAxes,
            x = _particleSystem.rotationOverLifetime.x.Serialize(),
            xMultiplier = _particleSystem.rotationOverLifetime.xMultiplier,
            y = _particleSystem.rotationOverLifetime.y.Serialize(),
            yMultiplier = _particleSystem.rotationOverLifetime.yMultiplier,
            z = _particleSystem.rotationOverLifetime.z.Serialize(),
            zMultiplier = _particleSystem.rotationOverLifetime.zMultiplier
        };
        #endregion

        #region Rotation By Speed Module
        returnVal.pRotationBySpeedModule = new SParticleSystem.P_RotationBySpeedModule()
        {
            enabled = _particleSystem.rotationBySpeed.enabled,
            range = _particleSystem.rotationBySpeed.range.Serialize(),
            x = _particleSystem.rotationBySpeed.x.Serialize(),
            xMultiplier = _particleSystem.rotationBySpeed.xMultiplier,
            y = _particleSystem.rotationBySpeed.y.Serialize(),
            yMultiplier = _particleSystem.rotationBySpeed.yMultiplier,
            z = _particleSystem.rotationBySpeed.z.Serialize(),
            zMultiplier = _particleSystem.rotationBySpeed.zMultiplier
        };
        #endregion

        #region External Forces Module
        returnVal.pExternalForcesModule = new SParticleSystem.P_ExternalForcesModule()
        {
            enabled = _particleSystem.externalForces.enabled,
            influenceCount = _particleSystem.externalForces.influenceCount,
            influenceFilter = _particleSystem.externalForces.influenceFilter,
            influenceMask = _particleSystem.externalForces.influenceMask,
            multiplier = _particleSystem.externalForces.multiplier,
            multiplierCurve = _particleSystem.externalForces.multiplierCurve.Serialize()
        };
        #endregion

        #region Collision Module
        returnVal.pCollisionModule = new SParticleSystem.P_CollisionModule()
        {
            bounce = _particleSystem.collision.bounce.Serialize(),
            bounceMultiplier = _particleSystem.collision.bounceMultiplier,
            colliderForce = _particleSystem.collision.colliderForce,
            collidesWith = _particleSystem.collision.collidesWith,
            dampen = _particleSystem.collision.dampen.Serialize(),
            dampenMultiplier = _particleSystem.collision.dampenMultiplier,
            enabled = _particleSystem.collision.enabled,
            enableDynamicColliders = _particleSystem.collision.enableDynamicColliders,
            lifetimeLoss = _particleSystem.collision.lifetimeLoss.Serialize(),
            lifetimeLossMultiplier = _particleSystem.collision.lifetimeLossMultiplier,
            maxCollisionShapes = _particleSystem.collision.maxCollisionShapes,
            maxKillSpeed = _particleSystem.collision.maxKillSpeed,
            maxPlaneCount = _particleSystem.collision.maxPlaneCount,
            minKillSpeed = _particleSystem.collision.minKillSpeed,
            mode = _particleSystem.collision.mode,
            multiplyColliderForceByCollisionAngle = _particleSystem.collision.multiplyColliderForceByCollisionAngle,
            multiplyColliderForceByParticleSize = _particleSystem.collision.multiplyColliderForceByParticleSize,
            multiplyColliderForceByParticleSpeed = _particleSystem.collision.multiplyColliderForceByParticleSpeed,
            quality = _particleSystem.collision.quality,
            radiusScale = _particleSystem.collision.radiusScale,
            sendCollisionMessages = _particleSystem.collision.sendCollisionMessages,
            type = _particleSystem.collision.type,
            voxelSize = _particleSystem.collision.voxelSize
        };
        #endregion

        #region Trigger Module
        returnVal.pTriggerModule = new SParticleSystem.P_TriggerModule()
        {
            enabled = _particleSystem.trigger.enabled,
            enter = _particleSystem.trigger.enter,
            exit = _particleSystem.trigger.exit,
            inside = _particleSystem.trigger.inside,
            maxColliderCount = _particleSystem.trigger.maxColliderCount,
            outside = _particleSystem.trigger.outside,
            radiusScale = _particleSystem.trigger.radiusScale
        };
        #endregion

        #region Sub Emitters Module
        returnVal.pSubEmittersModule = new SParticleSystem.P_SubEmittersModule()
        {
            enabled = _particleSystem.subEmitters.enabled,
            subEmittersCount = _particleSystem.subEmitters.subEmittersCount
        };
        //returnVal.pSubEmittersModule.SerializeSubEmitters(_particleSystem.subEmitters);
        #endregion

        #region Texture Sheet Animation Module
        returnVal.pTextureSheetAnimationModule = new SParticleSystem.P_TextureSheetAnimationModule()
        {
            animation = _particleSystem.textureSheetAnimation.animation,
            cycleCount = _particleSystem.textureSheetAnimation.cycleCount,
            enabled = _particleSystem.textureSheetAnimation.enabled,
            fps = _particleSystem.textureSheetAnimation.fps,
            frameOverTime = _particleSystem.textureSheetAnimation.frameOverTime.Serialize(),
            frameOverTimeMultiplier = _particleSystem.textureSheetAnimation.frameOverTimeMultiplier,
            mode = _particleSystem.textureSheetAnimation.mode,
            numTilesX = _particleSystem.textureSheetAnimation.numTilesX,
            numTilesY = _particleSystem.textureSheetAnimation.numTilesY,
            rowIndex = _particleSystem.textureSheetAnimation.rowIndex,
            rowMode = _particleSystem.textureSheetAnimation.rowMode,
            speedRange = _particleSystem.textureSheetAnimation.speedRange.Serialize(),
            spriteCount = _particleSystem.textureSheetAnimation.spriteCount,
            startFrame = _particleSystem.textureSheetAnimation.startFrame.Serialize(),
            startFrameMultiplier = _particleSystem.textureSheetAnimation.startFrameMultiplier,
            timeMode = _particleSystem.textureSheetAnimation.timeMode,
            uvChannelMask = _particleSystem.textureSheetAnimation.uvChannelMask
        };
        #endregion

        #region Lights Module
        returnVal.pLightsModule = new SParticleSystem.P_LightsModule()
        {
            alphaAffectsIntensity = _particleSystem.lights.alphaAffectsIntensity,
            enabled = _particleSystem.lights.enabled,
            intensity = _particleSystem.lights.intensity.Serialize(),
            intensityMultiplier = _particleSystem.lights.intensityMultiplier,
            //light = _particleSystem.lights.light,
            maxLights = _particleSystem.lights.maxLights,
            range = _particleSystem.lights.range.Serialize(),
            rangeMultiplier = _particleSystem.lights.rangeMultiplier,
            ratio = _particleSystem.lights.ratio,
            sizeAffectsRange = _particleSystem.lights.sizeAffectsRange,
            useParticleColor = _particleSystem.lights.useParticleColor,
            useRandomDistribution = _particleSystem.lights.useRandomDistribution
        };
        #endregion

        #region Trails Module
        returnVal.pTrailsModule = new SParticleSystem.P_TrailsModule()
        {
            attachRibbonsToTransform = _particleSystem.trails.attachRibbonsToTransform,
            colorOverLifetime = _particleSystem.trails.colorOverLifetime.Serialize(),
            colorOverTrail = _particleSystem.trails.colorOverTrail.Serialize(),
            dieWithParticles = _particleSystem.trails.dieWithParticles,
            enabled = _particleSystem.trails.enabled,
            generateLightingData = _particleSystem.trails.generateLightingData,
            inheritParticleColor = _particleSystem.trails.inheritParticleColor,
            lifetime = _particleSystem.trails.lifetime.Serialize(),
            lifetimeMultiplier = _particleSystem.trails.lifetimeMultiplier,
            minVertexDistance = _particleSystem.trails.minVertexDistance,
            mode = _particleSystem.trails.mode,
            ratio = _particleSystem.trails.ratio,
            ribbonCount = _particleSystem.trails.ribbonCount,
            shadowBias = _particleSystem.trails.shadowBias,
            sizeAffectsLifetime = _particleSystem.trails.sizeAffectsLifetime,
            sizeAffectsWidth = _particleSystem.trails.sizeAffectsWidth,
            splitSubEmitterRibbons = _particleSystem.trails.splitSubEmitterRibbons,
            textureMode = _particleSystem.trails.textureMode,
            widthOverTrail = _particleSystem.trails.widthOverTrail.Serialize(),
            widthOverTrailMultiplier = _particleSystem.trails.widthOverTrailMultiplier,
            worldSpace = _particleSystem.trails.worldSpace
        };
        #endregion

        #region Custom Data Module
        returnVal.pCustomDataModule = new SParticleSystem.P_CustomDataModule()
        {
            enabled = _particleSystem.customData.enabled,
        };
        #endregion

        //Particle System Renderer (Handle particle renderer here in the future)
        //_particleSystem.GetComponent<ParticleSystemRenderer>()

        return returnVal;
    }
    #endregion

    #region Deserialize
    public static void Deserialize(this SParticleSystem _particleSystem, ref GameObject _gameObject)
    {
        if (_particleSystem.ExistsOnObject == false)
            return;

        ParticleSystem returnVal = _gameObject.GetComponent<ParticleSystem>();

        bool isPlaying = returnVal.isPlaying;
        returnVal.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        #region Main Module
        ParticleSystem.MainModule mainModule = returnVal.main;
        mainModule.cullingMode = _particleSystem.pMain.cullingMode;
        mainModule.customSimulationSpace = _particleSystem.pMain.customSimulationSpace.Deserialize(ref _gameObject);
        mainModule.duration = _particleSystem.pMain.duration;
        mainModule.emitterVelocityMode = _particleSystem.pMain.emitterVelocityMode;
        mainModule.flipRotation = _particleSystem.pMain.flipRotation;
        mainModule.gravityModifier = _particleSystem.pMain.gravityModifier.Deserialize();
        mainModule.gravityModifierMultiplier = _particleSystem.pMain.gravityModifierMultiplier;
        mainModule.loop = _particleSystem.pMain.loop;
        mainModule.maxParticles = _particleSystem.pMain.maxParticles;
        mainModule.playOnAwake = _particleSystem.pMain.playOnAwake;
        mainModule.prewarm = _particleSystem.pMain.prewarm;
        mainModule.ringBufferLoopRange = _particleSystem.pMain.ringBufferLoopRange.Deserialize();
        mainModule.ringBufferMode = _particleSystem.pMain.ringBufferMode;
        mainModule.scalingMode = _particleSystem.pMain.scalingMode;
        mainModule.simulationSpace = _particleSystem.pMain.simulationSpace;
        mainModule.simulationSpeed = _particleSystem.pMain.simulationSpeed;
        mainModule.startColor = _particleSystem.pMain.startColor.Deserialize();
        mainModule.startDelay = _particleSystem.pMain.startDelay.Deserialize();
        mainModule.startDelayMultiplier = _particleSystem.pMain.startDelayMultiplier;
        mainModule.startLifetime = _particleSystem.pMain.startLifetime.Deserialize();
        mainModule.startLifetimeMultiplier = _particleSystem.pMain.startLifetimeMultiplier;
        mainModule.startRotation = _particleSystem.pMain.startRotation.Deserialize();
        mainModule.startRotation3D = _particleSystem.pMain.startRotation3D;
        mainModule.startRotationMultiplier = _particleSystem.pMain.startRotationMultiplier;
        mainModule.startRotationX = _particleSystem.pMain.startRotationX.Deserialize();
        mainModule.startRotationXMultiplier = _particleSystem.pMain.startRotationXMultiplier;
        mainModule.startRotationY = _particleSystem.pMain.startRotationY.Deserialize();
        mainModule.startRotationYMultiplier = _particleSystem.pMain.startRotationYMultiplier;
        mainModule.startRotationZ = _particleSystem.pMain.startRotationZ.Deserialize();
        mainModule.startRotationZMultiplier = _particleSystem.pMain.startRotationZMultiplier;
        mainModule.startSize = _particleSystem.pMain.startSize.Deserialize();
        mainModule.startSize3D = _particleSystem.pMain.startSize3D;
        mainModule.startSizeMultiplier = _particleSystem.pMain.startSizeMultiplier;
        mainModule.startSizeX = _particleSystem.pMain.startSizeX.Deserialize();
        mainModule.startSizeXMultiplier = _particleSystem.pMain.startSizeXMultiplier;
        mainModule.startSizeY = _particleSystem.pMain.startSizeY.Deserialize();
        mainModule.startSizeYMultiplier = _particleSystem.pMain.startSizeYMultiplier;
        mainModule.startSizeZ = _particleSystem.pMain.startSizeZ.Deserialize();
        mainModule.startSizeZMultiplier = _particleSystem.pMain.startSizeZMultiplier;
        mainModule.startSpeed = _particleSystem.pMain.startSpeed.Deserialize();
        mainModule.startSpeedMultiplier = _particleSystem.pMain.startSpeedMultiplier;
        mainModule.stopAction = _particleSystem.pMain.stopAction;
        mainModule.useUnscaledTime = _particleSystem.pMain.useUnscaledTime;
        #endregion

        #region Emission Module
        ParticleSystem.EmissionModule emissionModule = returnVal.emission;
        emissionModule.burstCount = _particleSystem.pEmission.burstCount;
        emissionModule.enabled = _particleSystem.pEmission.enabled;
        emissionModule.rateOverDistance = _particleSystem.pEmission.rateOverDistance.Deserialize();
        emissionModule.rateOverDistanceMultiplier = _particleSystem.pEmission.rateOverDistanceMultiplier;
        emissionModule.rateOverTime = _particleSystem.pEmission.rateOverTime.Deserialize();
        emissionModule.rateOverTimeMultiplier = _particleSystem.pEmission.rateOverTimeMultiplier;
        //_particleSystem.pEmission.DeserializeBursts(ref emissionModule);
        #endregion

        #region Shape Module
        ParticleSystem.ShapeModule shapeModule = returnVal.shape;
        shapeModule.alignToDirection = _particleSystem.pShapeModule.alignToDirection;
        shapeModule.angle = _particleSystem.pShapeModule.angle;
        shapeModule.arc = _particleSystem.pShapeModule.arc;
        shapeModule.arcMode = _particleSystem.pShapeModule.arcMode;
        shapeModule.arcSpeed = _particleSystem.pShapeModule.arcSpeed.Deserialize();
        shapeModule.arcSpeedMultiplier = _particleSystem.pShapeModule.arcSpeedMultiplier;
        shapeModule.arcSpread = _particleSystem.pShapeModule.arcSpread;
        shapeModule.scale = _particleSystem.pShapeModule.scale.Deserialize();
        shapeModule.boxThickness = _particleSystem.pShapeModule.boxThickness.Deserialize();
        shapeModule.donutRadius = _particleSystem.pShapeModule.donutRadius;
        shapeModule.enabled = _particleSystem.pShapeModule.enabled;
        shapeModule.length = _particleSystem.pShapeModule.length;
        shapeModule.mesh = _particleSystem.pShapeModule.mesh.Deserialize();
        shapeModule.meshMaterialIndex = _particleSystem.pShapeModule.meshMaterialIndex;
        shapeModule.meshRenderer = _particleSystem.pShapeModule.meshRenderer.Deserialize();
        shapeModule.meshShapeType = _particleSystem.pShapeModule.meshShapeType;
        shapeModule.meshSpawnMode = _particleSystem.pShapeModule.meshSpawnMode;
        shapeModule.meshSpawnSpeed = _particleSystem.pShapeModule.meshSpawnSpeed.Deserialize();
        shapeModule.meshSpawnSpeedMultiplier = _particleSystem.pShapeModule.meshSpawnSpeedMultiplier;
        shapeModule.meshSpawnSpread = _particleSystem.pShapeModule.meshSpawnSpread;
        shapeModule.normalOffset = _particleSystem.pShapeModule.normalOffset;
        shapeModule.position = _particleSystem.pShapeModule.position.Deserialize();
        shapeModule.radius = _particleSystem.pShapeModule.radius;
        shapeModule.radiusMode = _particleSystem.pShapeModule.radiusMode;
        shapeModule.radiusSpeed = _particleSystem.pShapeModule.radiusSpeed.Deserialize();
        shapeModule.radiusSpeedMultiplier = _particleSystem.pShapeModule.radiusSpeedMultiplier;
        shapeModule.radiusSpread = _particleSystem.pShapeModule.radiusSpread;
        shapeModule.radiusThickness = _particleSystem.pShapeModule.radiusThickness;
        shapeModule.randomDirectionAmount = _particleSystem.pShapeModule.randomDirectionAmount;
        shapeModule.randomPositionAmount = _particleSystem.pShapeModule.randomPositionAmount;
        shapeModule.rotation = _particleSystem.pShapeModule.rotation.Deserialize();
        shapeModule.scale = _particleSystem.pShapeModule.scale.Deserialize();
        shapeModule.shapeType = _particleSystem.pShapeModule.shapeType;
        shapeModule.skinnedMeshRenderer = _particleSystem.pShapeModule.skinnedMeshRenderer.Deserialize();
        shapeModule.sphericalDirectionAmount = _particleSystem.pShapeModule.sphericalDirectionAmount;
        //shapeModule.sprite = _particleSystem.pShapeModule.sprite;
        //shapeModule.spriteRenderer = _particleSystem.pShapeModule.spriteRenderer;
        //shapeModule.texture = _particleSystem.pShapeModule.texture;
        shapeModule.textureAlphaAffectsParticles = _particleSystem.pShapeModule.textureAlphaAffectsParticles;
        shapeModule.textureBilinearFiltering = _particleSystem.pShapeModule.textureBilinearFiltering;
        shapeModule.textureClipChannel = _particleSystem.pShapeModule.textureClipChannel;
        shapeModule.textureClipThreshold = _particleSystem.pShapeModule.textureClipThreshold;
        shapeModule.textureColorAffectsParticles = _particleSystem.pShapeModule.textureColorAffectsParticles;
        shapeModule.textureUVChannel = _particleSystem.pShapeModule.textureUVChannel;
        shapeModule.useMeshColors = _particleSystem.pShapeModule.useMeshColors;
        shapeModule.useMeshMaterialIndex = _particleSystem.pShapeModule.useMeshMaterialIndex;
        #endregion

        #region Velocity over Lifetime Module
        ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = returnVal.velocityOverLifetime;
        velocityOverLifetimeModule.enabled = _particleSystem.pVelocityOverLifetimeModule.enabled;
        velocityOverLifetimeModule.orbitalOffsetX = _particleSystem.pVelocityOverLifetimeModule.orbitalOffsetX.Deserialize();
        velocityOverLifetimeModule.orbitalOffsetXMultiplier = _particleSystem.pVelocityOverLifetimeModule.orbitalOffsetXMultiplier;
        velocityOverLifetimeModule.orbitalOffsetY = _particleSystem.pVelocityOverLifetimeModule.orbitalOffsetY.Deserialize();
        velocityOverLifetimeModule.orbitalOffsetYMultiplier = _particleSystem.pVelocityOverLifetimeModule.orbitalOffsetYMultiplier;
        velocityOverLifetimeModule.orbitalOffsetZ = _particleSystem.pVelocityOverLifetimeModule.orbitalOffsetZ.Deserialize();
        velocityOverLifetimeModule.orbitalOffsetZMultiplier = _particleSystem.pVelocityOverLifetimeModule.orbitalOffsetZMultiplier;
        velocityOverLifetimeModule.orbitalX = _particleSystem.pVelocityOverLifetimeModule.orbitalX.Deserialize();
        velocityOverLifetimeModule.orbitalXMultiplier = _particleSystem.pVelocityOverLifetimeModule.orbitalXMultiplier;
        velocityOverLifetimeModule.orbitalY = _particleSystem.pVelocityOverLifetimeModule.orbitalY.Deserialize();
        velocityOverLifetimeModule.orbitalYMultiplier = _particleSystem.pVelocityOverLifetimeModule.orbitalYMultiplier;
        velocityOverLifetimeModule.orbitalZ = _particleSystem.pVelocityOverLifetimeModule.orbitalZ.Deserialize();
        velocityOverLifetimeModule.orbitalZMultiplier = _particleSystem.pVelocityOverLifetimeModule.orbitalZMultiplier;
        velocityOverLifetimeModule.radial = _particleSystem.pVelocityOverLifetimeModule.radial.Deserialize();
        velocityOverLifetimeModule.radialMultiplier = _particleSystem.pVelocityOverLifetimeModule.radialMultiplier;
        velocityOverLifetimeModule.space = _particleSystem.pVelocityOverLifetimeModule.space;
        velocityOverLifetimeModule.speedModifier = _particleSystem.pVelocityOverLifetimeModule.speedModifier.Deserialize();
        velocityOverLifetimeModule.speedModifierMultiplier = _particleSystem.pVelocityOverLifetimeModule.speedModifierMultiplier;
        velocityOverLifetimeModule.x = _particleSystem.pVelocityOverLifetimeModule.x.Deserialize();
        velocityOverLifetimeModule.xMultiplier = _particleSystem.pVelocityOverLifetimeModule.xMultiplier;
        velocityOverLifetimeModule.y = _particleSystem.pVelocityOverLifetimeModule.y.Deserialize();
        velocityOverLifetimeModule.yMultiplier = _particleSystem.pVelocityOverLifetimeModule.yMultiplier;
        velocityOverLifetimeModule.z = _particleSystem.pVelocityOverLifetimeModule.z.Deserialize();
        velocityOverLifetimeModule.zMultiplier = _particleSystem.pVelocityOverLifetimeModule.zMultiplier;
        #endregion

        #region Noise Module
        ParticleSystem.NoiseModule noiseModule = returnVal.noise;
        noiseModule.damping = _particleSystem.pNoiseModule.damping;
        noiseModule.enabled = _particleSystem.pNoiseModule.enabled;
        noiseModule.frequency = _particleSystem.pNoiseModule.frequency;
        noiseModule.octaveCount = _particleSystem.pNoiseModule.octaveCount;
        noiseModule.octaveMultiplier = _particleSystem.pNoiseModule.octaveMultiplier;
        noiseModule.octaveScale = _particleSystem.pNoiseModule.octaveScale;
        noiseModule.positionAmount = _particleSystem.pNoiseModule.positionAmount.Deserialize();
        noiseModule.quality = _particleSystem.pNoiseModule.quality;
        noiseModule.remap = _particleSystem.pNoiseModule.remap.Deserialize();
        noiseModule.remapEnabled = _particleSystem.pNoiseModule.remapEnabled;
        noiseModule.remapMultiplier = _particleSystem.pNoiseModule.remapMultiplier;
        noiseModule.remapX = _particleSystem.pNoiseModule.remapX.Deserialize();
        noiseModule.remapXMultiplier = _particleSystem.pNoiseModule.remapXMultiplier;
        noiseModule.remapY = _particleSystem.pNoiseModule.remapY.Deserialize();
        noiseModule.remapYMultiplier = _particleSystem.pNoiseModule.remapYMultiplier;
        noiseModule.remapZ = _particleSystem.pNoiseModule.remapZ.Deserialize();
        noiseModule.remapZMultiplier = _particleSystem.pNoiseModule.remapZMultiplier;
        noiseModule.rotationAmount = _particleSystem.pNoiseModule.rotationAmount.Deserialize();
        noiseModule.scrollSpeed = _particleSystem.pNoiseModule.scrollSpeed.Deserialize();
        noiseModule.scrollSpeedMultiplier = _particleSystem.pNoiseModule.scrollSpeedMultiplier;
        noiseModule.separateAxes = _particleSystem.pNoiseModule.separateAxes;
        noiseModule.sizeAmount = _particleSystem.pNoiseModule.sizeAmount.Deserialize();
        noiseModule.strength = _particleSystem.pNoiseModule.strength.Deserialize();
        noiseModule.strengthMultiplier = _particleSystem.pNoiseModule.strengthMultiplier;
        noiseModule.strengthX = _particleSystem.pNoiseModule.strengthX.Deserialize();
        noiseModule.strengthXMultiplier = _particleSystem.pNoiseModule.strengthXMultiplier;
        noiseModule.strengthY = _particleSystem.pNoiseModule.strengthY.Deserialize();
        noiseModule.strengthYMultiplier = _particleSystem.pNoiseModule.strengthYMultiplier;
        noiseModule.strengthZ = _particleSystem.pNoiseModule.strengthZ.Deserialize();
        noiseModule.strengthZMultiplier = _particleSystem.pNoiseModule.strengthZMultiplier;
        #endregion

        #region Limit Velocity OverLifetime Module
        ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetimeModule = returnVal.limitVelocityOverLifetime;
        limitVelocityOverLifetimeModule.dampen = _particleSystem.pLimitVelocityOverLifetimeModule.dampen;
        limitVelocityOverLifetimeModule.drag = _particleSystem.pLimitVelocityOverLifetimeModule.drag.Deserialize();
        limitVelocityOverLifetimeModule.dragMultiplier = _particleSystem.pLimitVelocityOverLifetimeModule.dragMultiplier;
        limitVelocityOverLifetimeModule.enabled = _particleSystem.pLimitVelocityOverLifetimeModule.enabled;
        limitVelocityOverLifetimeModule.limit = _particleSystem.pLimitVelocityOverLifetimeModule.limit.Deserialize();
        limitVelocityOverLifetimeModule.limitMultiplier = _particleSystem.pLimitVelocityOverLifetimeModule.limitMultiplier;
        limitVelocityOverLifetimeModule.limitX = _particleSystem.pLimitVelocityOverLifetimeModule.limitX.Deserialize();
        limitVelocityOverLifetimeModule.limitXMultiplier = _particleSystem.pLimitVelocityOverLifetimeModule.limitXMultiplier;
        limitVelocityOverLifetimeModule.limitY = _particleSystem.pLimitVelocityOverLifetimeModule.limitY.Deserialize();
        limitVelocityOverLifetimeModule.limitYMultiplier = _particleSystem.pLimitVelocityOverLifetimeModule.limitYMultiplier;
        limitVelocityOverLifetimeModule.limitZ = _particleSystem.pLimitVelocityOverLifetimeModule.limitZ.Deserialize();
        limitVelocityOverLifetimeModule.limitZMultiplier = _particleSystem.pLimitVelocityOverLifetimeModule.limitZMultiplier;
        limitVelocityOverLifetimeModule.multiplyDragByParticleSize = _particleSystem.pLimitVelocityOverLifetimeModule.multiplyDragByParticleSize;
        limitVelocityOverLifetimeModule.multiplyDragByParticleVelocity = _particleSystem.pLimitVelocityOverLifetimeModule.multiplyDragByParticleVelocity;
        limitVelocityOverLifetimeModule.separateAxes = _particleSystem.pLimitVelocityOverLifetimeModule.separateAxes;
        limitVelocityOverLifetimeModule.space = _particleSystem.pLimitVelocityOverLifetimeModule.space;
        #endregion

        #region Inherit Velocity Module
        ParticleSystem.InheritVelocityModule inheritVelocity = returnVal.inheritVelocity;
        inheritVelocity.curve = _particleSystem.pInheritVelocityModule.curve.Deserialize();
        inheritVelocity.curveMultiplier = _particleSystem.pInheritVelocityModule.curveMultiplier;
        inheritVelocity.enabled = _particleSystem.pInheritVelocityModule.enabled;
        inheritVelocity.mode = _particleSystem.pInheritVelocityModule.mode;
        #endregion

        #region Force Over Lifetime Module
        ParticleSystem.ForceOverLifetimeModule forceOverLifetime = returnVal.forceOverLifetime;
        forceOverLifetime.enabled = _particleSystem.pForceOverLifetimeModule.enabled;
        forceOverLifetime.randomized = _particleSystem.pForceOverLifetimeModule.randomized;
        forceOverLifetime.space = _particleSystem.pForceOverLifetimeModule.space;
        forceOverLifetime.x = _particleSystem.pForceOverLifetimeModule.x.Deserialize();
        forceOverLifetime.xMultiplier = _particleSystem.pForceOverLifetimeModule.xMultiplier;
        forceOverLifetime.y = _particleSystem.pForceOverLifetimeModule.y.Deserialize();
        forceOverLifetime.yMultiplier = _particleSystem.pForceOverLifetimeModule.yMultiplier;
        forceOverLifetime.z = _particleSystem.pForceOverLifetimeModule.z.Deserialize();
        forceOverLifetime.zMultiplier = _particleSystem.pForceOverLifetimeModule.zMultiplier;
        #endregion

        #region Color Over Lifetime Module
        ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = returnVal.colorOverLifetime;
        colorOverLifetimeModule.color = _particleSystem.pColourOverLifetimeModule.color.Deserialize();
        colorOverLifetimeModule.enabled = _particleSystem.pColourOverLifetimeModule.enabled;
        #endregion

        #region Color By Speed Module
        ParticleSystem.ColorBySpeedModule colorBySpeedMocule = returnVal.colorBySpeed;
        colorBySpeedMocule.color = _particleSystem.pColorBySpeedModule.color.Deserialize();
        colorBySpeedMocule.enabled = _particleSystem.pColorBySpeedModule.enabled;
        colorBySpeedMocule.range = _particleSystem.pColorBySpeedModule.range.Deserialize();
        #endregion

        #region Size Over Lifetime Module
        ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = returnVal.sizeOverLifetime;
        sizeOverLifetimeModule.enabled = _particleSystem.pSizeOverLifetime.enabled;
        sizeOverLifetimeModule.separateAxes = _particleSystem.pSizeOverLifetime.separateAxes;
        sizeOverLifetimeModule.size = _particleSystem.pSizeOverLifetime.size.Deserialize();
        sizeOverLifetimeModule.sizeMultiplier = _particleSystem.pSizeOverLifetime.sizeMultiplier;
        sizeOverLifetimeModule.x = _particleSystem.pSizeOverLifetime.x.Deserialize();
        sizeOverLifetimeModule.xMultiplier = _particleSystem.pSizeOverLifetime.xMultiplier;
        sizeOverLifetimeModule.y = _particleSystem.pSizeOverLifetime.y.Deserialize();
        sizeOverLifetimeModule.yMultiplier = _particleSystem.pSizeOverLifetime.yMultiplier;
        sizeOverLifetimeModule.z = _particleSystem.pSizeOverLifetime.z.Deserialize();
        sizeOverLifetimeModule.zMultiplier = _particleSystem.pSizeOverLifetime.zMultiplier;
        #endregion

        #region Size By Speed Module
        ParticleSystem.SizeBySpeedModule sizeBySpeedModule = returnVal.sizeBySpeed;
        sizeBySpeedModule.enabled = _particleSystem.pSizeBySpeedModule.enabled;
        sizeBySpeedModule.range = _particleSystem.pSizeBySpeedModule.range.Deserialize();
        sizeBySpeedModule.separateAxes = _particleSystem.pSizeBySpeedModule.separateAxes;
        sizeBySpeedModule.size = _particleSystem.pSizeBySpeedModule.size.Deserialize();
        sizeBySpeedModule.sizeMultiplier = _particleSystem.pSizeBySpeedModule.sizeMultiplier;
        sizeBySpeedModule.x = _particleSystem.pSizeBySpeedModule.x.Deserialize();
        sizeBySpeedModule.xMultiplier = _particleSystem.pSizeBySpeedModule.xMultiplier;
        sizeBySpeedModule.y = _particleSystem.pSizeBySpeedModule.y.Deserialize();
        sizeBySpeedModule.yMultiplier = _particleSystem.pSizeBySpeedModule.yMultiplier;
        sizeBySpeedModule.z = _particleSystem.pSizeBySpeedModule.z.Deserialize();
        sizeBySpeedModule.zMultiplier = _particleSystem.pSizeBySpeedModule.zMultiplier;
        #endregion

        #region Rotation Over Lifetime Module
        ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = returnVal.rotationOverLifetime;
        rotationOverLifetimeModule.enabled = _particleSystem.pRotationOverLifetimeModule.enabled;
        rotationOverLifetimeModule.separateAxes = _particleSystem.pRotationOverLifetimeModule.separateAxes;
        rotationOverLifetimeModule.x = _particleSystem.pRotationOverLifetimeModule.x.Deserialize();
        rotationOverLifetimeModule.xMultiplier = _particleSystem.pRotationOverLifetimeModule.xMultiplier;
        rotationOverLifetimeModule.y = _particleSystem.pRotationOverLifetimeModule.y.Deserialize();
        rotationOverLifetimeModule.yMultiplier = _particleSystem.pRotationOverLifetimeModule.yMultiplier;
        rotationOverLifetimeModule.z = _particleSystem.pRotationOverLifetimeModule.z.Deserialize();
        rotationOverLifetimeModule.zMultiplier = _particleSystem.pRotationOverLifetimeModule.zMultiplier;
        #endregion

        #region Rotation By Speed Module
        ParticleSystem.RotationBySpeedModule rotationBySpeedModule = returnVal.rotationBySpeed;
        rotationBySpeedModule.enabled = _particleSystem.pRotationBySpeedModule.enabled;
        rotationBySpeedModule.range = _particleSystem.pRotationBySpeedModule.range.Deserialize();
        rotationBySpeedModule.x = _particleSystem.pRotationBySpeedModule.x.Deserialize();
        rotationBySpeedModule.xMultiplier = _particleSystem.pRotationBySpeedModule.xMultiplier;
        rotationBySpeedModule.y = _particleSystem.pRotationBySpeedModule.y.Deserialize();
        rotationBySpeedModule.yMultiplier = _particleSystem.pRotationBySpeedModule.yMultiplier;
        rotationBySpeedModule.z = _particleSystem.pRotationBySpeedModule.z.Deserialize();
        rotationBySpeedModule.zMultiplier = _particleSystem.pRotationBySpeedModule.zMultiplier;
        #endregion

        #region External Forces Module
        ParticleSystem.ExternalForcesModule externalForcesModule = returnVal.externalForces;
        externalForcesModule.enabled = _particleSystem.pExternalForcesModule.enabled;
        //externalForcesModule.influenceCount = _particleSystem.pExternalForcesModule.influenceCount;
        externalForcesModule.influenceFilter = _particleSystem.pExternalForcesModule.influenceFilter;
        externalForcesModule.influenceMask = _particleSystem.pExternalForcesModule.influenceMask;
        externalForcesModule.multiplier = _particleSystem.pExternalForcesModule.multiplier;
        externalForcesModule.multiplierCurve = _particleSystem.pExternalForcesModule.multiplierCurve.Deserialize();
        #endregion

        #region Collision Module
        ParticleSystem.CollisionModule collisionModule = returnVal.collision;
        collisionModule.bounce = _particleSystem.pCollisionModule.bounce.Deserialize();
        collisionModule.bounceMultiplier = _particleSystem.pCollisionModule.bounceMultiplier;
        collisionModule.colliderForce = _particleSystem.pCollisionModule.colliderForce;
        collisionModule.collidesWith = _particleSystem.pCollisionModule.collidesWith;
        collisionModule.dampen = _particleSystem.pCollisionModule.dampen.Deserialize();
        collisionModule.dampenMultiplier = _particleSystem.pCollisionModule.dampenMultiplier;
        collisionModule.enabled = _particleSystem.pCollisionModule.enabled;
        collisionModule.enableDynamicColliders = _particleSystem.pCollisionModule.enableDynamicColliders;
        collisionModule.lifetimeLoss = _particleSystem.pCollisionModule.lifetimeLoss.Deserialize();
        collisionModule.lifetimeLossMultiplier = _particleSystem.pCollisionModule.lifetimeLossMultiplier;
        collisionModule.maxCollisionShapes = _particleSystem.pCollisionModule.maxCollisionShapes;
        collisionModule.maxKillSpeed = _particleSystem.pCollisionModule.maxKillSpeed;
        //collisionModule.maxPlaneCount = _particleSystem.pCollisionModule.maxPlaneCount;
        collisionModule.minKillSpeed = _particleSystem.pCollisionModule.minKillSpeed;
        collisionModule.mode = _particleSystem.pCollisionModule.mode;
        collisionModule.multiplyColliderForceByCollisionAngle = _particleSystem.pCollisionModule.multiplyColliderForceByCollisionAngle;
        collisionModule.multiplyColliderForceByParticleSize = _particleSystem.pCollisionModule.multiplyColliderForceByParticleSize;
        collisionModule.multiplyColliderForceByParticleSpeed = _particleSystem.pCollisionModule.multiplyColliderForceByParticleSpeed;
        collisionModule.quality = _particleSystem.pCollisionModule.quality;
        collisionModule.radiusScale = _particleSystem.pCollisionModule.radiusScale;
        collisionModule.sendCollisionMessages = _particleSystem.pCollisionModule.sendCollisionMessages;
        collisionModule.type = _particleSystem.pCollisionModule.type;
        collisionModule.voxelSize = _particleSystem.pCollisionModule.voxelSize;
        #endregion

        #region Trigger Module
        ParticleSystem.TriggerModule triggerModule = returnVal.trigger;
        triggerModule.enabled = _particleSystem.pTriggerModule.enabled;
        triggerModule.enter = _particleSystem.pTriggerModule.enter;
        triggerModule.exit = _particleSystem.pTriggerModule.exit;
        triggerModule.inside = _particleSystem.pTriggerModule.inside;
        //triggerModule.maxColliderCount = _particleSystem.pTriggerModule.maxColliderCount;
        triggerModule.outside = _particleSystem.pTriggerModule.outside;
        triggerModule.radiusScale = _particleSystem.pTriggerModule.radiusScale;
        #endregion

        #region Sub Emitters Module
        ParticleSystem.SubEmittersModule subEmittersModule = returnVal.subEmitters;
        subEmittersModule.enabled = _particleSystem.pSubEmittersModule.enabled;
        //_particleSystem.subEmittersModule.subEmittersCount = returnVal.subEmitters.subEmittersCount;
        //_particleSystem.pSubEmittersModule.DeserializeSubEmitters(ref subEmittersModule);
        #endregion

        #region Texture Sheet Animation Module
        ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = returnVal.textureSheetAnimation;
        textureSheetAnimationModule.animation = _particleSystem.pTextureSheetAnimationModule.animation;
        textureSheetAnimationModule.cycleCount = _particleSystem.pTextureSheetAnimationModule.cycleCount;
        textureSheetAnimationModule.enabled = _particleSystem.pTextureSheetAnimationModule.enabled;
        textureSheetAnimationModule.fps = _particleSystem.pTextureSheetAnimationModule.fps;
        textureSheetAnimationModule.frameOverTime = _particleSystem.pTextureSheetAnimationModule.frameOverTime.Deserialize();
        textureSheetAnimationModule.frameOverTimeMultiplier = _particleSystem.pTextureSheetAnimationModule.frameOverTimeMultiplier;
        textureSheetAnimationModule.mode = _particleSystem.pTextureSheetAnimationModule.mode;
        textureSheetAnimationModule.numTilesX = _particleSystem.pTextureSheetAnimationModule.numTilesX;
        textureSheetAnimationModule.numTilesY = _particleSystem.pTextureSheetAnimationModule.numTilesY;
        textureSheetAnimationModule.rowIndex = _particleSystem.pTextureSheetAnimationModule.rowIndex;
        textureSheetAnimationModule.rowMode = _particleSystem.pTextureSheetAnimationModule.rowMode;
        textureSheetAnimationModule.speedRange = _particleSystem.pTextureSheetAnimationModule.speedRange.Deserialize();
        //textureSheetAnimationModule.spriteCount = _particleSystem.pTextureSheetAnimationModule.spriteCount;
        textureSheetAnimationModule.startFrame = _particleSystem.pTextureSheetAnimationModule.startFrame.Deserialize();
        textureSheetAnimationModule.startFrameMultiplier = _particleSystem.pTextureSheetAnimationModule.startFrameMultiplier;
        textureSheetAnimationModule.timeMode = _particleSystem.pTextureSheetAnimationModule.timeMode;
        textureSheetAnimationModule.uvChannelMask = _particleSystem.pTextureSheetAnimationModule.uvChannelMask;
        #endregion

        #region Lights Module
        ParticleSystem.LightsModule lightsModule = returnVal.lights;
        lightsModule.alphaAffectsIntensity = _particleSystem.pLightsModule.alphaAffectsIntensity;
        lightsModule.enabled = _particleSystem.pLightsModule.enabled;
        lightsModule.intensity = _particleSystem.pLightsModule.intensity.Deserialize();
        lightsModule.intensityMultiplier = _particleSystem.pLightsModule.intensityMultiplier;
        //lightsModule.light = _particleSystem.pLightsModule.light;
        lightsModule.maxLights = _particleSystem.pLightsModule.maxLights;
        lightsModule.range = _particleSystem.pLightsModule.range.Deserialize();
        lightsModule.rangeMultiplier = _particleSystem.pLightsModule.rangeMultiplier;
        lightsModule.ratio = _particleSystem.pLightsModule.ratio;
        lightsModule.sizeAffectsRange = _particleSystem.pLightsModule.sizeAffectsRange;
        lightsModule.useParticleColor = _particleSystem.pLightsModule.useParticleColor;
        lightsModule.useRandomDistribution = _particleSystem.pLightsModule.useRandomDistribution;
        #endregion

        #region Trails Module
        ParticleSystem.TrailModule trailsModule = returnVal.trails;
        trailsModule.attachRibbonsToTransform = _particleSystem.pTrailsModule.attachRibbonsToTransform;
        trailsModule.colorOverLifetime = _particleSystem.pTrailsModule.colorOverLifetime.Deserialize();
        trailsModule.colorOverTrail = _particleSystem.pTrailsModule.colorOverTrail.Deserialize();
        trailsModule.dieWithParticles = _particleSystem.pTrailsModule.dieWithParticles;
        trailsModule.enabled = _particleSystem.pTrailsModule.enabled;
        trailsModule.generateLightingData = _particleSystem.pTrailsModule.generateLightingData;
        trailsModule.inheritParticleColor = _particleSystem.pTrailsModule.inheritParticleColor;
        trailsModule.lifetime = _particleSystem.pTrailsModule.lifetime.Deserialize();
        trailsModule.lifetimeMultiplier = _particleSystem.pTrailsModule.lifetimeMultiplier;
        trailsModule.minVertexDistance = _particleSystem.pTrailsModule.minVertexDistance;
        trailsModule.mode = _particleSystem.pTrailsModule.mode;
        trailsModule.ratio = _particleSystem.pTrailsModule.ratio;
        trailsModule.ribbonCount = _particleSystem.pTrailsModule.ribbonCount;
        trailsModule.shadowBias = _particleSystem.pTrailsModule.shadowBias;
        trailsModule.sizeAffectsLifetime = _particleSystem.pTrailsModule.sizeAffectsLifetime;
        trailsModule.sizeAffectsWidth = _particleSystem.pTrailsModule.sizeAffectsWidth;
        trailsModule.splitSubEmitterRibbons = _particleSystem.pTrailsModule.splitSubEmitterRibbons;
        trailsModule.textureMode = _particleSystem.pTrailsModule.textureMode;
        trailsModule.widthOverTrail = _particleSystem.pTrailsModule.widthOverTrail.Deserialize();
        trailsModule.widthOverTrailMultiplier = _particleSystem.pTrailsModule.widthOverTrailMultiplier;
        trailsModule.worldSpace = _particleSystem.pTrailsModule.worldSpace;
        #endregion

        #region Custom Data Module
        ParticleSystem.CustomDataModule customDataModule = returnVal.customData;
        customDataModule.enabled = _particleSystem.pCustomDataModule.enabled;
        #endregion

        //Particle System Renderer (Handle particle renderer here in the future)
        //returnVal.GetComponent<ParticleSystemRenderer>()


        if (isPlaying == true)
            returnVal.Play();
    }
    #endregion
}