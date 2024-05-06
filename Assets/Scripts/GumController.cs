/*****************************************************************************
// File Name : GumController.cs 
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : handles the gum removal process
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class GumController : MonoBehaviour
{
    [SerializeField] private ItemSwitch itemSwitch;
    [SerializeField] private GameObject gumObject;
    [SerializeField] private ScoreData scoreData;
    private InputAction clickAction;
    /// <summary>
    /// creates the input for mouse clicks and enables the action listener
    /// </summary>
    private void OnEnable()
    {
        clickAction = new InputAction(binding: "<Mouse>/leftButton");
        clickAction.performed += OnClick;
        clickAction.Enable();
    }
    /// <summary>
    /// Disables the input action when the script is disabled or destroyed
    /// </summary>
    private void OnDisable()
    {
        clickAction.Disable();
    }
    /// <summary>
    /// casts a ray and if its hitting the gum object, it adds the score and removes the gum
    /// </summary>
    /// <param name="context"></param>
    private void OnClick(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject == gumObject && itemSwitch.ForcepsActive == true)
            {
                gumObject.GetComponent<Collider>().enabled = false;
                gumObject.GetComponent<Renderer>().enabled = false;
                scoreData.playerScore += 5;
            }
        }
    }
}
