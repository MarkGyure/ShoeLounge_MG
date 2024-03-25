/*****************************************************************************
// File Name : RandomPrefabSpawner.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : spawns the dirt prefabs
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomPrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; 
    public int numberOfPrefabs = 5; 
    public float spawnRadius = 1f; 
    public GameObject childObject; 
    /// <summary>
    /// makes sure nothing is null and does debug checks because this was miserable and then finds the mesh and
    /// adds the dirt blocks on random areas around the inside shoe mesh. Then instantiates them.
    /// </summary>
    private void Start()
    {
        if (childObject == null || prefabsToSpawn.Length == 0)
        {
            Debug.LogError("Child GameObject or no prefabs assigned.");
            return;
        }
        MeshFilter meshFilter = childObject.GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("MeshFilter component not found in the child GameObject.");
            return;
        }
        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = mesh.vertices;
        List<int> usedIndices = new List<int>();
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            GameObject prefabToInstantiate = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, vertices.Length);
            } while (usedIndices.Contains(randomIndex));

            usedIndices.Add(randomIndex);
            Vector3 vertexPosition = childObject.transform.TransformPoint(vertices[randomIndex] * spawnRadius);
            Instantiate(prefabToInstantiate, vertexPosition, Quaternion.identity, transform);
        }
    }
}
