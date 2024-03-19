using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHoverEffect : MonoBehaviour
{
 
    private void OnMouseEnter()
    {
        if (gameObject.transform.localScale.magnitude < 2f)
        {
            gameObject.transform.localScale *= 1.5f;
            Debug.Log("used MouseEnter");
        }
    }
    private void OnMouseExit()
    {
        if (gameObject.transform.localScale.magnitude > 1.5f)
        {
            gameObject.transform.localScale /= 1.5f;
            Debug.Log("used MouseExit");
        }
    }
}
