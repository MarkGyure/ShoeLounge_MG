/*****************************************************************************
// File Name : LightChange.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description :Handles how the lighting colors fade and switch between eachother
*****************************************************************************/
using UnityEngine;
public class LightChange : MonoBehaviour
{
    float duration = 55f;
    Color orangeColor = new Color(0.85f, 0.76f, 0.56f);
    Color whiteColor = new Color(1.0f, 1.0f, 1.0f);
    Color pinkColor = new Color(0.87f, 0.73f, 0.87f);
    Light lt;
    private bool nextColor;
    private bool nextLight;
    [SerializeField] private Light mainLight;
    [SerializeField] private GameObject fakeSun;
    private float startIntensity = 0.4f;
    private float midIntensity = 1.0f;
    private float endIntensity = 0.0f;
    private float speed = 0.25f;
    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        lt = GetComponent<Light>();
    }
    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        fakeSun.transform.Translate(Vector3.right * speed * Time.deltaTime);
        float t = Mathf.PingPong(Time.time, duration) / duration;
        if (nextLight == false)
        {
            mainLight.intensity = Mathf.Lerp(startIntensity, midIntensity, t);
        }
        if (mainLight.intensity >= 0.95f)
        {
            nextLight = true;
        }
        if (nextLight == true)
        {
            mainLight.intensity = midIntensity;
            mainLight.intensity = Mathf.Lerp(endIntensity, midIntensity, t);
        }
        if (nextColor == false)
        {
            lt.color = Color.Lerp(orangeColor, whiteColor, t);
        }
        if (lt.color == Color.white || lt.color == whiteColor)
        {
            nextColor = true;
        }
        if (nextColor == true)
        {
            lt.color = Color.Lerp(pinkColor, whiteColor, t);
        }
    }
}