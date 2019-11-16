using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class STransform
{
    public SVector3 localPosition = new SVector3();
    public SQuaternion localRotation = new SQuaternion();
    public SVector3 localScale = new SVector3();

    public static explicit operator STransform(Transform _trans)
    {
        STransform _sTrans = new STransform();
        _sTrans.localPosition = _trans.localPosition.Serialize();
        _sTrans.localRotation = _trans.localRotation.Serialize();
        _sTrans.localScale = _trans.localScale.Serialize();
        return _sTrans;
    }

    public static explicit operator Transform(STransform _sTrans)
    {
        Transform _trans = new RectTransform();
        _trans.localPosition = _sTrans.localPosition.Deserialize();
        _trans.localRotation = _sTrans.localRotation.Deserialize();
        _trans.localScale = _sTrans.localScale.Deserialize();
        return _trans;
    }
}

public static class TransformExtensionMethods
{
    #region Serialization
    public static STransform Serialize(this Transform _trans)
    {
        if (_trans == null)
            return null;

        STransform returnVal = new STransform();

        returnVal.localPosition = _trans.localPosition.Serialize();
        returnVal.localRotation = _trans.localRotation.Serialize();
        returnVal.localScale = _trans.localScale.Serialize();

        return returnVal;
    }
    #endregion

    #region Deserialization
    public static Transform Deserialize(this STransform _trans, ref GameObject _providedObject)
    {
        if (_trans == null)
            return null;

        Transform returnVal = _providedObject.GetComponent<Transform>();

        returnVal.localPosition = _trans.localPosition.Deserialize();
        returnVal.localRotation = _trans.localRotation.Deserialize();
        returnVal.localScale = _trans.localScale.Deserialize();

        return returnVal;
    }

    public static Transform Deserialize(this STransform _trans)
    {
        return (Transform)_trans;
    }
    #endregion
}