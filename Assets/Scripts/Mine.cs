using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float maxTime = 3f;
    private float timerToExplode = 0f;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("empieza a reproducir el fx que hace referencia a una bomba cerca");
    }
    private void OnTriggerStay(Collider other)
    {
        timerToExplode += Time.deltaTime;
        Debug.Log("timer: " + timerToExplode);
        if (timerToExplode > 3f)
        {
            timerToExplode = 0f;
            Debug.Log("la mina explotó y mató al " + other.name);
            Destroy(other.gameObject);
            Debug.Log("deja de reproducir el fx que hace referencia a una bomba cerca y reproduce el fx de explosión");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        timerToExplode = 0f;
        Debug.Log("deja de reproducir el fx que hace referencia a una bomba cerca");
    }
}