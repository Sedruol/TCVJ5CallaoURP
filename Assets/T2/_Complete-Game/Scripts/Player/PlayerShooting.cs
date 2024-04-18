using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerShooting : MonoBehaviour
    {
        //=============================================================================
        //Variables
        public Transform bulletsParent;                        //usaremos este objeto para que sea el padre de todas las balas creadas
        [SerializeField] private GameObject bullet;            //almacena el prefab de bala
        //=============================================================================
        public static float timeBetweenBullets = 0.15f;        // Tiempo entre cada disparo.


        float timer;                                    // Un cronometro para determinar cuando disparar.
        ParticleSystem gunParticles;                    // Referencia al sistema de particulas.
        AudioSource gunAudio;                           // Referencia al audio source.
        Light gunLight;                                 // Referencia al componente de luz.
        public Light faceLight;							// Duh
        float effectsDisplayTime = 0.2f;                // La proporción del tiempo entre balas durante el cual se mostrarán los efectos.


        void Awake()
        {
            // Configura las referencias.
            gunParticles = GetComponent<ParticleSystem>();
            gunAudio = GetComponent<AudioSource>();
            gunLight = GetComponent<Light>();
            //faceLight = GetComponentInChildren<Light> ();
        }


        void Update()
        {
            // La variable timer va incrementando su valor conforme avanza el tiempo.
            timer += Time.deltaTime;

            // Si se está presionando el botón izquierdo del mouse y el timer es mayor al tiempo de espera entre cada disparo...
            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                // ... Dispara
                Shoot();
            }
            // Si el timer ha excedido la proporción de tiempo entre balas durante el cual los efectos deben mostrarse...
            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                // ... Desactiva los efectos
                DisableEffects();
            }
        }


        public void DisableEffects()
        {// Desactiva el line renderer y las luces.
            faceLight.enabled = false;
            gunLight.enabled = false;
        }


        void Shoot()
        {
            // Reinicia el timer.
            timer = 0f;

            // Reproduce el audioclip de disparo.
            gunAudio.Play();

            // Activa las luces.
            gunLight.enabled = true;
            faceLight.enabled = true;

            // Detenemos las particulas para volver a activarlas.
            gunParticles.Stop();
            gunParticles.Play();

            //=============================================================================
            // Creamos un GameObject "temp", al cual le asignaremos el valor del GameObject de la bala creada
            // Para la creación de la bala, usaremos: Instantiate(prefab, posicion de la "mira" de la escopeta, rotacion normal, padre donde colocaremos las balas)
            GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity, bulletsParent);
            // Le asignamos movimiento a la bala que creamos previamente a través del GameObject creado
            // Como el personaje rota constantemente puede usar la propiedad vista en clase para referirse al frente del objeto
            temp.GetComponent<Rigidbody>().AddForce(transform.forward * 750);
            //=============================================================================
        }
    }
}