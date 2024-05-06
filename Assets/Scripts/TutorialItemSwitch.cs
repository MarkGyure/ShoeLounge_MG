/*****************************************************************************
// File Name : TutorialItemSwitch.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : Handles the item switch button for the tutorial level
*****************************************************************************/
using UnityEngine;

public class TutorialItemSwitch : MonoBehaviour
{
    [SerializeField] private GameObject sponge;
    [SerializeField] private GameObject soap;
    [SerializeField] private bool spongeActive = false; 
    [SerializeField] private bool soapActive = false;
    /// <summary>
    /// sets the sponge as the default active tool
    /// </summary>
    private void Start()
    {
        spongeActive = true;
    }
    /// <summary>
    /// getter for the sponge active var
    /// </summary>
    public bool SpongeActive
    {
        get { return spongeActive; }
    }
    /// <summary>
    /// getter for the soap active var
    /// </summary>
    public bool SoapActive
    {
        get { return soapActive; }
    }
    /// <summary>
    /// If sponge is active, deactivate it and activate soap and if soap is active, deactivate it and activate sponge
    /// </summary>
    public void ToggleObjects()
    {
        if (spongeActive)
        {
            spongeActive = false;
            soapActive = true;

            if (sponge != null)
                sponge.GetComponent<MeshRenderer>().enabled = false;

            if (soap != null)
                soap.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (soapActive)
        {
            spongeActive = true;
            soapActive = false;

            if (sponge != null)
                sponge.GetComponent<MeshRenderer>().enabled = true;

            if (soap != null)
                soap.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}