using UnityEngine;
using System.Collections;

public class mesh_deform : MonoBehaviour {

    int intensity;

    float max;
    float sample_max;

    public Vector3[] refresh_vertices;
    public Vector3[] refresh_normals;

	// Use this for initialization
	void Start () {
        intensity = 25;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        refresh_vertices = mesh.vertices;
        refresh_normals = mesh.normals;
    }
	
	// Update is called once per frame
	void Update () {

        max = FindObjectOfType<Camera>().GetComponent<spectrum>().max;
        sample_max = FindObjectOfType<Camera>().GetComponent<spectrum>().sample_max;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        int j = 0;

        for ( j = 0; j < vertices.Length; j++ )
        {
            vertices[j] += normals[j] * Mathf.Sin(Time.time) * Time.deltaTime * 0.1f;
            //vertices[j] += normals[j] * Mathf.Sin(Time.time) * sample_max * sample_max;
            //vertices[j] += (normals[j] * Mathf.Sin(Time.time) * Time.deltaTime) + new Vector3((sample_max * Mathf.Sin(Time.time)), (sample_max * Mathf.Sin(Time.time)), (sample_max * Mathf.Sin(Time.time)));
            
            
        }

        mesh.vertices = vertices;

        /*^if (Time.frameCount % 512 == 0)
        {
            mesh.vertices = refresh_vertices;
        }*/

	}
}
