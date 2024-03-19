using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHoverEffect : MonoBehaviour
{
    [SerializeField] private GameObject fakeButton;
 
    private void OnMouseOver()
    {
        if (fakeButton.gameObject.transform.localScale.magnitude < 2f)
        {
            fakeButton.gameObject.transform.localScale *= 1.5f;
            Debug.Log("used MouseOver");
        }
    }
    private void OnMouseEnter()
    {
        if (fakeButton.gameObject.transform.localScale.magnitude < 2f)
        {
            fakeButton.gameObject.transform.localScale *= 1.5f;
            Debug.Log("used MouseEnter");
        }
    }
    private void OnMouseExit()
    {
        if (fakeButton.gameObject.transform.localScale.magnitude > 1.5f)
        {
            fakeButton.gameObject.transform.localScale /= 1.5f;
            Debug.Log("used MouseExit");
        }
    }
}
