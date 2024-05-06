/*****************************************************************************
// File Name : ToolActivationEvents.cs
// Author : Mark Gyure
// Creation Date : 5/4/2024
//
// Brief Description : Handles the activatiom events for the tools
*****************************************************************************/
using UnityEngine;
using UnityEngine.Events;
public class ToolActivationEvents : MonoBehaviour
{
    public UnityEvent spongeActivated;
    public UnityEvent soapActivated;
    public UnityEvent forcepsActivated;
    public UnityEvent brushActivated;
    /// <summary>
    /// Handles the activatiom events for the sponge
    /// </summary>
    public void ActivateSponge()
    {
        spongeActivated.Invoke();
    }
    /// <summary>
    /// Handles the activatiom events for the soap
    /// </summary>
    public void ActivateSoap()
    {
        soapActivated.Invoke();
    }
    /// <summary>
    /// Handles the activatiom events for the pliars
    /// </summary>
    public void ActivateForceps()
    {
        forcepsActivated.Invoke();
    }
    /// <summary>
    /// Handles the activatiom events for glue
    /// </summary>
    public void ActivateBrush()
    {
        brushActivated.Invoke();
    }
}
