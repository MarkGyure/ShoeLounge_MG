/*****************************************************************************
// File Name : HotbarController.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : Handles the hotbar
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HotBarController : MonoBehaviour
{
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject oranage;
    [SerializeField] private GameObject yellow;
    [SerializeField] private GameObject lime;
    [SerializeField] private GameObject green;
    [SerializeField] private GameObject teal;
    [SerializeField] private GameObject cyan;
    [SerializeField] private GameObject babyBlue;
    [SerializeField] private GameObject blue;
    [SerializeField] private GameObject purple;
    [SerializeField] private GameObject lavender;
    [SerializeField] private GameObject pink;
    [SerializeField] private bool redOn;
    [SerializeField] private bool orangeOn;
    [SerializeField] private bool yellowOn;
    [SerializeField] private bool limeOn;
    [SerializeField] private bool greenOn;
    [SerializeField] private bool tealOn;
    [SerializeField] private bool cyanOn;
    [SerializeField] private bool babyBlueOn;
    [SerializeField] private bool blueOn;
    [SerializeField] private bool purpleOn;
    [SerializeField] private bool lavenderOn;
    [SerializeField] private bool pinkOn;
  /// <summary>
  /// called before first frame, sets all visuals to not be seen
  /// </summary>
    void Start()
    {
        red.SetActive(false);
        oranage.SetActive(false);
        yellow.SetActive(false);
        lime.SetActive(false);
        green.SetActive(false);
        teal.SetActive(false);
        cyan.SetActive(false);
        babyBlue.SetActive(false);
        blue.SetActive(false);
        purple.SetActive(false);
        lavender.SetActive(false);
        pink.SetActive(false);    
    }

  /// <summary>
  /// called once per frame and checks to see if the bool is on, if it is, it makes it appear
  /// </summary>
    void Update()
    {
        if (redOn)
            red.SetActive(true);
        else red.SetActive(false);
        if (orangeOn)
            oranage.SetActive(true);
        else oranage.SetActive(false);
        if (yellowOn)
            yellow.SetActive(true);
        else yellow.SetActive(false);
        if (limeOn)
            lime.SetActive(true); 
        else lime.SetActive(false);
        if (greenOn)
            green.SetActive(true); 
        else green.SetActive(false);
        if (tealOn)
            teal.SetActive(true); 
        else teal.SetActive(false);
        if (cyanOn)
            cyan.SetActive(true); 
        else cyan.SetActive(false);
        if (babyBlueOn)
            babyBlue.SetActive(true); 
        else babyBlue.SetActive(false);
        if (blueOn)
            blue.SetActive(true); 
        else blue.SetActive(false);
        if (purpleOn)
            purple.SetActive(true); 
        else purple.SetActive(false);
        if (lavenderOn)
            lavender.SetActive(true); 
        else lavender.SetActive(false);
        if (pinkOn)
            pink.SetActive(true); 
        else pink.SetActive(false);
    }
}
