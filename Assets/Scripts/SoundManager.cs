using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int soundIndex)
    {
        if (soundIndex < 0 || soundIndex >= sounds.Length)
        {
            Debug.LogWarning("Invalid sound index!");
            return;
        }

        // Stop the currently playing sound
        audioSource.Stop();

        // Assign and play the new sound
        audioSource.clip = sounds[soundIndex];
        audioSource.Play();
    }
}
