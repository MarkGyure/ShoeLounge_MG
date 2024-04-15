using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialVoice : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip; // Assign your audio clip in the Inspector

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if an AudioClip is assigned
        if (audioClip != null)
        {
            // Assign the audio clip to the AudioSource component
            audioSource.clip = audioClip;

            // Play the audio
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No audio clip assigned to PlayAudioOnStart script.");
        }
    }
}
