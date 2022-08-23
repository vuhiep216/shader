using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	void Start () {
		var vertices2D = new Vector2[] {
			new Vector2(0,0),
			new Vector2(0,50),
			new Vector2(50,50),
			new Vector2(50,100),
			new Vector2(0,100),
			new Vector2(0,150),
			new Vector2(150,150),
			new Vector2(150,100),
			new Vector2(100,100),
			new Vector2(100,50),
			new Vector2(150,50),
			new Vector2(150,0),
		};
		
		var tr = new Triangulator(vertices2D);
		var indices = tr.Triangulate();
		
		var vertices = new Vector3[vertices2D.Length];
		for (var i=0; i<vertices.Length; i++) {
			vertices[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 0);
		}
	
		var msh = new Mesh();
		msh.vertices = vertices;
		msh.triangles = indices;
		msh.RecalculateNormals();
		msh.RecalculateBounds();
	
		gameObject.AddComponent(typeof(MeshRenderer));
		var fillter = gameObject.GetComponent<MeshFilter>();
		fillter.mesh = msh;
	}
}