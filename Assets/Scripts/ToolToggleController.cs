/*****************************************************************************
// File Name : ToolToggleController.cs
// Author : Mark Gyure
// Creation Date : 5/4/2024
// Brief Description : enables and disables the specific tools based on whats being clicked and whats currently
equipped.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
public class ToolToggleController : MonoBehaviour
{
    [SerializeField] private GameObject toolSponge;
    [SerializeField] private GameObject mouseSponge;
    [SerializeField] private GameObject toolSoap;
    [SerializeField] private GameObject mouseSoap;
    [SerializeField] private GameObject toolForceps;
    [SerializeField] private GameObject mouseForceps;
    [SerializeField] private GameObject toolBrush;
    [SerializeField] private GameObject mouseBrush;
    [SerializeField] private ToolActivationEvents activationEvents;
    private InputAction clickAction;
    /// <summary>
    /// before the first frame 
    /// </summary>
    private void Start()
    {
        clickAction = new InputAction(binding: "<Mouse>/leftButton");
        clickAction.Enable();
        clickAction.performed += OnClick;
    }
    /// <summary>
    /// casts ray to mouse location and searches for which tool is being selected and enables/disables tools
    /// accordingly
    /// </summary>
    /// <param name="context"></param>
    private void OnClick(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Clicked object: " + hitObject.name); //degbug line
            if (hitObject == toolSponge)
            {
                activationEvents.ActivateSponge();
                toolSponge.GetComponent<MeshRenderer>().enabled = false;
                mouseSponge.SetActive(true);
                mouseSponge.GetComponent<MeshRenderer>().enabled = true;
                mouseSoap.GetComponent<MeshRenderer>().enabled = false;
                mouseForceps.GetComponent<MeshRenderer>().enabled = false;
                mouseBrush.GetComponent<MeshRenderer>().enabled = false;
                toolSoap.GetComponent<MeshRenderer>().enabled = true;
                toolForceps.GetComponent<MeshRenderer>().enabled = true;
                toolBrush.GetComponent<MeshRenderer>().enabled = true;
            }
            else if (hitObject == toolSoap)
            {
                activationEvents.ActivateSoap();
                toolSoap.GetComponent<MeshRenderer>().enabled = false;
                mouseSoap.SetActive(true);
                mouseSponge.GetComponent<MeshRenderer>().enabled = false;
                mouseSoap.GetComponent<MeshRenderer>().enabled = true;
                mouseForceps.GetComponent<MeshRenderer>().enabled = false;
                mouseBrush.GetComponent<MeshRenderer>().enabled = false;
                toolSponge.GetComponent<MeshRenderer>().enabled = true;
                toolForceps.GetComponent<MeshRenderer>().enabled = true;
                toolBrush.GetComponent<MeshRenderer>().enabled = true;
            }
            else if (hitObject == toolForceps)
            {
                activationEvents.ActivateForceps();
                toolForceps.GetComponent<MeshRenderer>().enabled = false;
                mouseForceps.SetActive(true);
                mouseSponge.GetComponent<MeshRenderer>().enabled = false;
                mouseSoap.GetComponent<MeshRenderer>().enabled = false;
                mouseForceps.GetComponent<MeshRenderer>().enabled = true;
                mouseBrush.GetComponent<MeshRenderer>().enabled = false;
                toolSponge.GetComponent<MeshRenderer>().enabled = true;
                toolSoap.GetComponent<MeshRenderer>().enabled = true;
                toolBrush.GetComponent<MeshRenderer>().enabled = true;
            }
            else if (hitObject == toolBrush)
            {
                activationEvents.ActivateBrush();
                toolBrush.GetComponent<MeshRenderer>().enabled = false;
                mouseBrush.SetActive(true);
                mouseSponge.GetComponent<MeshRenderer>().enabled = false;
                mouseSoap.GetComponent<MeshRenderer>().enabled = false;
                mouseForceps.GetComponent<MeshRenderer>().enabled = false;
                mouseBrush.GetComponent<MeshRenderer>().enabled = true;
                toolSponge.GetComponent<MeshRenderer>().enabled = true;
                toolSoap.GetComponent<MeshRenderer>().enabled = true;
                toolForceps.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
    /// <summary>
    /// disables the click action event
    /// </summary>
    private void OnDisable()
    {
        clickAction.Disable();
    }
}