using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //=============================================================================
    //Variables
    private AudioSource audioSource;                         //Crear una variable de un componente de audio
    public AudioClip music1;                                 //Crear una variable que almacene un archivo de musica
    public AudioClip music2;                                 //Crear una variable que almacene un archivo de musica
    public AudioClip music3;                                 //Crear una variable que almacene un archivo de musica
    //=============================================================================
    void Start()
    {
        //le asignamos un valor a la variable del componente de audio
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //=============================================================================
        //Configurar el componente de audio para cumplir con los requisitos descritos en el documento de instrucciones
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
        //=============================================================================
    }
}
