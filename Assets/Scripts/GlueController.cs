/*****************************************************************************
// File Name : GlueController.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : handles how the glue action works
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class GlueController : MonoBehaviour
{
    [SerializeField] private GameObject glueLoc1;
    [SerializeField] private GameObject glueLoc2;
    [SerializeField] private GameObject glueLoc3;
    [SerializeField] private GameObject glueLoc4;
    [SerializeField] private GameObject brokenSole;
    [SerializeField] private GameObject fixedSole;
    public int clickedGlueLocations = 0;
    private InputAction clickAction;
    [SerializeField] private ItemSwitch itemSwitch;
    [SerializeField] private ScoreData scoreData;
    private bool scoreAdded = false;
    /// <summary>
    /// creates a new input action for clicking and makes listeners
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
    /// runs AddPlayer score and enables different colliders and renderers based on which ones are clicked
    /// </summary>
    private void Update()
    {
        AddPlayerScore();
        if ( itemSwitch.BrushActive == true)
        {
            glueLoc1.GetComponent<Renderer>().enabled = true;
            glueLoc1.GetComponent<Collider>().enabled = true;
            glueLoc2.GetComponent<Renderer>().enabled = true;
            glueLoc2.GetComponent<Collider>().enabled = true;
            glueLoc3.GetComponent<Renderer>().enabled = true;
            glueLoc3.GetComponent<Collider>().enabled = true;
            glueLoc4.GetComponent<Renderer>().enabled = true;
            glueLoc4.GetComponent<Collider>().enabled = true;
        }
        else
        {
            glueLoc1.GetComponent<Renderer>().enabled = false;
            glueLoc1.GetComponent<Collider>().enabled = false;
            glueLoc2.GetComponent<Renderer>().enabled = false;
            glueLoc2.GetComponent<Collider>().enabled = false;
            glueLoc3.GetComponent<Renderer>().enabled = false;
            glueLoc3.GetComponent<Collider>().enabled = false;
            glueLoc4.GetComponent<Renderer>().enabled = false;
            glueLoc4.GetComponent<Collider>().enabled = false;
        }
        if (clickedGlueLocations >= 4)
        {
            glueLoc1.GetComponent<Renderer>().enabled = false;
            glueLoc1.GetComponent<Collider>().enabled = false;
            glueLoc2.GetComponent<Renderer>().enabled = false;
            glueLoc2.GetComponent<Collider>().enabled = false;
            glueLoc3.GetComponent<Renderer>().enabled = false;
            glueLoc3.GetComponent<Collider>().enabled = false;
            glueLoc4.GetComponent<Renderer>().enabled = false;
            glueLoc4.GetComponent<Collider>().enabled = false;
        }
    }
    /// <summary>
    /// casts a ray at mouse and checks to see which object its colliding with and adds clickedGlueLocations and then
    /// changes the color of that object. Then, in clickedGlueLocations is done it "glues the shoe" back together by
    /// enabling/disabling renderers
    /// </summary>
    /// <param name="context"></param>
    private void OnClick(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject == glueLoc1)
            {
                Renderer rend1 = glueLoc1.GetComponent<Renderer>();
                if (rend1.material.color == Color.red)
                {
                    clickedGlueLocations++;
                }
                rend1.material.color = Color.green;
            }else if (hitObject == glueLoc2)
            {
                Renderer rend1 = glueLoc2.GetComponent<Renderer>();
                if (rend1.material.color == Color.red)
                {
                    clickedGlueLocations++;
                }
                rend1.material.color = Color.green;
            }
            else if (hitObject == glueLoc3)
            {
                Renderer rend1 = glueLoc3.GetComponent<Renderer>();
                if (rend1.material.color == Color.red)
                {
                    clickedGlueLocations++;
                }
                rend1.material.color = Color.green;
            }
            else if (hitObject == glueLoc4)
            {
                Renderer rend1 = glueLoc4.GetComponent<Renderer>();
                if (rend1.material.color == Color.red)
                {
                    clickedGlueLocations++;
                }
                rend1.material.color = Color.green;
            }
        }
        if(clickedGlueLocations >= 4)
        {
            brokenSole.GetComponent<Renderer>().enabled = false;
            brokenSole.GetComponent<Collider>().enabled = false;
            fixedSole.GetComponent<Renderer>().enabled = true;
            fixedSole.GetComponent <Collider>().enabled = true;
            glueLoc1.GetComponent<Renderer>().enabled = false;
            glueLoc1.GetComponent<Collider>().enabled = false;
            glueLoc2.GetComponent<Renderer>().enabled = false;
            glueLoc2.GetComponent<Collider>().enabled = false;
            glueLoc3.GetComponent<Renderer>().enabled = false;
            glueLoc3.GetComponent<Collider>().enabled = false;
            glueLoc4.GetComponent<Renderer>().enabled = false;
            glueLoc4.GetComponent<Collider>().enabled = false;
            scoreAdded = true;
        }
    }
   /// <summary>
   /// adds score when all the locations are clicked
   /// </summary>
    private void AddPlayerScore()
    {
        if (scoreAdded == true && clickedGlueLocations == 4)
        {
            clickedGlueLocations++;
            scoreData.playerScore += 5;
            scoreAdded = false;
        }
    }
}