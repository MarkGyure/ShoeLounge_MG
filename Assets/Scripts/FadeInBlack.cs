/*****************************************************************************
// File Name : FadeInBlack
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : Controlls the fade into black effect for entering scenes.
*****************************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class FadeInBlack : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1.0f; 
    private Image image;
    /// <summary>
    /// Runs before the first frame is called. gets the image component and sets the alpha (brightness) to 1 
    /// which maxes it out and makes it completely black
    /// </summary>
    private void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(0, 0, 0, 1); // Set alpha to 1 for full black at start
        StartCoroutine(FadeFromBlack());
    }
    /// <summary>
    /// handles how fast the screen fades by decresing alpha over time instead of instantly
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeFromBlack()
    {
        float elapsedTime = 0;
        Color color = image.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            color.a = 1 - t; // Decrease alpha from 1 to 0
            image.color = color;
            yield return null;
        }
        // Check if the image is completely see-through
        if (color.a == 0f)
        {
            image.enabled = false;
        }
    }
}
