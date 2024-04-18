using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maria : MonoBehaviour
{
    private Animator mariaController;
    [SerializeField] private float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        mariaController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            speed += 0.5f;//speed=0+0.5=0.5 | speed=0.5+0.5=1
            mariaController.SetFloat("speed", speed);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            speed -= 0.5f;
            mariaController.SetFloat("speed", speed);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            mariaController.SetBool("IsRunning", true);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            mariaController.SetBool("IsRunning", false);
        }
    }
}
