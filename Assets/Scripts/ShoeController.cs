/*****************************************************************************
// File Name : ShoeController.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : Controls how shoes generate
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShoeController : MonoBehaviour
{
    [SerializeField] private GameObject sportPrefab;
    [SerializeField] private GameObject casualPrefab;
    private Vector3 spawnPosition = new Vector3(-28.5599995f, 4.01399994f, -7.71299982f);
    // Materials
    [SerializeField] private Material feltMaterial;
    [SerializeField] private Material coatedLeatherMaterial;
    [SerializeField] private Material artificialLeatherMaterial;
    [SerializeField] private Material denimMaterial;
    [SerializeField] private Material dirtyFeltMaterial;
    [SerializeField] private Material dirtyCoatedLeatherMaterial;
    [SerializeField] private Material dirtyArtificialLeatherMaterial;
    [SerializeField] private Material dirtyDenimMaterial;
    private CleanController cleanController;
    /// <summary>
    /// called before first frame, finds clean controller and generates the shoe that is to be cleaned
    /// </summary>
    void Start()
    {
        cleanController = FindObjectOfType<CleanController>();
        GenerateShoe();
    }
    /// <summary>
    /// finds random shoe type out of 2 THIS WILL CHANGE TO 4 LATER
    /// then fids the material the shoe is supposed to be and assigns it
    /// THEN finds the condition is supposed to be and "assigns" that
    /// </summary>
    private void GenerateShoe()
    {
        int randomShoeType = UnityEngine.Random.Range(0, 2); 

        GameObject shoePrefab = null;
        switch (randomShoeType)
        {
            case 0:
                shoePrefab = sportPrefab;
                Debug.Log("Type: Sport");
                break;
            case 1:
                shoePrefab = casualPrefab;
                Debug.Log("Type: Casual");
                break;
            default:
                Debug.Log("Invalid random integer generated.");
                break;
        }

        if (shoePrefab != null)
        {
            GameObject shoeInstance = Instantiate(shoePrefab, spawnPosition, Quaternion.identity);

            int randomMaterial = UnityEngine.Random.Range(0, 4);

            Material materialToAssign = null;
            switch (randomMaterial)
            {
                case 0:
                    materialToAssign = dirtyFeltMaterial;
                    Debug.Log("Material: Felt");
                    break;
                case 1:
                    materialToAssign = dirtyCoatedLeatherMaterial;
                    Debug.Log("Material: Coated Leather");
                    break;
                case 2:
                    materialToAssign = dirtyArtificialLeatherMaterial;
                    Debug.Log("Material: Artificial Leather");
                    break;
                case 3:
                    materialToAssign = dirtyDenimMaterial;
                    Debug.Log("Material: Denim");
                    break;
                default:
                    Debug.Log("Invalid random integer generated.");
                    break;
            }

            // Assign material to the cubes within the shoe prefab
            if (materialToAssign != null)
            {
                Renderer[] cubeRenderers = shoeInstance.GetComponentsInChildren<Renderer>();
                foreach (Renderer cubeRenderer in cubeRenderers)
                {
                    cubeRenderer.material = materialToAssign;
                }
            }
            else
            {
                Debug.LogError("Failed to assign material to the shoe object.");
            }
        }

        int randomCondition = UnityEngine.Random.Range(0, 2);
        switch (randomCondition)
        {
            case 0:
                Debug.Log("Condition: Dirty");
                break;
            case 1:
                Debug.Log("Condition: Very Dirty");
                break;
            case 2:
                Debug.Log("Condition: Torn");
                break;
            default:
                Debug.Log("Invalid random integer generated.");
                break;
        }
    }
}
