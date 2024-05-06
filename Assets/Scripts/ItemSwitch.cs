/*****************************************************************************
// File Name : ItemSwitch.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : Controlls how the items are switched 
*****************************************************************************/
using UnityEngine;
public class ItemSwitch : MonoBehaviour
{
    [SerializeField] private GameObject sponge;
    [SerializeField] private GameObject soap;
    [SerializeField] private GameObject forceps;
    [SerializeField] private GameObject brush;
    [SerializeField] private bool soapActive = false;
    [SerializeField] private bool spongeActive = false;
    [SerializeField] private bool forcepsActive = false;
    [SerializeField] private bool brushActive = false;
    /// <summary>
    /// getter for the pliars
    /// </summary>
    public bool ForcepsActive
    {
        get { return forcepsActive; }
    }
    /// <summary>
    /// getter for the glue
    /// </summary>
    public bool BrushActive
    {
        get { return brushActive; }
    }
    /// <summary>
    /// getter for the soap
    /// </summary>
    public bool SoapActive
    {
        get { return soapActive; }
    }
    /// <summary>
    /// getter for sponge
    /// </summary>
    public bool SpongeActive
    {
        get { return spongeActive; }
    }
    /// <summary>
    /// before the first frame gets all the action listeners for getting the tools
    /// </summary>
    private void Start()
    {
        var events = FindObjectOfType<ToolActivationEvents>();
        events.spongeActivated.AddListener(ActivateSponge);
        events.soapActivated.AddListener(ActivateSoap);
        events.forcepsActivated.AddListener(ActivateForceps);
        events.brushActivated.AddListener(ActivateBrush);
    }
    /// <summary>
    /// activaes sponge
    /// </summary>
    private void ActivateSponge()
    {
        sponge.SetActive(false);
        soap.SetActive(true);
        forceps.SetActive(true);
        brush.SetActive(true);
        spongeActive = true;
        soapActive = false;
        forcepsActive = false;
        brushActive = false;
        Debug.Log("sponge activated");
    }
    /// <summary>
    /// activaes soap
    /// </summary>
    private void ActivateSoap()
    {
        sponge.SetActive(true);
        soap.SetActive(false);
        forceps.SetActive(true);
        brush.SetActive(true);
        spongeActive = false;
        soapActive = true;
        forcepsActive = false;
        brushActive = false;
        Debug.Log("soap activated");
    }
    /// <summary>
    /// activaes pliars
    /// </summary>
    private void ActivateForceps()
    {
        sponge.SetActive(true);
        soap.SetActive(true);
        forceps.SetActive(false);
        brush.SetActive(true);
        spongeActive = false;
        soapActive = false;
        forcepsActive = true;
        brushActive = false;
        Debug.Log("forceps activated");
    }
    /// <summary>
    /// activaes glue
    /// </summary>
    private void ActivateBrush()
    {
        sponge.SetActive(true);
        soap.SetActive(true);
        forceps.SetActive(true);
        brush.SetActive(false);
        spongeActive = false;
        soapActive = false;
        forcepsActive = false;
        brushActive = true;
        Debug.Log("forceps activated");
    }
}
