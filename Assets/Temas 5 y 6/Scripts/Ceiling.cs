using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Destruimos el objeto con el que colisionamos, es decir, destruye la bala
        Destroy(other.gameObject);
        //desactivamos los objetos que colisionen con el techo
        //other.gameObject.SetActive(false);
    }
}
