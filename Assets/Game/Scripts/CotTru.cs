using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Funzilla
{
    public class CotTru : MonoBehaviour
    {
        private Vector3[] _vertices;
       private int[] _triangles;
       private Mesh _mesh;
       private MeshFilter _meshFillter;
       [SerializeField] private float rIner;
       [SerializeField] private float rOutner;
       [SerializeField] private Vector3 center;
       [SerializeField] private float thickness;

       [SerializeField] private float deltaPhi = 60f;
       private bool _isCreated;
       
       private Vector3[] _newVertices;
       private List<Vector3> _verticesList;
       private List<int> _trianglesList;
       private float _phi = 0;
       [SerializeField]private bool dir = false;
       [SerializeField]private Transform parent;
       private void Start()
       {
         Init();
         
       }
       private void Init()
       {
           _verticesList = new List<Vector3>();
          _mesh = new Mesh();
          _trianglesList = new List<int>();
          _meshFillter = GetComponent<MeshFilter>();
          _newVertices = new Vector3[4];
         
       }
       
       internal void AddShape()
       {
           if (!_isCreated)
           {
               _mesh.Clear();
               _verticesList.Add(new Vector3(center.x + rIner,thickness/2,center.z ));
               _verticesList.Add(new Vector3(center.x + rOutner,thickness/2,center.z ));
               _verticesList.Add(new Vector3(center.x + rOutner,-thickness/2,center.z ));
               _verticesList.Add(new Vector3(center.x + rIner,-thickness/2,center.z ));
               AddTriangle(0,2,3);
               AddTriangle(1,2,0);
               _isCreated = true;
           }

           var deltaphi = deltaPhi*Time.deltaTime;
           _phi += deltaphi;
           if (_phi >= 360 + deltaphi) return;
           if (_phi >= 360)
           {
               for (var i = 0; i < 6; i++)
               {
                   _trianglesList.RemoveAt(_trianglesList.Count - 1);
               }
               for (var i = 0; i < 6; i++)
               {
                   _trianglesList.RemoveAt(0);
               }
               
               AddTriangle(0,1,_verticesList.Count-4);
               AddTriangle(1,_verticesList.Count-3,_verticesList.Count-4);
               AddTriangle(0,_verticesList.Count-4,3);
               AddTriangle(3,_verticesList.Count-4,_verticesList.Count-1);
               AddTriangle(1,2,_verticesList.Count-3);
               AddTriangle(2,_verticesList.Count-2,_verticesList.Count-3);
               AddTriangle(_verticesList.Count-1,2,3);
               AddTriangle(_verticesList.Count-2,2,_verticesList.Count-1);
               _mesh.triangles = _trianglesList.ToArray();
               _mesh.RecalculateNormals();
               _meshFillter.mesh = _mesh;
               return;
           }

           if (dir)
           {
               parent.transform.eulerAngles += Vector3.up * deltaphi;
           }
           var sinPhi = Mathf.Sin(_phi*2*Mathf.PI/360);
           var cosPhi = Mathf.Cos(_phi*2*Mathf.PI/360);

           var xInner = cosPhi * rIner;
           var zInner = sinPhi * rIner;
           var xOuter = cosPhi * rOutner;
           var zOuter = sinPhi * rOutner;
           var thicknessHalf = thickness / 2;
           _newVertices[0] = new Vector3(center.x +xInner,thicknessHalf,center.z + zInner);
           _newVertices[1] = new Vector3(center.x +xOuter, thicknessHalf,center.z + zOuter);
           _newVertices[2] = new Vector3(center.x +xOuter, -thicknessHalf, center.z + zOuter);
           _newVertices[3] = new Vector3(center.x +xInner, -thicknessHalf, center.z + zInner);
           
           for (var i = 0; i < 4; i ++ )
           {
               _verticesList.Add(_newVertices[i]);
           }

           if (_trianglesList.Count > 7)
           {
               for (var i = 0; i < 6; i++)
               {
                   _trianglesList.RemoveAt(_trianglesList.Count - 1);
               }
               
           }
           var vertexCount = _verticesList.Count;
           var oldTriangleIndex = _verticesList.Count - 9;
           var newTriangleIndex = _verticesList.Count - 5;
           
           AddTriangle(oldTriangleIndex + 4,oldTriangleIndex + 3,newTriangleIndex + 3);
           AddTriangle(oldTriangleIndex + 4,newTriangleIndex + 3,newTriangleIndex + 4);
           AddTriangle(newTriangleIndex + 3,oldTriangleIndex + 2,newTriangleIndex + 2);
           AddTriangle(oldTriangleIndex + 3,oldTriangleIndex + 2,newTriangleIndex + 3);
           AddTriangle(oldTriangleIndex + 1,oldTriangleIndex + 4,newTriangleIndex + 1);
           AddTriangle(newTriangleIndex + 4,newTriangleIndex + 1,oldTriangleIndex + 4);
           AddTriangle(oldTriangleIndex + 1,newTriangleIndex + 1,newTriangleIndex + 2);
           AddTriangle(oldTriangleIndex + 1,newTriangleIndex + 2,oldTriangleIndex + 2);
           
           AddTriangle(newTriangleIndex + 4,newTriangleIndex + 2,newTriangleIndex + 1);
           AddTriangle(newTriangleIndex + 4,newTriangleIndex + 3,newTriangleIndex + 2);
           
           _mesh.vertices = _verticesList.ToArray();
           _mesh.triangles = _trianglesList.ToArray();
           _mesh.RecalculateNormals();
           _meshFillter.mesh = _mesh;
       }

       private void AddTriangle(int v1,int v2,int v3)
       {
           _trianglesList.Add(v1);
           _trianglesList.Add(v2);
           _trianglesList.Add(v3);
       }
    }

}
