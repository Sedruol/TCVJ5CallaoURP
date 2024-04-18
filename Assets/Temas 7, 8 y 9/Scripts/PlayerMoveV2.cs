using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveV2 : MonoBehaviour
{
    [SerializeField] GameObject inBullet;//objeto de donde saldrá la bala
    [SerializeField] GameObject bullet;//prefab de la bala
    [SerializeField] Transform parentBullet;//objeto donde almacenaremos todas las balas
    [SerializeField] float velocityBullet;//velocidad de las balas
    public static int playerHP = 100;
    public MeshRenderer meshRenderer;
    public Material material;
    public static float timeToShoot = 0.2f;
    private float time;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D))//movimiento derecha
        {
            rb.velocity = transform.right * 5;
        }
        else if (Input.GetKey(KeyCode.A))//movimiento izquierda
        {
            rb.velocity = -transform.right * 5;
        }
        if (Input.GetMouseButton(0))//al presionar el boton izquierdo del mouse
        {
            time += Time.deltaTime;
            if (time >= timeToShoot)
                CreateBullets();
            //CreateBulletsOptimizated();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            time = 0;
        }
        if (playerHP <= 0)
        {
            Debug.Log("Perdiste");
        }
    }
    private void CreateBullets()
    {
        time = 0;
        //Instantiate(prefab, posicion, rotacion, que sea hijo de este objeto)
        GameObject temp = Instantiate(bullet, inBullet.transform.position, Quaternion.identity, parentBullet);
        temp.GetComponent<Rigidbody>().AddForce(transform.up * velocityBullet);
    }
    //Modificadores
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Modificators"))
        {
            Debug.Log("entre");
            switch (other.name)
            {
                case "DoubleDamage":
                    BulletV2.damage *= 2;
                    break;
                case "HalfReductionTimeBetweenBullets":
                    PlayerMoveV2.timeToShoot /= 2;
                    break;
                case "ChangeMaterial":
                    Debug.Log("mat");
                    meshRenderer.material = material;
                    break;
            }
        }
        else if (other.gameObject.CompareTag("Tramps"))
        {
            switch (other.name)
            {
                case "Reduccion de Daño":
                    BulletV2.damage /= 2;
                    break;
            }
        }
        Destroy(other.gameObject);
    }
}
