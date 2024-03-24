using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepController : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public float footstepInterval = 0.5f;
    public float footstepVolume = 1.0f; // Add this variable for volume control

    private AudioSource audioSource;
    private bool isWalking;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = footstepVolume; // Set the initial volume
        StartCoroutine(PlayFootsteps());
    }

    private void Update()
    {
        // Add your player movement detection logic here
        // For example, check if the player's velocity is greater than a certain threshold
        float playerVelocity = GetComponent<Rigidbody2D>().velocity.magnitude;
        isWalking = playerVelocity > 0.1f;
    }

    private IEnumerator PlayFootsteps()
    {
        while (true)
        {
            if (isWalking)
            {
                // Play a random footstep sound from the array
                AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
                audioSource.PlayOneShot(footstepSound);
            }

            yield return new WaitForSeconds(footstepInterval);
        }
    }
}
