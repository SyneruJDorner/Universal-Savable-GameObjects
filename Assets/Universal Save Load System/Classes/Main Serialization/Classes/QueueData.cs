using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class QueueData
{
    public static void QueueItemToSave(GameObject saveObject, string serializedGuid)
    {
        SerializableData serializableData = new SerializableData();

        #region Serilaize Object
        #region Serialize Unity classes and types
        serializableData.ID =                                           DataSerialization.Serialize(serializedGuid);
        serializableData.activeInHierarchy =                            DataSerialization.Serialize(saveObject.activeInHierarchy);
        serializableData.unitySerializableData.sTransform =             DataSerialization.Serialize(saveObject.transform.Serialize());
        serializableData.unitySerializableData.sCamera =                (saveObject.GetComponent<Camera>() is var cam && cam != null) ?                                                     DataSerialization.Serialize(cam.Serialize()) : null;

        #region Audio
        serializableData.unitySerializableData.sAudioChorusFilter =     (saveObject.GetComponent<AudioChorusFilter>() is var audioChorusFilter && audioChorusFilter != null) ?              DataSerialization.Serialize(audioChorusFilter.Serialize()) : null;
        serializableData.unitySerializableData.sAudioDistortionFilter = (saveObject.GetComponent<AudioDistortionFilter>() is var audioDistortionFilter && audioDistortionFilter != null) ?  DataSerialization.Serialize(audioDistortionFilter.Serialize()) : null;
        serializableData.unitySerializableData.sAudioEchoFilter =       (saveObject.GetComponent<AudioEchoFilter>() is var audioEchoFilter && audioEchoFilter != null) ?                    DataSerialization.Serialize(audioEchoFilter.Serialize()) : null;
        serializableData.unitySerializableData.sAudioHighPassFilter =   (saveObject.GetComponent<AudioHighPassFilter>() is var audioHighPassFilter && audioHighPassFilter != null) ?        DataSerialization.Serialize(audioHighPassFilter.Serialize()) : null;
        serializableData.unitySerializableData.sAudioListener =         (saveObject.GetComponent<AudioListener>() is var audioListener && audioListener != null) ?                          DataSerialization.Serialize(audioListener.Serialize()) : null;
        serializableData.unitySerializableData.sAudioLowPassFilter =    (saveObject.GetComponent<AudioLowPassFilter>() is var audioLowPassFilter && audioLowPassFilter != null) ?           DataSerialization.Serialize(audioLowPassFilter.Serialize()) : null;
        serializableData.unitySerializableData.sAudioReverbFilter =     (saveObject.GetComponent<AudioReverbFilter>() is var audioReverbFilter && audioReverbFilter != null) ?              DataSerialization.Serialize(audioReverbFilter.Serialize()) : null;
        serializableData.unitySerializableData.sAudioReverbZone =       (saveObject.GetComponent<AudioReverbZone>() is var audioReverbZone && audioReverbZone != null) ?                    DataSerialization.Serialize(audioReverbZone.Serialize()) : null;
        serializableData.unitySerializableData.sAudioSource =           (saveObject.GetComponent<AudioSource>() is var audioSource && audioSource != null) ?                                DataSerialization.Serialize(audioSource.Serialize()) : null;
        #endregion

        #region Effects
        serializableData.unitySerializableData.sLensFlare =             (saveObject.GetComponent<LensFlare>() is var lensFlare && lensFlare != null) ?                                      DataSerialization.Serialize(lensFlare.Serialize()) : null;
        serializableData.unitySerializableData.sLineRenderer =          (saveObject.GetComponent<LineRenderer>() is var lineRenderer && lineRenderer != null) ?                             DataSerialization.Serialize(lineRenderer.Serialize()) : null;
        serializableData.unitySerializableData.sParticleSystem =        (saveObject.GetComponent<ParticleSystem>() is var particleSystem && particleSystem != null) ?                       DataSerialization.Serialize(particleSystem.Serialize()) : null;
        serializableData.unitySerializableData.sProjector =             (saveObject.GetComponent<Projector>() is var projector && projector != null) ?                                      DataSerialization.Serialize(projector.Serialize()) : null;
        serializableData.unitySerializableData.sTrailRenderer =         (saveObject.GetComponent<TrailRenderer>() is var trailRenderer && trailRenderer != null) ?                          DataSerialization.Serialize(trailRenderer.Serialize()) : null;
        #endregion
        #endregion

        #region Serialize User Defined Classes
        MonoBehaviour[] saveableScripts = saveObject.GetComponents<MonoBehaviour>();

        foreach (var monoItem in saveableScripts)
        {
            if (monoItem is IUniversalSerializedPersistenceSystem == false)
                continue;

            System.Type thisType = monoItem.GetType();
            MethodInfo theMethod = thisType.GetMethod("Serialize");
            object[] parameters = new object[1] { saveObject };
            serializableData.serializedScripts = (List<UserDefinedData>)theMethod.Invoke(monoItem, parameters);
            break;
        }
        #endregion
        #endregion

        #region Serilaize Objects Children
        QueueAllChildren(serializedGuid, saveObject.transform, saveObject.transform, ref serializableData);
        #endregion

        UniversalSerializedPersistenceSystem.serializableDataSet.data.Add(serializableData);
        saveObject.BroadcastMessage("SaveMessage", SendMessageOptions.DontRequireReceiver);
    }

    public static void QueueAllChildren(string serializedGuid, Transform rootParent, Transform parent, ref SerializableData serializableData)
    {
        foreach (Transform t in parent)
        {
            GameObject saveObject = t.gameObject;
            SerializableChildData serializableChildData = new SerializableChildData();

            #region Serialize Unity classes and types
            serializableChildData.rootParentID =                                    DataSerialization.Serialize(serializedGuid);
            serializableChildData.activeInHierarchy =                               DataSerialization.Serialize(saveObject.activeInHierarchy);
            serializableChildData.unitySerializableData.sTransform =                DataSerialization.Serialize(saveObject.transform.Serialize());
            serializableChildData.unitySerializableData.sCamera =                   (saveObject.GetComponent<Camera>() is var cam && cam != null) ?                                                     DataSerialization.Serialize(cam.Serialize()) : null;

            #region Audio
            serializableChildData.unitySerializableData.sAudioChorusFilter =        (saveObject.GetComponent<AudioChorusFilter>() is var audioChorusFilter && audioChorusFilter != null) ?              DataSerialization.Serialize(audioChorusFilter.Serialize()) : null;
            serializableChildData.unitySerializableData.sAudioDistortionFilter =    (saveObject.GetComponent<AudioDistortionFilter>() is var audioDistortionFilter && audioDistortionFilter != null) ?  DataSerialization.Serialize(audioDistortionFilter.Serialize()) : null;
            serializableChildData.unitySerializableData.sAudioEchoFilter =          (saveObject.GetComponent<AudioEchoFilter>() is var audioEchoFilter && audioEchoFilter != null) ?                    DataSerialization.Serialize(audioEchoFilter.Serialize()) : null;
            serializableChildData.unitySerializableData.sAudioHighPassFilter =      (saveObject.GetComponent<AudioHighPassFilter>() is var audioHighPassFilter && audioHighPassFilter != null) ?        DataSerialization.Serialize(audioHighPassFilter.Serialize()) : null;
            serializableChildData.unitySerializableData.sAudioListener =            (saveObject.GetComponent<AudioListener>() is var audioListener && audioListener != null) ?                          DataSerialization.Serialize(audioListener.Serialize()) : null;
            serializableChildData.unitySerializableData.sAudioLowPassFilter =       (saveObject.GetComponent<AudioLowPassFilter>() is var audioLowPassFilter && audioLowPassFilter != null) ?           DataSerialization.Serialize(audioLowPassFilter.Serialize()) : null;
            serializableChildData.unitySerializableData.sAudioReverbFilter =        (saveObject.GetComponent<AudioReverbFilter>() is var audioReverbFilter && audioReverbFilter != null) ?              DataSerialization.Serialize(audioReverbFilter.Serialize()) : null;
            serializableChildData.unitySerializableData.sAudioReverbZone =          (saveObject.GetComponent<AudioReverbZone>() is var audioReverbZone && audioReverbZone != null) ?                    DataSerialization.Serialize(audioReverbZone.Serialize()) : null;
            serializableChildData.unitySerializableData.sAudioSource =              (saveObject.GetComponent<AudioSource>() is var audioSource && audioSource != null) ?                                DataSerialization.Serialize(audioSource.Serialize()) : null;
            #endregion

            #region Effects
            serializableChildData.unitySerializableData.sLensFlare =                (saveObject.GetComponent<LensFlare>() is var lensFlare && lensFlare != null) ?                                      DataSerialization.Serialize(lensFlare.Serialize()) : null;
            serializableChildData.unitySerializableData.sLineRenderer =             (saveObject.GetComponent<LineRenderer>() is var lineRenderer && lineRenderer != null) ?                             DataSerialization.Serialize(lineRenderer.Serialize()) : null;
            serializableChildData.unitySerializableData.sParticleSystem =           (saveObject.GetComponent<ParticleSystem>() is var particleSystem && particleSystem != null) ?                       DataSerialization.Serialize(particleSystem.Serialize()) : null;
            serializableChildData.unitySerializableData.sProjector =                (saveObject.GetComponent<Projector>() is var projector && projector != null) ?                                      DataSerialization.Serialize(projector.Serialize()) : null;
            serializableChildData.unitySerializableData.sTrailRenderer =            (saveObject.GetComponent<TrailRenderer>() is var trailRenderer && trailRenderer != null) ?                          DataSerialization.Serialize(trailRenderer.Serialize()) : null;
            #endregion
            #endregion

            #region Serialize User Defined Classes
            MonoBehaviour[] saveableScripts = parent.GetComponents<MonoBehaviour>();

            foreach (var monoItem in saveableScripts)
            {
                if (monoItem is IUniversalSerializedPersistenceSystem == false)
                    continue;

                System.Type thisType = monoItem.GetType();
                MethodInfo theMethod = thisType.GetMethod("Serialize");
                object[] parameters = new object[1] { saveObject };
                serializableChildData.serializedScripts = (List<UserDefinedData>)theMethod.Invoke(monoItem, parameters);
                break;
            }
            #endregion

            serializableData.serializableChildData.Add(serializableChildData);
            QueueAllChildren(serializedGuid, rootParent, t, ref serializableData);
        }
    }

    public static void QueueItemToLoad(GameObject saveObject, string serializedGuid)
    {
        UniversalSerializedPersistenceSystem.gameObjectsDataSet.Add(new UniversalSerializedPersistenceSystem.QueuedItem() { ID = serializedGuid, saveObject = saveObject });
        saveObject.BroadcastMessage("SaveMessage", SendMessageOptions.DontRequireReceiver);
    }

    public static void DequeueAllChildren(Transform rootParent, Transform parent, SerializableData serializableData, ref int childIndex)
    {
        foreach (Transform t in parent)
        {
            if (serializableData.serializableChildData.Count == 0)
                break;

            SerializableChildData serializableChildData = serializableData.serializableChildData[++childIndex];
            GameObject currentObj = t.gameObject;

            #region Deserialize Unity classes and types
            #region Deserialize transform
            ((STransform)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sTransform)).Deserialize(ref currentObj);
            #endregion

            #region Deserialize Camera
            if (serializableChildData.unitySerializableData.sCamera.Length > 0)
                ((SCamera)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sCamera)).Deserialize(ref currentObj);
            #endregion

            #region Deserialize Audio
            if (serializableChildData.unitySerializableData.sAudioChorusFilter.Length > 0)
                ((SAudioChorusFilter)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sAudioChorusFilter)).Deserialize(ref currentObj);

            if (serializableChildData.unitySerializableData.sAudioDistortionFilter.Length > 0)
            {
                SAudioDistortionFilter sAudioDistortionFilter = (SAudioDistortionFilter)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sAudioDistortionFilter);
                sAudioDistortionFilter.Deserialize(ref currentObj);
            }

            if (serializableChildData.unitySerializableData.sAudioEchoFilter.Length > 0)
                ((SAudioEchoFilter)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sAudioEchoFilter)).Deserialize(ref currentObj);

            if (serializableChildData.unitySerializableData.sAudioHighPassFilter.Length > 0)
                ((SAudioHighPassFilter)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sAudioHighPassFilter)).Deserialize(ref currentObj);

            if (serializableChildData.unitySerializableData.sAudioListener.Length > 0)
                ((SAudioListener)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sAudioListener)).Deserialize(ref currentObj);

            if (serializableChildData.unitySerializableData.sAudioLowPassFilter.Length > 0)
                ((SAudioLowPassFilter)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sAudioLowPassFilter)).Deserialize(ref currentObj);

            if (serializableChildData.unitySerializableData.sAudioReverbFilter.Length > 0)
                ((SAudioReverbFilter)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sAudioReverbFilter)).Deserialize(ref currentObj);

            if (serializableChildData.unitySerializableData.sAudioReverbZone.Length > 0)
                ((SAudioReverbZone)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sAudioReverbZone)).Deserialize(ref currentObj);

            if (serializableChildData.unitySerializableData.sAudioSource.Length > 0)
                ((SAudioSource)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sAudioSource)).Deserialize(ref currentObj);
            #endregion

            #region Deserialize Effects
            if (serializableChildData.unitySerializableData.sLensFlare.Length > 0)
                ((SLensFlare)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sLensFlare)).Deserialize(ref currentObj);

            if (serializableChildData.unitySerializableData.sLineRenderer.Length > 0)
                ((SLineRenderer)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sLineRenderer)).Deserialize(ref currentObj);

            if (serializableChildData.unitySerializableData.sParticleSystem.Length > 0)
                ((SParticleSystem)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sParticleSystem)).Deserialize(ref currentObj);

            if (serializableChildData.unitySerializableData.sProjector.Length > 0)
                ((SProjector)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sProjector)).Deserialize(ref currentObj);

            if (serializableChildData.unitySerializableData.sTrailRenderer.Length > 0)
                ((STrailRenderer)DataDeserialization.Deserialize(serializableChildData.unitySerializableData.sTrailRenderer)).Deserialize(ref currentObj);
            #endregion
            #endregion

            #region Deserialize User Defined Classes
            MonoBehaviour[] saveableScripts = parent.gameObject.GetComponents<MonoBehaviour>();

            foreach (var monoItem in saveableScripts)
            {
                if (monoItem is IUniversalSerializedPersistenceSystem == false)
                    continue;

                System.Type thisType = monoItem.GetType();
                MethodInfo theMethod = thisType.GetMethod("Deserialize");
                object[] param = new object[2] {
                    serializableChildData.serializedScripts,
                    currentObj
                };

                theMethod.Invoke(monoItem, param);
                break;
            }
            #endregion

            #region Deserialize All Children
            DequeueAllChildren(rootParent, t, serializableData, ref childIndex);
            #endregion
        }
    }
}
