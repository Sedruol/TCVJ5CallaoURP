using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : MonoBehaviour
{
    [SerializeField] private Transform mutant;
    private float distance = 0f;
    private Animator animationPaladin;
    private void Start()
    {
        animationPaladin = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {//IMPORTANTE: se debe colocar el nombre correcto del parámetro
        animationPaladin.SetBool("IsRunning", true);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))//Presione el botón derecho del mouse
        {
            distance = Vector3.Distance(transform.position, mutant.position);
            Debug.Log("El paladin y el mutante se encuentran a una distancia de " + distance + " unidades");
        }
    }
}