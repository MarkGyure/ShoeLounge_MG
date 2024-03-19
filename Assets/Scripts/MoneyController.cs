using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private int playerBalance = 999;
    [SerializeField] private TMP_Text balanceText;
    // Start is called before the first frame update
    public int PlayerBalance { get => playerBalance; set => playerBalance = value; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        balanceText.text = "Balance: " + playerBalance;
    }
}
