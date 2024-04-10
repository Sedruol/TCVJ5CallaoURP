using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : MonoBehaviour
{
    private Animator animationMutant;
    [SerializeField] private float speed = 0;
    private void Start()
    {
        animationMutant = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))//Presione la tecla X?
        {
            speed += 0.5f;
            animationMutant.SetFloat("Speed", speed);//IMPORTANTE: se debe colocar el nombre correcto del par�metro
        }
        else if (Input.GetButtonDown("Fire1"))//Presione el bot�n izquierdo del mouse
        {
            animationMutant.SetTrigger("Attack");//IMPORTANTE: se debe colocar el nombre correcto del par�metro
        }
    }
}