using UnityEngine;
 using System.Collections;
 [RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
 public class TestGenerate : MonoBehaviour 
 {
     // Use this for initialization
     void Start ()
     {
         Mesh mesh = new Mesh();
     
         Vector3[] vertices = new Vector3[4];
         vertices[0] = new Vector3(-0.6f,-1,1.1f); //top-left
         vertices[1] = new Vector3(0.2f,-1,1.1f); //top-right
         vertices[2] = new Vector3(-0.3f,-1,0.4f); //bottom-left
         vertices[3] = new Vector3(0.2f,-1,0.5f); //bottom-right
         
         mesh.vertices = vertices;
         
         int[] triangles = new int[6]{0,1,2,3,2,1};
         mesh.triangles = triangles;
         
         //this is also acceptable!
         //mesh.SetTriangleStrip(new int[4]{0,1,2,3}, 0);
     
         Vector2[] uvs = new Vector2[4];
         uvs[0] = new Vector2(-0.6f,1.1f); //top-left
         uvs[1] = new Vector2(0.2f,1.1f); //top-right
         uvs[2] = new Vector2(-0.3f,0.4f); //bottom-left
         uvs[3] = new Vector2(0.2f,0.5f); //bottom-right
     
         mesh.uv = uvs;
     
         Vector3[] normals = new Vector3[4]{Vector3.forward,Vector3.forward,Vector3.forward,Vector3.forward};
         mesh.normals = normals;
     
         //you could also call this instead...
         //mesh.RecalculateNormals();
     
     
         //grab our filter.. set the mesh
         MeshFilter filter = GetComponent<MeshFilter>();
         filter.mesh = mesh;
     
         //you can do your material stuff here...
         //MeshRenderer r = GetComponent<MeshRenderer>();
         //r.material = new Material(Shader.Find("my_shader_here"));
     
     }
 }