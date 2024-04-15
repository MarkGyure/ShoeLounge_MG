/*****************************************************************************
// File Name : LaceCleaner
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : Contains the code that will handle how the lace cleaning works
*****************************************************************************/
using UnityEngine;
public class LaceCleaner : MonoBehaviour
{
    public GameObject objectToDisable; 
    public GameObject objectToEnable; 
    /// <summary>
    /// when the mouse is pressed make sure the objects are not null and then disables or enables the components 
    /// renderer (temporary)
    /// </summary>
    private void OnMouseDown()
    {
        if (objectToDisable != null && objectToEnable != null)
        {
            if (objectToDisable.GetComponent<Renderer>() != null)
            {
                objectToDisable.GetComponent<Renderer>().enabled = false;
            }
            if (objectToDisable.GetComponent<Collider>() != null)
            {
                objectToDisable.GetComponent<Collider>().enabled = false;
            }
            if (objectToEnable.GetComponent<Renderer>() != null)
            {
                objectToEnable.GetComponent<Renderer>().enabled = true;
            }
            if (objectToEnable.GetComponent<Collider>() != null)
            {
                objectToEnable.GetComponent<Collider>().enabled = true;
            }
        }
        else
        {
            Debug.LogError("objectToDisable or objectToEnable is not assigned!");
        }
    }
}
