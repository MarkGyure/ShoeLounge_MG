using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemSwitch : MonoBehaviour
{
    public GameObject sponge; // Reference to the sponge object
    public GameObject soap; // Reference to the soap object

    
    [SerializeField] private bool spongeActive = false; // Flag to track if sponge is active
    [SerializeField] private bool soapActive = false; // Flag to track if soap is active

    // Method to toggle between sponge and soap
    private void Start()
    {
        spongeActive = true;
    }
    public bool SpongeActive
    {
        get { return spongeActive; }
    }

    // Public property to access soapActive
    public bool SoapActive
    {
        get { return soapActive; }
    }
    public void ToggleObjects()
    {
        // If sponge is active, deactivate it and activate soap
        if (spongeActive)
        {
            spongeActive = false;
            soapActive = true;

            if (sponge != null)
                sponge.GetComponent<MeshRenderer>().enabled = false;

            if (soap != null)
                soap.GetComponent<MeshRenderer>().enabled = true;
        }
        // If soap is active, deactivate it and activate sponge
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