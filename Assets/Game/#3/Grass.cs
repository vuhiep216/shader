using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] private GameObject pref;
    [SerializeField] private Texture2D mainTexture;
    [SerializeField] float blockSize;
    [SerializeField] MeshFilter meshFilter;
    public List<Vector3> vert;
    public List<int> tris;
    public List<Color> col;

    // Start is called before the first frame update
    private void Start()
    {
        var mesh = new Mesh();
        var a = blockSize / mainTexture.height;
        var meshPref = pref.GetComponent<MeshFilter>().sharedMesh;
        var vertPref = meshPref.vertices;
        for (var x = 0; x < mainTexture.height; x++)
        {
            for (var y = 0; y < mainTexture.width; y++)
            {
                var pos = new Vector3(x, 0, y) * a;
                foreach (var vp in vertPref)
                {
                    var v = vp;
                    v += pos;
                    vert.Add(v);
                }

                var color = mainTexture.GetPixel(x, y);
                col.Add(color);
            }
        }

        for (var i = 0; i < vert.Count - 4; i += 4)
        {
            tris.Add(i);
            tris.Add(i + 1);
            tris.Add(i + 2);
            tris.Add(i);
            tris.Add(i + 3);
            tris.Add(i + 2);
        }

        var colorVert = new Color[vert.Count];
        for (var i = 0; i < colorVert.Length - 4; i += 4)
        {
            int y;
            if (i != 0)
                y = i / 4;
            else
                y = 0;
            colorVert[i] = col[y] * (0.2f + 0.8f * vert[i].y);
            colorVert[i + 1] = col[y] * (0.2f + 0.8f * vert[i + 1].y);
            colorVert[i + 2] = col[y] * (0.2f + 0.8f * vert[i + 2].y);
            colorVert[i + 3] = col[y] * (0.2f + 0.8f * vert[i + 3].y);
        }

        var uv = new Vector2[vert.Count];
        for (var i = 0; i < uv.Length; i++)
        {
            uv[i] = new Vector2(vert[i].x + .2f * vert[i].y, vert[i].z + .2f * vert[i].y);
        }

        mesh.vertices = vert.ToArray();
        mesh.colors = colorVert;
        mesh.triangles = tris.ToArray();
        mesh.uv = uv;
        meshFilter.sharedMesh = mesh;
    }
}