using UnityEngine;
using System.Collections;

public class BuyController : MonoBehaviour
{
    [SerializeField] private MoneyController MoneyController;
    [SerializeField] private int cost;
    [SerializeField] private GameObject item;
    public ParticleSystem particle; // Reference to the Particle System

    void Start()
    {
        print(MoneyController.PlayerBalance + " money.");
      

        // Ensure the Particle System is not playing initially
        particle.Stop();
    }

    void OnMouseDown()
    {
        if (MoneyController.PlayerBalance > cost)
        {
            // Check if the Particle System is not already playing
            if (!particle.isPlaying)
            {
                // Play the Particle System
                particle.Play();

                

                // Start a coroutine to stop the Particle System after one second
                StartCoroutine(StopParticleSystemAfterDelay(1f));
                MoneyController.PlayerBalance -= cost;
                Destroy(item);
            }
        }
    }

    IEnumerator StopParticleSystemAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Stop the Particle System after the delay
        particle.Stop();
    }
}
