using UnityEngine;
using System.Collections;

public class MeshBend : MonoBehaviour {

	public Transform[] rubberBodies;
	float[] beforeBodies;

	void Start () {
		beforeBodies = new float[rubberBodies.Length];
		for (int i=0; i<rubberBodies.Length; i++) {
			beforeBodies[i] = 0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
		int ro = 360 / rubberBodies.Length;
		for(int i = 0;i < vertices.Length;i++) {
			int rn = (int)((Mathf.Clamp(Mathf.Atan2(vertices[i].y,vertices[i].x) * Mathf.Rad2Deg+180f,0f,359f)) / ro);
			//if(rn >= rubberBodies.Length)rn=0;
			float d = beforeBodies[rn] - rubberBodies[rn].localPosition.y;
			vertices[i] += normals[i] * d;
		}
		for (int i=0; i<rubberBodies.Length; i++) {
			beforeBodies[i] = rubberBodies[i].localPosition.y;;
		}
		mesh.vertices = vertices;
	}
}
