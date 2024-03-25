/*****************************************************************************
// File Name : Voxelizer.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : Not used yet, but may be an alternate method of cleaning shoes.
*****************************************************************************/
using UnityEngine;

public class Voxelizer : MonoBehaviour
{
    public GameObject cubePrefab; 
    public float cubeSize = 0.5f; 
    /// <summary>
    /// makes cubes on all vertices of the shoe to "voxelize"
    /// </summary>
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        Vector3[] vertices = mesh.vertices;
        Vector3 objectPosition = transform.position;
        foreach (Vector3 vertex in vertices)
        {
            Vector3 worldVertex = transform.TransformPoint(vertex);
            GameObject cube = Instantiate(cubePrefab, worldVertex, Quaternion.identity);
            cube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        }
        Destroy(gameObject);
    }
}
