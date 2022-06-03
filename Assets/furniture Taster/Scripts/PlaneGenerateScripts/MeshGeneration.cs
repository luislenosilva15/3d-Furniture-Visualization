using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class MeshGeneration : MonoBehaviour
{

    public List<Vector3> RoomCorners = new List<Vector3>();
    Vector3[] vertices = new Vector3[4];
    Vector2[] uvs = new Vector2[4];

    public List<Texture> floorTexture = new List<Texture>();
    public List<string> floorTextureName = new List<string>();
    public Material meshMaterial;

    public Transform Points;

    public void Start()
    {

        string floorName = PlayerPrefs.GetString("floor");

        for (int index = 0; index < floorTexture.Count; index++)
        {
            if (floorName == floorTextureName[index])
            {
                meshMaterial.mainTexture = floorTexture[index];
            }
        }

       // CreateMesh();
    }

    public void CreateMesh()
    {
        SetPointsPositions();
       // RoomCorners.Add(new Vector3(1.4f, -1.1f, 1.2f)); //top-left
       // RoomCorners.Add(new Vector3(2.5f, -1.1f, 0.1f)); //top-right
       // RoomCorners.Add(new Vector3(1.3f, -1.1f, -0.7f)); //bottom-right
       // RoomCorners.Add(new Vector3(0.4f, -1.1f, 0.4f)); //bottom-left


        Mesh mesh = new Mesh();

        vertices[0] = RoomCorners[0]; //top-left
        vertices[1] = RoomCorners[1]; //top-right
        vertices[2] = RoomCorners[3]; //bottom-left
        vertices[3] = RoomCorners[2]; //bottom-right

        mesh.vertices = vertices;

        int[] triangles = new int[6] { 0, 1, 2, 3, 2, 1 };
        mesh.triangles = triangles;

        uvs[0] = new Vector2(vertices[0].x, vertices[0].z); //top-left
        uvs[1] = new Vector2(vertices[1].x, vertices[1].z); //top-right
        uvs[2] = new Vector2(vertices[2].x, vertices[2].z); //bottom-left
        uvs[3] = new Vector2(vertices[3].x, vertices[3].z); //bottom-right
        mesh.uv = uvs;

        


        Vector3[] normals = new Vector3[4] { Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward };
        mesh.normals = normals;

        MeshFilter filter = GetComponent<MeshFilter>();
        filter.mesh = mesh;

    }

    public void RotateFloorTexture(float val)
    {
        
        meshMaterial.SetFloat("_Rotation", meshMaterial.GetFloat("_Rotation") + val);
    }

    private void SetPointsPositions()
    {
        if (Points == null)
        {
            return;
        }

        foreach (Transform point in Points.GetComponentsInChildren<Transform>())
        {
            if(point.name != Points.name)
            {
                RoomCorners.Add(point.position);
            }
            
        }
        foreach (Vector3 point in RoomCorners)
        {
            print(point);
        }
        //print(RoomCorners.Count);
    }
}