using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangulator : MonoBehaviour
{ 
    public Mesh mesh;

    private void Start()
    {
        mesh = new Mesh();
        MeshTriangulator();
    }

    private void MeshTriangulator()
    {
        mesh.name = "Mesh Triangulator";
        GetComponent<MeshFilter>().mesh=mesh;
        mesh.vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(0,10,0),
            new Vector3(10,0,0),
            new Vector3(10,10,0)
        };
        mesh.triangles=new int[]
        {
            0,1,2,
            2,1,3
        };
    }
}
