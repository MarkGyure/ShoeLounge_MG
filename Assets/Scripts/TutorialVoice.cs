/*****************************************************************************
// File Name : TutorialVoice.cs 
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : handles the tutorial voice dialogue
*****************************************************************************/
using UnityEngine;
public class TutorialVoice : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip; // Assign your audio clip in the Inspector
    private AudioSource audioSource;
    /// <summary>
    /// Gets the AudioSource component attached to this GameObject and makes sure its assigned, and plays it
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No audio clip assigned to PlayAudioOnStart script.");
        }
    }
}