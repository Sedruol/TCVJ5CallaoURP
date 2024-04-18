using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeAudios : MonoBehaviour
{
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (audioSource.clip.name != music1.name)
            {
                audioSource.clip = music1;
                audioSource.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (audioSource.clip.name != music2.name)
            {
                audioSource.clip = music2;
                audioSource.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (audioSource.clip.name != music3.name)
            {
                audioSource.clip = music3;
                audioSource.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!audioSource.isPlaying)
                audioSource.UnPause();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
        }
    }
}
