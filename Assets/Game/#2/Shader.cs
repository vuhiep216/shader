using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shader : MonoBehaviour
{
    public Mesh mesh;
    public Material mat;
    public MeshFilter meshFilter;
    private void Start()
    {
        MeshGenerateSquare();
    }
    private void MeshGenerateSquare()
    {
        mesh = new Mesh();
        mat = GetComponent<Renderer>().material;
        mesh.name = "MeshShader";
        mesh.vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(0,1,0),
            new Vector3(1,0,0),
            new Vector3(1,1,0)
        };
        mesh.normals = new Vector3[]
        {
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up,
        };
        mesh.SetUVs(0, new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(1,1),
            new Vector2(0,1)
        });
        mesh.triangles=new int[]
        {
            0,1,2,
            2,1,3
        };
        meshFilter.mesh = mesh;
    }

    private void Update()
    {
        var x = Mathf.Cos(Time.time);
        var y = Mathf.Sin(Time.time);
        mat.SetVector("Rotate", new Vector4(x, y,0,0));
    }
}
