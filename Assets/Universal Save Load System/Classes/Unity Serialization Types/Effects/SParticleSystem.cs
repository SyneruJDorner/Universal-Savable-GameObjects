using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

#region Particle System
[System.Serializable]
class SParticleSystem
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

    public SParticleSystem Serialize(ParticleSystem _particleSystem)
    {
        if (_particleSystem == null)
            return null;

        SParticleSystem returnVal = new SParticleSystem();
        returnVal.ExistsOnObject = (_particleSystem == null) ? false : true;

        #region Main Module
        returnVal.pMain = new P_MainModule()
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
        returnVal.pEmission = new P_EmissionModule()
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
        returnVal.pShapeModule = new P_ShapeModule()
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
        returnVal.pVelocityOverLifetimeModule = new P_VelocityOverLifetimeModule()
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
        returnVal.pNoiseModule = new P_NoiseModule()
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
        returnVal.pLimitVelocityOverLifetimeModule = new P_LimitVelocityOverLifetimeModule()
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
        returnVal.pInheritVelocityModule = new P_InheritVelocityModule()
        {
            curve = _particleSystem.inheritVelocity.curve.Serialize(),
            curveMultiplier = _particleSystem.inheritVelocity.curveMultiplier,
            enabled = _particleSystem.inheritVelocity.enabled,
            mode = _particleSystem.inheritVelocity.mode
        };
        #endregion

        #region Force Over Lifetime Module
        returnVal.pForceOverLifetimeModule = new P_ForceOverLifetimeModule()
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
        returnVal.pColourOverLifetimeModule = new P_ColourOverLifetimeModule()
        {
            color = _particleSystem.colorOverLifetime.color.Serialize(),
            enabled = _particleSystem.colorOverLifetime.enabled
        };
        #endregion

        #region Color By Speed Module
        returnVal.pColorBySpeedModule = new P_ColorBySpeedModule()
        {
            color = _particleSystem.colorBySpeed.color.Serialize(),
            enabled = _particleSystem.colorBySpeed.enabled,
            range = _particleSystem.colorBySpeed.range.Serialize()
        };
        #endregion

        #region Size Over Lifetime Module
        returnVal.pSizeOverLifetime = new P_SizeOverLifetime()
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
        returnVal.pSizeBySpeedModule = new P_SizeBySpeedModule()
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
        returnVal.pRotationOverLifetimeModule = new P_RotationOverLifetimeModule()
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
        returnVal.pRotationBySpeedModule = new P_RotationBySpeedModule()
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
        returnVal.pExternalForcesModule = new P_ExternalForcesModule()
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
        returnVal.pCollisionModule = new P_CollisionModule()
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
        returnVal.pTriggerModule = new P_TriggerModule()
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
        returnVal.pSubEmittersModule = new P_SubEmittersModule()
        {
            enabled = _particleSystem.subEmitters.enabled,
            subEmittersCount = _particleSystem.subEmitters.subEmittersCount
        };
        //returnVal.pSubEmittersModule.SerializeSubEmitters(_particleSystem.subEmitters);
        #endregion

        #region Texture Sheet Animation Module
        returnVal.pTextureSheetAnimationModule = new P_TextureSheetAnimationModule()
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
        returnVal.pLightsModule = new P_LightsModule()
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
        returnVal.pTrailsModule = new P_TrailsModule()
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
        returnVal.pCustomDataModule = new P_CustomDataModule()
        {
            enabled = _particleSystem.customData.enabled,
        };
        #endregion

        //Particle System Renderer (Handle particle renderer here in the future)
        //_particleSystem.GetComponent<ParticleSystemRenderer>()

        return returnVal;
    }

    public void Deserialize(ref GameObject _gameObject)
    {
        if (ExistsOnObject == false)
            return;

        ParticleSystem _particleSystem = _gameObject.GetComponent<ParticleSystem>();

        bool isPlaying = _particleSystem.isPlaying;
        _particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        Debug.Log("Particle playing " + isPlaying);

        #region Main Module
        ParticleSystem.MainModule mainModule = _particleSystem.main;
        mainModule.cullingMode = pMain.cullingMode;
        mainModule.customSimulationSpace = pMain.customSimulationSpace.Deserialize(ref _gameObject);
        mainModule.duration = pMain.duration;
        mainModule.emitterVelocityMode = pMain.emitterVelocityMode;
        mainModule.flipRotation = pMain.flipRotation;
        mainModule.gravityModifier = pMain.gravityModifier.Deserialize();
        mainModule.gravityModifierMultiplier = pMain.gravityModifierMultiplier;
        mainModule.loop = pMain.loop;
        mainModule.maxParticles = pMain.maxParticles;
        mainModule.playOnAwake = pMain.playOnAwake;
        mainModule.prewarm = pMain.prewarm;
        mainModule.ringBufferLoopRange = pMain.ringBufferLoopRange.Deserialize();
        mainModule.ringBufferMode = pMain.ringBufferMode;
        mainModule.scalingMode = pMain.scalingMode;
        mainModule.simulationSpace = pMain.simulationSpace;
        mainModule.simulationSpeed = pMain.simulationSpeed;
        mainModule.startColor = pMain.startColor.Deserialize();
        mainModule.startDelay = pMain.startDelay.Deserialize();
        mainModule.startDelayMultiplier = pMain.startDelayMultiplier;
        mainModule.startLifetime = pMain.startLifetime.Deserialize();
        mainModule.startLifetimeMultiplier = pMain.startLifetimeMultiplier;
        mainModule.startRotation = pMain.startRotation.Deserialize();
        mainModule.startRotation3D = pMain.startRotation3D;
        mainModule.startRotationMultiplier = pMain.startRotationMultiplier;
        mainModule.startRotationX = pMain.startRotationX.Deserialize();
        mainModule.startRotationXMultiplier = pMain.startRotationXMultiplier;
        mainModule.startRotationY = pMain.startRotationY.Deserialize();
        mainModule.startRotationYMultiplier = pMain.startRotationYMultiplier;
        mainModule.startRotationZ = pMain.startRotationZ.Deserialize();
        mainModule.startRotationZMultiplier = pMain.startRotationZMultiplier;
        mainModule.startSize = pMain.startSize.Deserialize();
        mainModule.startSize3D = pMain.startSize3D;
        mainModule.startSizeMultiplier = pMain.startSizeMultiplier;
        mainModule.startSizeX = pMain.startSizeX.Deserialize();
        mainModule.startSizeXMultiplier = pMain.startSizeXMultiplier;
        mainModule.startSizeY = pMain.startSizeY.Deserialize();
        mainModule.startSizeYMultiplier = pMain.startSizeYMultiplier;
        mainModule.startSizeZ = pMain.startSizeZ.Deserialize();
        mainModule.startSizeZMultiplier = pMain.startSizeZMultiplier;
        mainModule.startSpeed = pMain.startSpeed.Deserialize();
        mainModule.startSpeedMultiplier = pMain.startSpeedMultiplier;
        mainModule.stopAction = pMain.stopAction;
        mainModule.useUnscaledTime = pMain.useUnscaledTime;
        #endregion

        #region Emission Module
        ParticleSystem.EmissionModule emissionModule = _particleSystem.emission;
        emissionModule.burstCount = pEmission.burstCount;
        emissionModule.enabled = pEmission.enabled;
        emissionModule.rateOverDistance = pEmission.rateOverDistance.Deserialize();
        emissionModule.rateOverDistanceMultiplier = pEmission.rateOverDistanceMultiplier;
        emissionModule.rateOverTime = pEmission.rateOverTime.Deserialize();
        emissionModule.rateOverTimeMultiplier = pEmission.rateOverTimeMultiplier;
        //pEmission.DeserializeBursts(ref emissionModule);
        #endregion

        #region Shape Module
        ParticleSystem.ShapeModule shapeModule = _particleSystem.shape;
        shapeModule.alignToDirection = pShapeModule.alignToDirection;
        shapeModule.angle = pShapeModule.angle;
        shapeModule.arc = pShapeModule.arc;
        shapeModule.arcMode = pShapeModule.arcMode;
        shapeModule.arcSpeed = pShapeModule.arcSpeed.Deserialize();
        shapeModule.arcSpeedMultiplier = pShapeModule.arcSpeedMultiplier;
        shapeModule.arcSpread = pShapeModule.arcSpread;
        shapeModule.scale = pShapeModule.scale.Deserialize();
        shapeModule.boxThickness = pShapeModule.boxThickness.Deserialize();
        shapeModule.donutRadius = pShapeModule.donutRadius;
        shapeModule.enabled = pShapeModule.enabled;
        shapeModule.length = pShapeModule.length;
        shapeModule.mesh = pShapeModule.mesh.Deserialize();
        shapeModule.meshMaterialIndex = pShapeModule.meshMaterialIndex;
        shapeModule.meshRenderer = pShapeModule.meshRenderer.Deserialize();
        shapeModule.meshShapeType = pShapeModule.meshShapeType;
        shapeModule.meshSpawnMode = pShapeModule.meshSpawnMode;
        shapeModule.meshSpawnSpeed = pShapeModule.meshSpawnSpeed.Deserialize();
        shapeModule.meshSpawnSpeedMultiplier = pShapeModule.meshSpawnSpeedMultiplier;
        shapeModule.meshSpawnSpread = pShapeModule.meshSpawnSpread;
        shapeModule.normalOffset = pShapeModule.normalOffset;
        shapeModule.position = pShapeModule.position.Deserialize();
        shapeModule.radius = pShapeModule.radius;
        shapeModule.radiusMode = pShapeModule.radiusMode;
        shapeModule.radiusSpeed = pShapeModule.radiusSpeed.Deserialize();
        shapeModule.radiusSpeedMultiplier = pShapeModule.radiusSpeedMultiplier;
        shapeModule.radiusSpread = pShapeModule.radiusSpread;
        shapeModule.radiusThickness = pShapeModule.radiusThickness;
        shapeModule.randomDirectionAmount = pShapeModule.randomDirectionAmount;
        shapeModule.randomPositionAmount = pShapeModule.randomPositionAmount;
        shapeModule.rotation = pShapeModule.rotation.Deserialize();
        shapeModule.scale = pShapeModule.scale.Deserialize();
        shapeModule.shapeType = pShapeModule.shapeType;
        shapeModule.skinnedMeshRenderer = pShapeModule.skinnedMeshRenderer.Deserialize();
        shapeModule.sphericalDirectionAmount = pShapeModule.sphericalDirectionAmount;
        //shapeModule.sprite = pShapeModule.sprite;
        //shapeModule.spriteRenderer = pShapeModule.spriteRenderer;
        //shapeModule.texture = pShapeModule.texture;
        shapeModule.textureAlphaAffectsParticles = pShapeModule.textureAlphaAffectsParticles;
        shapeModule.textureBilinearFiltering = pShapeModule.textureBilinearFiltering;
        shapeModule.textureClipChannel = pShapeModule.textureClipChannel;
        shapeModule.textureClipThreshold = pShapeModule.textureClipThreshold;
        shapeModule.textureColorAffectsParticles = pShapeModule.textureColorAffectsParticles;
        shapeModule.textureUVChannel = pShapeModule.textureUVChannel;
        shapeModule.useMeshColors = pShapeModule.useMeshColors;
        shapeModule.useMeshMaterialIndex = pShapeModule.useMeshMaterialIndex;
        #endregion

        #region Velocity over Lifetime Module
        ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = _particleSystem.velocityOverLifetime;
        velocityOverLifetimeModule.enabled = pVelocityOverLifetimeModule.enabled;
        velocityOverLifetimeModule.orbitalOffsetX = pVelocityOverLifetimeModule.orbitalOffsetX.Deserialize();
        velocityOverLifetimeModule.orbitalOffsetXMultiplier = pVelocityOverLifetimeModule.orbitalOffsetXMultiplier;
        velocityOverLifetimeModule.orbitalOffsetY = pVelocityOverLifetimeModule.orbitalOffsetY.Deserialize();
        velocityOverLifetimeModule.orbitalOffsetYMultiplier = pVelocityOverLifetimeModule.orbitalOffsetYMultiplier;
        velocityOverLifetimeModule.orbitalOffsetZ = pVelocityOverLifetimeModule.orbitalOffsetZ.Deserialize();
        velocityOverLifetimeModule.orbitalOffsetZMultiplier = pVelocityOverLifetimeModule.orbitalOffsetZMultiplier;
        velocityOverLifetimeModule.orbitalX = pVelocityOverLifetimeModule.orbitalX.Deserialize();
        velocityOverLifetimeModule.orbitalXMultiplier = pVelocityOverLifetimeModule.orbitalXMultiplier;
        velocityOverLifetimeModule.orbitalY = pVelocityOverLifetimeModule.orbitalY.Deserialize();
        velocityOverLifetimeModule.orbitalYMultiplier = pVelocityOverLifetimeModule.orbitalYMultiplier;
        velocityOverLifetimeModule.orbitalZ = pVelocityOverLifetimeModule.orbitalZ.Deserialize();
        velocityOverLifetimeModule.orbitalZMultiplier = pVelocityOverLifetimeModule.orbitalZMultiplier;
        velocityOverLifetimeModule.radial = pVelocityOverLifetimeModule.radial.Deserialize();
        velocityOverLifetimeModule.radialMultiplier = pVelocityOverLifetimeModule.radialMultiplier;
        velocityOverLifetimeModule.space = pVelocityOverLifetimeModule.space;
        velocityOverLifetimeModule.speedModifier = pVelocityOverLifetimeModule.speedModifier.Deserialize();
        velocityOverLifetimeModule.speedModifierMultiplier = pVelocityOverLifetimeModule.speedModifierMultiplier;
        velocityOverLifetimeModule.x = pVelocityOverLifetimeModule.x.Deserialize();
        velocityOverLifetimeModule.xMultiplier = pVelocityOverLifetimeModule.xMultiplier;
        velocityOverLifetimeModule.y = pVelocityOverLifetimeModule.y.Deserialize();
        velocityOverLifetimeModule.yMultiplier = pVelocityOverLifetimeModule.yMultiplier;
        velocityOverLifetimeModule.z = pVelocityOverLifetimeModule.z.Deserialize();
        velocityOverLifetimeModule.zMultiplier = pVelocityOverLifetimeModule.zMultiplier;
        #endregion

        #region Noise Module
        ParticleSystem.NoiseModule noiseModule = _particleSystem.noise;
        noiseModule.damping = pNoiseModule.damping;
        noiseModule.enabled = pNoiseModule.enabled;
        noiseModule.frequency = pNoiseModule.frequency;
        noiseModule.octaveCount = pNoiseModule.octaveCount;
        noiseModule.octaveMultiplier = pNoiseModule.octaveMultiplier;
        noiseModule.octaveScale = pNoiseModule.octaveScale;
        noiseModule.positionAmount = pNoiseModule.positionAmount.Deserialize();
        noiseModule.quality = pNoiseModule.quality;
        noiseModule.remap = pNoiseModule.remap.Deserialize();
        noiseModule.remapEnabled = pNoiseModule.remapEnabled;
        noiseModule.remapMultiplier = pNoiseModule.remapMultiplier;
        noiseModule.remapX = pNoiseModule.remapX.Deserialize();
        noiseModule.remapXMultiplier = pNoiseModule.remapXMultiplier;
        noiseModule.remapY = pNoiseModule.remapY.Deserialize();
        noiseModule.remapYMultiplier = pNoiseModule.remapYMultiplier;
        noiseModule.remapZ = pNoiseModule.remapZ.Deserialize();
        noiseModule.remapZMultiplier = pNoiseModule.remapZMultiplier;
        noiseModule.rotationAmount = pNoiseModule.rotationAmount.Deserialize();
        noiseModule.scrollSpeed = pNoiseModule.scrollSpeed.Deserialize();
        noiseModule.scrollSpeedMultiplier = pNoiseModule.scrollSpeedMultiplier;
        noiseModule.separateAxes = pNoiseModule.separateAxes;
        noiseModule.sizeAmount = pNoiseModule.sizeAmount.Deserialize();
        noiseModule.strength = pNoiseModule.strength.Deserialize();
        noiseModule.strengthMultiplier = pNoiseModule.strengthMultiplier;
        noiseModule.strengthX = pNoiseModule.strengthX.Deserialize();
        noiseModule.strengthXMultiplier = pNoiseModule.strengthXMultiplier;
        noiseModule.strengthY = pNoiseModule.strengthY.Deserialize();
        noiseModule.strengthYMultiplier = pNoiseModule.strengthYMultiplier;
        noiseModule.strengthZ = pNoiseModule.strengthZ.Deserialize();
        noiseModule.strengthZMultiplier = pNoiseModule.strengthZMultiplier;
        #endregion

        #region Limit Velocity OverLifetime Module
        ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetimeModule = _particleSystem.limitVelocityOverLifetime;
        limitVelocityOverLifetimeModule.dampen = pLimitVelocityOverLifetimeModule.dampen;
        limitVelocityOverLifetimeModule.drag = pLimitVelocityOverLifetimeModule.drag.Deserialize();
        limitVelocityOverLifetimeModule.dragMultiplier = pLimitVelocityOverLifetimeModule.dragMultiplier;
        limitVelocityOverLifetimeModule.enabled = pLimitVelocityOverLifetimeModule.enabled;
        limitVelocityOverLifetimeModule.limit = pLimitVelocityOverLifetimeModule.limit.Deserialize();
        limitVelocityOverLifetimeModule.limitMultiplier = pLimitVelocityOverLifetimeModule.limitMultiplier;
        limitVelocityOverLifetimeModule.limitX = pLimitVelocityOverLifetimeModule.limitX.Deserialize();
        limitVelocityOverLifetimeModule.limitXMultiplier = pLimitVelocityOverLifetimeModule.limitXMultiplier;
        limitVelocityOverLifetimeModule.limitY = pLimitVelocityOverLifetimeModule.limitY.Deserialize();
        limitVelocityOverLifetimeModule.limitYMultiplier = pLimitVelocityOverLifetimeModule.limitYMultiplier;
        limitVelocityOverLifetimeModule.limitZ = pLimitVelocityOverLifetimeModule.limitZ.Deserialize();
        limitVelocityOverLifetimeModule.limitZMultiplier = pLimitVelocityOverLifetimeModule.limitZMultiplier;
        limitVelocityOverLifetimeModule.multiplyDragByParticleSize = pLimitVelocityOverLifetimeModule.multiplyDragByParticleSize;
        limitVelocityOverLifetimeModule.multiplyDragByParticleVelocity = pLimitVelocityOverLifetimeModule.multiplyDragByParticleVelocity;
        limitVelocityOverLifetimeModule.separateAxes = pLimitVelocityOverLifetimeModule.separateAxes;
        limitVelocityOverLifetimeModule.space = pLimitVelocityOverLifetimeModule.space;
        #endregion

        #region Inherit Velocity Module
        ParticleSystem.InheritVelocityModule inheritVelocity = _particleSystem.inheritVelocity;
        inheritVelocity.curve = pInheritVelocityModule.curve.Deserialize();
        inheritVelocity.curveMultiplier = pInheritVelocityModule.curveMultiplier;
        inheritVelocity.enabled = pInheritVelocityModule.enabled;
        inheritVelocity.mode = pInheritVelocityModule.mode;
        #endregion

        #region Force Over Lifetime Module
        ParticleSystem.ForceOverLifetimeModule forceOverLifetime = _particleSystem.forceOverLifetime;
        forceOverLifetime.enabled = pForceOverLifetimeModule.enabled;
        forceOverLifetime.randomized = pForceOverLifetimeModule.randomized;
        forceOverLifetime.space = pForceOverLifetimeModule.space;
        forceOverLifetime.x = pForceOverLifetimeModule.x.Deserialize();
        forceOverLifetime.xMultiplier = pForceOverLifetimeModule.xMultiplier;
        forceOverLifetime.y = pForceOverLifetimeModule.y.Deserialize();
        forceOverLifetime.yMultiplier = pForceOverLifetimeModule.yMultiplier;
        forceOverLifetime.z = pForceOverLifetimeModule.z.Deserialize();
        forceOverLifetime.zMultiplier = pForceOverLifetimeModule.zMultiplier;
        #endregion

        #region Color Over Lifetime Module
        ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = _particleSystem.colorOverLifetime;
        colorOverLifetimeModule.color = pColourOverLifetimeModule.color.Deserialize();
        colorOverLifetimeModule.enabled = pColourOverLifetimeModule.enabled;
        #endregion

        #region Color By Speed Module
        ParticleSystem.ColorBySpeedModule colorBySpeedMocule = _particleSystem.colorBySpeed;
        colorBySpeedMocule.color = pColorBySpeedModule.color.Deserialize();
        colorBySpeedMocule.enabled = pColorBySpeedModule.enabled;
        colorBySpeedMocule.range = pColorBySpeedModule.range.Deserialize();
        #endregion

        #region Size Over Lifetime Module
        ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = _particleSystem.sizeOverLifetime;
        sizeOverLifetimeModule.enabled = pSizeOverLifetime.enabled;
        sizeOverLifetimeModule.separateAxes = pSizeOverLifetime.separateAxes;
        sizeOverLifetimeModule.size = pSizeOverLifetime.size.Deserialize();
        sizeOverLifetimeModule.sizeMultiplier = pSizeOverLifetime.sizeMultiplier;
        sizeOverLifetimeModule.x = pSizeOverLifetime.x.Deserialize();
        sizeOverLifetimeModule.xMultiplier = pSizeOverLifetime.xMultiplier;
        sizeOverLifetimeModule.y = pSizeOverLifetime.y.Deserialize();
        sizeOverLifetimeModule.yMultiplier = pSizeOverLifetime.yMultiplier;
        sizeOverLifetimeModule.z = pSizeOverLifetime.z.Deserialize();
        sizeOverLifetimeModule.zMultiplier = pSizeOverLifetime.zMultiplier;
        #endregion

        #region Size By Speed Module
        ParticleSystem.SizeBySpeedModule sizeBySpeedModule = _particleSystem.sizeBySpeed;
        sizeBySpeedModule.enabled = pSizeBySpeedModule.enabled;
        sizeBySpeedModule.range = pSizeBySpeedModule.range.Deserialize();
        sizeBySpeedModule.separateAxes = pSizeBySpeedModule.separateAxes;
        sizeBySpeedModule.size = pSizeBySpeedModule.size.Deserialize();
        sizeBySpeedModule.sizeMultiplier = pSizeBySpeedModule.sizeMultiplier;
        sizeBySpeedModule.x = pSizeBySpeedModule.x.Deserialize();
        sizeBySpeedModule.xMultiplier = pSizeBySpeedModule.xMultiplier;
        sizeBySpeedModule.y = pSizeBySpeedModule.y.Deserialize();
        sizeBySpeedModule.yMultiplier = pSizeBySpeedModule.yMultiplier;
        sizeBySpeedModule.z = pSizeBySpeedModule.z.Deserialize();
        sizeBySpeedModule.zMultiplier = pSizeBySpeedModule.zMultiplier;
        #endregion

        #region Rotation Over Lifetime Module
        ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = _particleSystem.rotationOverLifetime;
        rotationOverLifetimeModule.enabled = pRotationOverLifetimeModule.enabled;
        rotationOverLifetimeModule.separateAxes = pRotationOverLifetimeModule.separateAxes;
        rotationOverLifetimeModule.x = pRotationOverLifetimeModule.x.Deserialize();
        rotationOverLifetimeModule.xMultiplier = pRotationOverLifetimeModule.xMultiplier;
        rotationOverLifetimeModule.y = pRotationOverLifetimeModule.y.Deserialize();
        rotationOverLifetimeModule.yMultiplier = pRotationOverLifetimeModule.yMultiplier;
        rotationOverLifetimeModule.z = pRotationOverLifetimeModule.z.Deserialize();
        rotationOverLifetimeModule.zMultiplier = pRotationOverLifetimeModule.zMultiplier;
        #endregion

        #region Rotation By Speed Module
        ParticleSystem.RotationBySpeedModule rotationBySpeedModule = _particleSystem.rotationBySpeed;
        rotationBySpeedModule.enabled = pRotationBySpeedModule.enabled;
        rotationBySpeedModule.range = pRotationBySpeedModule.range.Deserialize();
        rotationBySpeedModule.x = pRotationBySpeedModule.x.Deserialize();
        rotationBySpeedModule.xMultiplier = pRotationBySpeedModule.xMultiplier;
        rotationBySpeedModule.y = pRotationBySpeedModule.y.Deserialize();
        rotationBySpeedModule.yMultiplier = pRotationBySpeedModule.yMultiplier;
        rotationBySpeedModule.z = pRotationBySpeedModule.z.Deserialize();
        rotationBySpeedModule.zMultiplier = pRotationBySpeedModule.zMultiplier;
        #endregion

        #region External Forces Module
        ParticleSystem.ExternalForcesModule externalForcesModule = _particleSystem.externalForces;
        externalForcesModule.enabled = pExternalForcesModule.enabled;
        //externalForcesModule.influenceCount = pExternalForcesModule.influenceCount;
        externalForcesModule.influenceFilter = pExternalForcesModule.influenceFilter;
        externalForcesModule.influenceMask = pExternalForcesModule.influenceMask;
        externalForcesModule.multiplier = pExternalForcesModule.multiplier;
        externalForcesModule.multiplierCurve = pExternalForcesModule.multiplierCurve.Deserialize();
        #endregion

        #region Collision Module
        ParticleSystem.CollisionModule collisionModule = _particleSystem.collision;
        collisionModule.bounce = pCollisionModule.bounce.Deserialize();
        collisionModule.bounceMultiplier = pCollisionModule.bounceMultiplier;
        collisionModule.colliderForce = pCollisionModule.colliderForce;
        collisionModule.collidesWith = pCollisionModule.collidesWith;
        collisionModule.dampen = pCollisionModule.dampen.Deserialize();
        collisionModule.dampenMultiplier = pCollisionModule.dampenMultiplier;
        collisionModule.enabled = pCollisionModule.enabled;
        collisionModule.enableDynamicColliders = pCollisionModule.enableDynamicColliders;
        collisionModule.lifetimeLoss = pCollisionModule.lifetimeLoss.Deserialize();
        collisionModule.lifetimeLossMultiplier = pCollisionModule.lifetimeLossMultiplier;
        collisionModule.maxCollisionShapes = pCollisionModule.maxCollisionShapes;
        collisionModule.maxKillSpeed = pCollisionModule.maxKillSpeed;
        //collisionModule.maxPlaneCount = pCollisionModule.maxPlaneCount;
        collisionModule.minKillSpeed = pCollisionModule.minKillSpeed;
        collisionModule.mode = pCollisionModule.mode;
        collisionModule.multiplyColliderForceByCollisionAngle = pCollisionModule.multiplyColliderForceByCollisionAngle;
        collisionModule.multiplyColliderForceByParticleSize = pCollisionModule.multiplyColliderForceByParticleSize;
        collisionModule.multiplyColliderForceByParticleSpeed = pCollisionModule.multiplyColliderForceByParticleSpeed;
        collisionModule.quality = pCollisionModule.quality;
        collisionModule.radiusScale = pCollisionModule.radiusScale;
        collisionModule.sendCollisionMessages = pCollisionModule.sendCollisionMessages;
        collisionModule.type = pCollisionModule.type;
        collisionModule.voxelSize = pCollisionModule.voxelSize;
        #endregion

        #region Trigger Module
        ParticleSystem.TriggerModule triggerModule = _particleSystem.trigger;
        triggerModule.enabled = pTriggerModule.enabled;
        triggerModule.enter = pTriggerModule.enter;
        triggerModule.exit = pTriggerModule.exit;
        triggerModule.inside = pTriggerModule.inside;
        //triggerModule.maxColliderCount = pTriggerModule.maxColliderCount;
        triggerModule.outside = pTriggerModule.outside;
        triggerModule.radiusScale = pTriggerModule.radiusScale;
        #endregion

        #region Sub Emitters Module
        ParticleSystem.SubEmittersModule subEmittersModule = _particleSystem.subEmitters;
        subEmittersModule.enabled = pSubEmittersModule.enabled;
        //subEmittersModule.subEmittersCount = _particleSystem.subEmitters.subEmittersCount;
        //pSubEmittersModule.DeserializeSubEmitters(ref subEmittersModule);
        #endregion

        #region Texture Sheet Animation Module
        ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = _particleSystem.textureSheetAnimation;
        textureSheetAnimationModule.animation = pTextureSheetAnimationModule.animation;
        textureSheetAnimationModule.cycleCount = pTextureSheetAnimationModule.cycleCount;
        textureSheetAnimationModule.enabled = pTextureSheetAnimationModule.enabled;
        textureSheetAnimationModule.fps = pTextureSheetAnimationModule.fps;
        textureSheetAnimationModule.frameOverTime = pTextureSheetAnimationModule.frameOverTime.Deserialize();
        textureSheetAnimationModule.frameOverTimeMultiplier = pTextureSheetAnimationModule.frameOverTimeMultiplier;
        textureSheetAnimationModule.mode = pTextureSheetAnimationModule.mode;
        textureSheetAnimationModule.numTilesX = pTextureSheetAnimationModule.numTilesX;
        textureSheetAnimationModule.numTilesY = pTextureSheetAnimationModule.numTilesY;
        textureSheetAnimationModule.rowIndex = pTextureSheetAnimationModule.rowIndex;
        textureSheetAnimationModule.rowMode = pTextureSheetAnimationModule.rowMode;
        textureSheetAnimationModule.speedRange = pTextureSheetAnimationModule.speedRange.Deserialize();
        //textureSheetAnimationModule.spriteCount = pTextureSheetAnimationModule.spriteCount;
        textureSheetAnimationModule.startFrame = pTextureSheetAnimationModule.startFrame.Deserialize();
        textureSheetAnimationModule.startFrameMultiplier = pTextureSheetAnimationModule.startFrameMultiplier;
        textureSheetAnimationModule.timeMode = pTextureSheetAnimationModule.timeMode;
        textureSheetAnimationModule.uvChannelMask = pTextureSheetAnimationModule.uvChannelMask;
        #endregion

        #region Lights Module
        ParticleSystem.LightsModule lightsModule = _particleSystem.lights;
        lightsModule.alphaAffectsIntensity = pLightsModule.alphaAffectsIntensity;
        lightsModule.enabled = pLightsModule.enabled;
        lightsModule.intensity = pLightsModule.intensity.Deserialize();
        lightsModule.intensityMultiplier = pLightsModule.intensityMultiplier;
        //lightsModule.light = pLightsModule.light;
        lightsModule.maxLights = pLightsModule.maxLights;
        lightsModule.range = pLightsModule.range.Deserialize();
        lightsModule.rangeMultiplier = pLightsModule.rangeMultiplier;
        lightsModule.ratio = pLightsModule.ratio;
        lightsModule.sizeAffectsRange = pLightsModule.sizeAffectsRange;
        lightsModule.useParticleColor = pLightsModule.useParticleColor;
        lightsModule.useRandomDistribution = pLightsModule.useRandomDistribution;
        #endregion

        #region Trails Module
        ParticleSystem.TrailModule trailsModule = _particleSystem.trails;
        trailsModule.attachRibbonsToTransform = pTrailsModule.attachRibbonsToTransform;
        trailsModule.colorOverLifetime = pTrailsModule.colorOverLifetime.Deserialize();
        trailsModule.colorOverTrail = pTrailsModule.colorOverTrail.Deserialize();
        trailsModule.dieWithParticles = pTrailsModule.dieWithParticles;
        trailsModule.enabled = pTrailsModule.enabled;
        trailsModule.generateLightingData = pTrailsModule.generateLightingData;
        trailsModule.inheritParticleColor = pTrailsModule.inheritParticleColor;
        trailsModule.lifetime = pTrailsModule.lifetime.Deserialize();
        trailsModule.lifetimeMultiplier = pTrailsModule.lifetimeMultiplier;
        trailsModule.minVertexDistance = pTrailsModule.minVertexDistance;
        trailsModule.mode = pTrailsModule.mode;
        trailsModule.ratio = pTrailsModule.ratio;
        trailsModule.ribbonCount = pTrailsModule.ribbonCount;
        trailsModule.shadowBias = pTrailsModule.shadowBias;
        trailsModule.sizeAffectsLifetime = pTrailsModule.sizeAffectsLifetime;
        trailsModule.sizeAffectsWidth = pTrailsModule.sizeAffectsWidth;
        trailsModule.splitSubEmitterRibbons = pTrailsModule.splitSubEmitterRibbons;
        trailsModule.textureMode = pTrailsModule.textureMode;
        trailsModule.widthOverTrail = pTrailsModule.widthOverTrail.Deserialize();
        trailsModule.widthOverTrailMultiplier = pTrailsModule.widthOverTrailMultiplier;
        trailsModule.worldSpace = pTrailsModule.worldSpace;
        #endregion

        #region Custom Data Module
        ParticleSystem.CustomDataModule customDataModule = _particleSystem.customData;
        customDataModule.enabled = pCustomDataModule.enabled;
        #endregion

        //Particle System Renderer (Handle particle renderer here in the future)
        //_particleSystem.GetComponent<ParticleSystemRenderer>()


        if (isPlaying == true)
            _particleSystem.Play();
    }
}
#endregion
