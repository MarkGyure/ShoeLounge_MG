using UnityEngine;

public class Voxelizer : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab of the cube game object
    public float cubeSize = 0.5f; // Size of the cube

    void Start()
    {
        // Access the shared mesh of the original game object
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        Vector3[] vertices = mesh.vertices;

        // Get the world position of the gameObject
        Vector3 objectPosition = transform.position;

        // Iterate through vertices of the mesh
        foreach (Vector3 vertex in vertices)
        {
            // Convert vertex position to world space
            Vector3 worldVertex = transform.TransformPoint(vertex);

            // Instantiate cube game object at the vertex position
            GameObject cube = Instantiate(cubePrefab, worldVertex, Quaternion.identity);

            // Adjust size and scale of the cube
            cube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        }

        // Optionally, remove the original mesh game object
        Destroy(gameObject);
    }
}
