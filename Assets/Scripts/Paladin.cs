using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : MonoBehaviour
{
    [SerializeField] private Transform mutant;
    private float distance = 0f;
    private Animator animationPaladin;
    private int corriendo = 0;
    [SerializeField] private bool estacorriendo = false;
    private void Start()
    {
        animationPaladin = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {//IMPORTANTE: se debe colocar el nombre correcto del parámetro
        //animationPaladin.SetBool("IsRunning", true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))//Presione la tecla A?
        {
            animationPaladin.SetBool("IsRunning", true);
            //if (corriendo == 0)
            //{
            //    corriendo = 1;
            //    animationPaladin.SetBool("IsRunning", true);
            //}
            //else if (corriendo == 1)
            //{
            //    corriendo = 0;
            //    animationPaladin.SetBool("IsRunning", false);
            //}
            //if (!estacorriendo)//estacorriendo != true | esta corriendo == false
            //{
            //    estacorriendo = true;
            //    animationPaladin.SetBool("IsRunning", true);
            //}
            //else
            //{
            //    estacorriendo = false;
            //    animationPaladin.SetBool("IsRunning", false);
            //}
        }
        if (Input.GetKeyDown(KeyCode.S))//Presione la tecla S?
        {
            animationPaladin.SetBool("IsRunning", false);
        }
        //if (Input.GetKeyUp(KeyCode.A))//Solte la tecla A?
        //{
        //    animationPaladin.SetBool("IsRunning", false);
        //}
        if (Input.GetButtonDown("Fire1"))//Presione el botón izquierdo del mouse?
        {
            animationPaladin.SetTrigger("Attack");
        }
        if (Input.GetButtonDown("Fire2"))//Presione el botón derecho del mouse?
        {
            animationPaladin.SetTrigger("Jump");
            //distance = Vector3.Distance(transform.position, mutant.position);
            //Debug.Log("El paladin y el mutante se encuentran a una distancia de " + distance + " unidades");
        }
    }
}