using UnityEngine;
using UnityEngine.Audio;

public abstract class Picture : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // ABSTRACTION
        MakeSound();
    }

    // ENCAPSULATION
    protected virtual void MakeSound()
    {
        audioSource.Play();
    }
   
}
