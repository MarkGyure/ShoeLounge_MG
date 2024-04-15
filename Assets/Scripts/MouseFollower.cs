/*****************************************************************************
// File Name : MouseFolower.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : Handles the tools following the mouse for the main levels
*****************************************************************************/
using UnityEngine;
public class MouseFollower : MonoBehaviour
{
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private GameObject sponge;
    [SerializeField] private GameObject soap;
    [SerializeField] private float soapOffset = 5f;
    [SerializeField] private TimerCountdown timerCountdown;
    /// <summary>
    /// called once per frame and makes a vector to calculate mouse position. takes a raycast from the camera to the
    /// mouse position. if the ray hits, if the timer isnt up, and if the round isnt over it will find the point that
    /// the ray hit, get the sponges position and move it to the mouse target position at the specified speed, and 
    /// repeats the same for the soap bottle.
    /// </summary>
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && timerCountdown.timesUp1 == false && timerCountdown.allDone1 == false)
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
