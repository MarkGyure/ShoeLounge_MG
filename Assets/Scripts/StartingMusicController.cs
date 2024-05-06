/*****************************************************************************
// File Name : StartingMusicController.cs
// Author : Mark Gyure
// Creation Date : 5/4/2024
//
// Brief Description : Handles the music for the game
*****************************************************************************/
using UnityEngine;

public class StartingMusicController : MonoBehaviour
{
    [SerializeField] private AudioClip musicTrack; 
    private AudioSource audioSource;
    /// <summary>
    /// creates an AudioSource component and sets the audioclip to the audio sourcec
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicTrack;
        audioSource.Play();
        audioSource.volume = 0.1f;
        audioSource.loop = true;
    }
}
