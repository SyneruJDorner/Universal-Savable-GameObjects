using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SProjector
{
    public bool ExistsOnObject = false;
    public bool Enabled;

    public float aspectRatio;
    public float farClipPlane;
    public float fieldOfView;
    public float nearClipPlane;
    public bool orthographic;
    public float orthographicSize;
    //public Material material;
    public int ignoreLayers;
}

public static class ProjectorExtensionMethods
{
    #region Serialization
    public static SProjector Serialize(this Projector _projector)
    {
        if (_projector == null)
            return null;

        SProjector returnVal = new SProjector
        {
            ExistsOnObject = (_projector == null) ? false : true,
            Enabled = _projector.enabled,

            aspectRatio = _projector.aspectRatio,
            farClipPlane = _projector.farClipPlane,
            fieldOfView = _projector.fieldOfView,
            nearClipPlane = _projector.nearClipPlane,
            orthographic = _projector.orthographic,
            orthographicSize = _projector.orthographicSize,
            //material = _projector.material,
            ignoreLayers = _projector.ignoreLayers
        };

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static Projector Deserialize(this SProjector _projector, ref GameObject _gameObject)
    {
        if (_projector.ExistsOnObject == false)
            return null;

        Projector returnVal = _gameObject.GetComponent<Projector>();

        returnVal.enabled = _projector.Enabled;
        returnVal.aspectRatio = _projector.aspectRatio;
        returnVal.farClipPlane = _projector.farClipPlane;
        returnVal.fieldOfView = _projector.fieldOfView;
        returnVal.nearClipPlane = _projector.nearClipPlane;
        returnVal.orthographic = _projector.orthographic;
        returnVal.orthographicSize = _projector.orthographicSize;
        //returnVal.material = _projector.material;
        returnVal.ignoreLayers = _projector.ignoreLayers;
        return returnVal;
    }
    #endregion
}