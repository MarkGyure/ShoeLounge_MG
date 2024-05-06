/*****************************************************************************
// File Name : TutorialMouseFollower.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : handles how the tools follow the mouse for the tutorial only because it has to be different
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
public class TutorialMouseFollower : MonoBehaviour
{
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private GameObject sponge;
    [SerializeField] private GameObject soap;
    [SerializeField] private float soapOffset = 5f;
    private InputAction mousePositionAction;
    /// <summary>
    ///         Enable the mouse position action
    /// </summary>
    void OnEnable()
    {
        mousePositionAction.Enable();
    }
    /// <summary>
    /// Disable the mouse position action
    /// </summary>
    void OnDisable()
    {
        mousePositionAction.Disable();
    }
    /// <summary>
    /// Create the mouse position action
    /// </summary>
    void Awake()
    {
        mousePositionAction = new InputAction(binding: "<Mouse>/position");
    }
    /// <summary>
    /// reads mouse position  and sets the current tool to the mouses pos during every frame
    /// </summary>
    void Update()
    {
        Vector2 mousePosition = mousePositionAction.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;
            if (sponge != null)
            {
                sponge.transform.position = Vector3.Lerp(sponge.transform.position, targetPosition, followSpeed * Time.deltaTime);
            }
            Vector3 soapTargetPosition = hit.point - Vector3.up * soapOffset;
            if (soap != null)
            {
                soap.transform.position = Vector3.Lerp(soap.transform.position, soapTargetPosition, followSpeed * Time.deltaTime);
            }
        }
    }
}
