using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class SMesh
{
    public Matrix4x4[] bindposes;
    public BoneWeight[] boneWeights;
    public Bounds bounds;
    public SColor[] colors;
    public IndexFormat indexFormat;
    public string name;
    public SVector3[] normals;
    public SVector4[] tangents;
    public int[] triangles;
    public SVector2[] uv;
    public SVector2[] uv2;
    public SVector2[] uv3;
    public SVector2[] uv4;
    public SVector2[] uv5;
    public SVector2[] uv6;
    public SVector2[] uv7;
    public SVector2[] uv8;
    public SVector3[] vertices;
}

public static class MeshExtensionMethods
{
    #region Serialization
    public static SMesh Serialize(this Mesh _mesh)
    {
        if (_mesh == null)
            return null;

        SMesh returnVal = new SMesh
        {
            bindposes = _mesh.bindposes,
            boneWeights = _mesh.boneWeights,
            bounds = _mesh.bounds,
            colors = _mesh.colors.Serialize(),
            indexFormat = _mesh.indexFormat,
            name = _mesh.name,
            normals = _mesh.normals.Serialize(),
            tangents = _mesh.tangents.Serialize(),
            uv = _mesh.uv.Serialize(),
            uv2 = _mesh.uv2.Serialize(),
            uv3 = _mesh.uv3.Serialize(),
            uv4 = _mesh.uv4.Serialize(),
            uv5 = _mesh.uv5.Serialize(),
            uv6 = _mesh.uv6.Serialize(),
            uv7 = _mesh.uv7.Serialize(),
            uv8 = _mesh.uv8.Serialize(),
            vertices = _mesh.vertices.Serialize()
        };

        //Do triangles still aka mesh
        return returnVal;
    }

    public static SMesh[] Serialize(this Mesh[] _mesh)
    {
        if (_mesh == null)
            return null;

        List<SMesh> returnVal = new List<SMesh>();

        for (int i = 0; i < _mesh.Length; i++)
        {
            returnVal.Add(new SMesh
            {
                bindposes = _mesh[i].bindposes,
                boneWeights = _mesh[i].boneWeights,
                bounds = _mesh[i].bounds,
                colors = _mesh[i].colors.Serialize(),
                indexFormat = _mesh[i].indexFormat,
                name = _mesh[i].name,
                normals = _mesh[i].normals.Serialize(),
                tangents = _mesh[i].tangents.Serialize(),
                uv = _mesh[i].uv.Serialize(),
                uv2 = _mesh[i].uv2.Serialize(),
                uv3 = _mesh[i].uv3.Serialize(),
                uv4 = _mesh[i].uv4.Serialize(),
                uv5 = _mesh[i].uv5.Serialize(),
                uv6 = _mesh[i].uv6.Serialize(),
                uv7 = _mesh[i].uv7.Serialize(),
                uv8 = _mesh[i].uv8.Serialize(),
                vertices = _mesh[i].vertices.Serialize()
                //Do triangles still aka mesh
            });
        }

        return returnVal.ToArray();
    }
    #endregion

    #region Deserialization
    public static Mesh Deserialize(this SMesh _mesh)
    {
        if (_mesh == null)
            return null;

        Mesh returnVal = new Mesh()
        {
            bindposes = _mesh.bindposes,
            boneWeights = _mesh.boneWeights,
            bounds = _mesh.bounds,
            colors = _mesh.colors.Deserialize(),
            indexFormat = _mesh.indexFormat,
            name = _mesh.name,
            normals = _mesh.normals.Deserialize(),
            tangents = _mesh.tangents.Deserialize(),
            uv = _mesh.uv.Deserialize(),
            uv2 = _mesh.uv2.Deserialize(),
            uv3 = _mesh.uv3.Deserialize(),
            uv4 = _mesh.uv4.Deserialize(),
            uv5 = _mesh.uv5.Deserialize(),
            uv6 = _mesh.uv6.Deserialize(),
            uv7 = _mesh.uv7.Deserialize(),
            uv8 = _mesh.uv8.Deserialize(),
            vertices = _mesh.vertices.Deserialize()
        };

        //Do triangles still aka mesh
        return returnVal;
    }

    public static Mesh[] Deserialize(this SMesh[] _mesh)
    {
        if (_mesh == null)
            return null;

        List<Mesh> returnVal = new List<Mesh>();

        for (int i = 0; i < _mesh.Length; i++)
        {
            returnVal.Add(new Mesh()
            {
                bindposes = _mesh[i].bindposes,
                boneWeights = _mesh[i].boneWeights,
                bounds = _mesh[i].bounds,
                colors = _mesh[i].colors.Deserialize(),
                indexFormat = _mesh[i].indexFormat,
                name = _mesh[i].name,
                normals = _mesh[i].normals.Deserialize(),
                tangents = _mesh[i].tangents.Deserialize(),
                uv = _mesh[i].uv.Deserialize(),
                uv2 = _mesh[i].uv2.Deserialize(),
                uv3 = _mesh[i].uv3.Deserialize(),
                uv4 = _mesh[i].uv4.Deserialize(),
                uv5 = _mesh[i].uv5.Deserialize(),
                uv6 = _mesh[i].uv6.Deserialize(),
                uv7 = _mesh[i].uv7.Deserialize(),
                uv8 = _mesh[i].uv8.Deserialize(),
                vertices = _mesh[i].vertices.Deserialize()
            });
        }

        //Do triangles still aka mesh
        return returnVal.ToArray();
    }
    #endregion
}