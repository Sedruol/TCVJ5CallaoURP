using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject other;
    public float speed = 5f;
    public float speedRotation = 5f;
    private Rigidbody rb;
    private Animator animator;
    private float moveHorizontal = 0f;
    private float moveVertical = 0f;
    private CharacterController cc;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    // Usar FixedUpdate cuando usemos fuerzas
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        //-------------------------
        //Transform.position | Recomendado para objetos que no tienen colisiones, como una camara, un efecto visual o un personaje de un juego donde las colisiones no sean importantes
        //-------------------------
        //Vector3 movementDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);//y=1.89
        //movementDirection.Normalize();
        //transform.position = transform.position + movementDirection * speed * Time.deltaTime;
        //if (movementDirection != Vector3.zero)
        //{
        //    animator.SetBool("IsRunning", true);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), speedRotation * Time.deltaTime);
        //}
        //else
        //{
        //    animator.SetBool("IsRunning", false);
        //}

        //-------------------------
        //Rigidbody AddForce | misiles o carros en juegos | Fall guys
        //-------------------------
        //Activar Freeze Rotation
        //Vector3 movementDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //rb.AddForce(movementDirection * speed, ForceMode.Acceleration);//speed=150, ForceMode.Acceleration=ignorar la masa
        //if (movementDirection != Vector3.zero)
        //{
        //    animator.SetBool("IsRunning", true);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), speedRotation * Time.deltaTime);
        //}
        //else
        //{
        //    animator.SetBool("IsRunning", false);
        //}

        //-------------------------
        //Rigidbody.MovePosition
        //-------------------------
        Vector3 movementDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.MovePosition(rb.position + movementDirection.normalized * speed * Time.deltaTime);
        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsRunning", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), speedRotation * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        //-------------------------
        //CharacterController
        //-------------------------
        //Vector3 movementDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //cc.Move(movementDirection.normalized * speed * Time.deltaTime);
        //if (movementDirection != Vector3.zero)
        //{
        //    animator.SetBool("IsRunning", true);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), speedRotation * Time.deltaTime);
        //}
        //else
        //{
        //    animator.SetBool("IsRunning", false);
        //}


        //-------------------------
        //Rigidbody.velocity, juegos sin gravedad
        //-------------------------
        //rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);//y=0
        //if (rb.velocity != Vector3.zero)
        //{
        //    animator.SetBool("IsRunning", true);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rb.velocity), speedRotation * Time.deltaTime);
        //}
        //else
        //{
        //    animator.SetBool("IsRunning", false);
        //}
    }
    private void Update()
    {
        //Enabled
        if (Input.GetKeyDown(KeyCode.A))
        {
            other.GetComponent<BoxCollider>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            other.GetComponent<BoxCollider>().enabled = true;
        }
    }
}