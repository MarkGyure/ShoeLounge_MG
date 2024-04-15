using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DayData", menuName = "Day Data")]

public class DayCounter : ScriptableObject
{
    [SerializeField] private int dayNumber = 2;

    //to get these, right click variable "Quick actions and refactorings" and encapsulate field.
 
    public int dayNumber1 { get => dayNumber; set => dayNumber = value; }
    public void GoNext()
    {
        Debug.Log("You have made it to day " + --dayNumber);
        dayNumber+=2;

    }
}
