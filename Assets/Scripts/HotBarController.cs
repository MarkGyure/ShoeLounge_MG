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
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (redOn)
            red.SetActive(true);
        if (orangeOn)
            red.SetActive(true);
        if (yellowOn)
            red.SetActive(true);
        if (limeOn)
            red.SetActive(true);
        if (greenOn)
            red.SetActive(true);
        if (tealOn)
            red.SetActive(true);
        if (cyanOn)
            red.SetActive(true);
        if (babyBlueOn)
            red.SetActive(true);
        if (blueOn)
            red.SetActive(true);
        if (purpleOn)
            red.SetActive(true);
        if (lavenderOn)
            red.SetActive(true);
        if (pinkOn)
            red.SetActive(true);
    }
}
