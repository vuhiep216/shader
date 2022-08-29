using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Funzilla
{
    public class Homework : MonoBehaviour
    {
        private List<int> listTriangle = new List<int>();
        private List<Vector3> listVerticle = new List<Vector3>();
        public Mesh mesh;
        public bool square=false, circle=false, fourSquares=false;

        private void Start()
        {
            mesh = new Mesh();
            if(square) MeshGenerateSquare();
            if(circle) MeshGenerateCircle(36);
            if(fourSquares) GenerateFourSquares();
        }

        private void MeshGenerateSquare()
        {
            mesh.name = "Mesh square";
            GetComponent<MeshFilter>().mesh=mesh;
            mesh.vertices = new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(0,1,0),
                new Vector3(1,0,0),
                new Vector3(1,1,0)
            };
            mesh.triangles=new int[]
            {
                0,1,2,
                2,1,3
            };
        }

        private void MeshGenerateCircle(int numOfPoints)
        {
            mesh.name = "Mesh circle";
            GetComponent<MeshFilter>().mesh=mesh;
            var angleStep = 360.0f / (float)numOfPoints;
                var vertexList = new List<Vector3>();
                var triangleList = new List<int>();
                var quaternion = Quaternion.Euler(0.0f, 0.0f, -angleStep);
                vertexList.Add(new Vector3(0.0f, 0.0f, 0.0f));
                vertexList.Add(new Vector3(0.0f, 2.5f, 0.0f));
                vertexList.Add(quaternion * vertexList[1]);
                triangleList.Add(0);
                triangleList.Add(1);
                triangleList.Add(2);
                for (int i = 0; i < numOfPoints - 1; i++)
                {
                    triangleList.Add(0);
                    triangleList.Add(vertexList.Count - 1);
                    triangleList.Add(vertexList.Count);
                    vertexList.Add(quaternion * vertexList[vertexList.Count - 1]);
                }
                mesh.vertices = vertexList.ToArray();
                mesh.triangles = triangleList.ToArray();
            }

        private void GenerateFourSquares()
        {
            mesh.name = "Mesh 4 squares";
            GetComponent<MeshFilter>().mesh=mesh;
            mesh.vertices = new Vector3[]
            {
                new Vector3(0,0,1),
                new Vector3(0,11,1),
                new Vector3(11,0,1),
                new Vector3(11,11,1),
                new Vector3(5,0,1),
                new Vector3(6,0,1),
                new Vector3(0,5,1),
                new Vector3(0,6,1),
                new Vector3(11,5,1),
                new Vector3(11,6,1),
                new Vector3(5,11,1),
                new Vector3(6,11,1),
                new Vector3(5,6,1),
                new Vector3(6,6,1),
                new Vector3(5,5,1),
                new Vector3(6,5,1)
            };
            mesh.triangles=new int[]
            {
              1,12,7,
              1,10,12,
              6,14,0,
              0,14,4,
              5,15,2,
              2,15,8,
              13,11,9,
              9,11,3
            };
        }
    }

}
