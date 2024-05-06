/*****************************************************************************
// File Name : MouseFollower.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : Handles the tools following the mouse for the main levels
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private GameObject sponge;
    [SerializeField] private GameObject soap;
    [SerializeField] private GameObject forceps;
    [SerializeField] private GameObject brush;
    [SerializeField] private float soapOffset = 5f;
    [SerializeField] private TimerCountdown timerCountdown;

    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && !timerCountdown.timesUp1 && !timerCountdown.allDone1)
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
            if (forceps != null)
            {
                forceps.transform.position = Vector3.Lerp(forceps.transform.position, targetPosition, followSpeed * Time.deltaTime);
            }
            if (brush != null)
            {
                brush.transform.position = Vector3.Lerp(brush.transform.position, targetPosition, followSpeed * Time.deltaTime);
            }
        }
    }
}
