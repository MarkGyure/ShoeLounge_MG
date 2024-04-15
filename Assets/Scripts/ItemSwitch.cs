using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitch : MonoBehaviour
{
    public GameObject sponge; // Reference to the sponge object
    public GameObject soap; // Reference to the soap object

    
    [SerializeField] private bool spongeActive = false; // Flag to track if sponge is active
    [SerializeField] private bool soapActive = false; // Flag to track if soap is active

    [SerializeField] private TimerCountdown timerCountdown;

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
        if (spongeActive && timerCountdown.timesUp1 == false)
        {
            spongeActive = false;
            soapActive = true;

            if (sponge != null)
                sponge.GetComponent<MeshRenderer>().enabled = false;

            if (soap != null)
                soap.GetComponent<MeshRenderer>().enabled = true;
        }
        // If soap is active, deactivate it and activate sponge
        else if (soapActive && timerCountdown.timesUp1 == false)
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