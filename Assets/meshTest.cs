using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshTest : MonoBehaviour
{
    public Vector3 pos0 = new Vector3( 1.3f,0,-0.7f);
    public Vector3 pos1 = new Vector3( 0.4f,0,0.4f);
    public Vector3 pos2 = new Vector3(2.5f,0,0.1f);
    public Vector3 pos3 = new Vector3( 1.4f,0,1.2f);

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs = new Vector2[4];

    void Awake() {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void Start()
    {
        MakeMeshData();
        CreateMesh();
        
    }

    void MakeMeshData() {
        vertices = new Vector3[] { pos0, pos1, pos2, pos3};
        triangles = new int[] {0,1,2, 2, 1, 3};
        uvs = new Vector2[] { new Vector2(1.3f, -0.7f), new Vector2(0.4f, 0.4f), new Vector2(2.5f, 0.1f), new Vector2(1.4f, 1.2f)};


      
        //MeshFilter filter = GetComponent<MeshFilter>();
        //filter.mesh = mesh;
    }
    void CreateMesh() {
        mesh.vertices = vertices;
        mesh.triangles = triangles;
          mesh.uv = uvs;
    }



}
