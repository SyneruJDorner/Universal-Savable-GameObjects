using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableData
{
    public byte[] ID;
    public byte[] activeInHierarchy;
    public UnitySerializableData unitySerializableData = new UnitySerializableData();//Serializable Data with Unity components on gameobjects
    public List<UserDefinedData> serializedScripts = new List<UserDefinedData>();//Serialize user scripts
    public List<SerializableChildData> serializableChildData = new List<SerializableChildData>();//Children info
}

[System.Serializable]
public class UnitySerializableData
{
    public byte[] sTransform;
    public byte[] sCamera;

    #region Audio
    public byte[] sAudioChorusFilter;
    public byte[] sAudioDistortionFilter;
    public byte[] sAudioEchoFilter;
    public byte[] sAudioHighPassFilter;
    public byte[] sAudioListener;
    public byte[] sAudioLowPassFilter;
    public byte[] sAudioReverbFilter;
    public byte[] sAudioReverbZone;
    public byte[] sAudioSource;
    #endregion

    #region Effects
    public byte[] sLensFlare;
    public byte[] sLineRenderer;
    public byte[] sParticleSystem;
    #endregion
}

[System.Serializable]
public class SerializableChildData
{
    public byte[] rootParentID;
    public byte[] activeInHierarchy;
    public UnitySerializableData unitySerializableData = new UnitySerializableData();
    public List<UserDefinedData> serializedScripts = new List<UserDefinedData>();
}

[System.Serializable]
public class UserDefinedData
{
    public string ID;
    public string scriptName;
    public byte[] serializedData;
}
