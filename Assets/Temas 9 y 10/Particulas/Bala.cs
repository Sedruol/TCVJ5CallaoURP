using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocityBullet;//velocidad de las balas
    public ParticleSystem particles;//almacena el sistema de particulas
    public AudioSource audioSource;//almacena el audio
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.right * velocityBullet);
    }

    private void OnTriggerEnter(Collider other)
    {
        particles.transform.position = other.transform.position;
        particles.Play();
        audioSource.Play();
        Destroy(other.gameObject);
    }
}