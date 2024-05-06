/*****************************************************************************
// File Name : RockController.cs
// Author : Mark Gyure
// Creation Date : 5/4/2024
// Brief Description : handles how the rocks are removed from the shoes
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
public class RockController : MonoBehaviour
{
    public GameObject[] rocks;
    private int rocksRemoved = 0;
    [SerializeField] private int targetAmount;
    [SerializeField] private ScoreData scoreData;
    [SerializeField] private ItemSwitch itemSwitch;
    [SerializeField] private int addScore;
    private InputAction clickAction;
    /// <summary>
    /// before the first frame updates the score display and the instatiates and enables the mouse click action
    /// </summary>
    void Start()
    {
        UpdateScoreDisplay();
        clickAction = new InputAction(binding: "<Mouse>/leftButton");
        clickAction.Enable();
        clickAction.performed += OnClick;
    }
    /// <summary>
    /// Logs how many rocks are removed to make sure everything is working properly
    /// </summary>
    void UpdateScoreDisplay()
    {
        Debug.Log("Score: " + rocksRemoved);
    }
    /// <summary>
    /// gets the click action and casts a ray to mouse position. if the ray is hitting a rock object and the pliars
    /// are active, then the renderer and collider of the rock are disabled giving it the effect that it disappeared
    /// and also adds the points when the target ammount is hit.
    /// </summary>g
    /// <param name="context"></param>
    private void OnClick(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (IsRock(hitObject) && itemSwitch.ForcepsActive == true)
            {
                hitObject.GetComponent<MeshRenderer>().enabled = false;
                hitObject.GetComponent<MeshCollider>().enabled = false;
                rocksRemoved++; 
                UpdateScoreDisplay();
                if (rocksRemoved >= targetAmount)
                {
                    scoreData.playerScore+= addScore;
                }
            }
        }
    }
    /// <summary>
    /// Disables the click action when this script is disabled or destroyed
    /// </summary>
    private void OnDisable()
    {
        clickAction.Disable();
    }
    /// <summary>
    /// Check if the GameObject is one of the rock GameObjects
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    bool IsRock(GameObject obj)
    {
        foreach (GameObject rock in rocks)
        {
            if (obj == rock)
            {
                return true;
            }
        }
        return false;
    }
}
