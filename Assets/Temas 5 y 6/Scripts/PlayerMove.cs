using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject inBullet;//objeto de donde saldrá la bala
    [SerializeField] GameObject bullet;//prefab de la bala
    [SerializeField] Transform parentBullet;//objeto donde almacenaremos todas las balas
    [SerializeField] float velocityBullet;//velocidad de las balas
    private Rigidbody rb;
    private float time;
    public float tiempoEntreDisparo = 0.25f;
    [Header("Object Pooling")]
    //object pooling
    [SerializeField] int poolBullets;//cuantas balas creará en un inicio
    [SerializeField] List<GameObject> bullets;//lista para almacenar las balas
    private int existBullet;//cuantas balas existen
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //GenerateBullets();
    }
    //object pooling
    //private void GenerateBullets()
    //{//creamos en un inicio "poolBullets" (cantidad) balas
    //    for (int i = 0; i < poolBullets; i++)
    //    {//crear bala
    //        GameObject temp = Instantiate(bullet, inBullet.transform.position, Quaternion.identity, parentBullet);
    //        temp.SetActive(false);//desactivar bala creada
    //        bullets.Add(temp);//añadimos la bala a la lista
    //    }
    //}

    // Update is called once per frame
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
            if (time >= tiempoEntreDisparo)
            {
                time = 0f;
                CreateBullets();
            }
            //CreateBulletsOptimizated();
        }
        else if (Input.GetMouseButtonUp(0)){
            time = 0f;
        }
    }
    private void CreateBullets()
    {//Instantiate(prefab, posicion, rotacion, que sea hijo de este objeto)
        GameObject temp = Instantiate(bullet, inBullet.transform.position, Quaternion.identity, parentBullet);
        temp.GetComponent<Rigidbody>().AddForce(transform.up * velocityBullet);
    }
    //object pooling
    //private void CreateBulletsOptimizated()
    //{//recorremos nuestra lista de balas
    //    for (int i = 0; i < bullets.Count; i++)
    //    {//encontró una bala desactivada?
    //        if (!bullets[i].activeSelf)
    //        {//cambia la posicion de la bala, la activa y le da una fuerza hacia arriba
    //            bullets[i].transform.position = inBullet.transform.position;
    //            bullets[i].SetActive(true);
    //            bullets[i].GetComponent<Rigidbody>().AddForce(transform.up * velocityBullet);
    //            existBullet = 0;//reinicia el contador de balas existentes
    //            break;//cierra el for
    //        }//cuando no encuentra una bala desactivada en la posicion "i"
    //        existBullet++;//aumentará su contador de balas existentes en 1
    //        if (existBullet == bullets.Count)//el contador de balas existentes es igual al tamaño de la lista de balas
    //        {//entrará aquí cuando todas las balas esten activadas
    //            existBullet = 0;//reinicia el contador de balas existentes
    //            poolBullets++;//aumentará el tamaño de la lista de balas en 1
    //            GameObject temp = Instantiate(bullet, inBullet.transform.position, Quaternion.identity, parentBullet);
    //            temp.GetComponent<Rigidbody>().AddForce(transform.up * velocityBullet);
    //            bullets.Add(temp);
    //        }//creamos una bala mas, le damos movimiento y lo añadimos a la lista de balas
    //    }
    //}
}