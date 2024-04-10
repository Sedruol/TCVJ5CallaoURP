using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersExample : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("entre en contacto");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entre en contacto trigger");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("mantengo el contacto trigger");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("terminó el contacto trigger");
    }
}