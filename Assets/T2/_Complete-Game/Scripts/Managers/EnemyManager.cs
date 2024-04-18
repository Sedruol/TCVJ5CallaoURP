using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Referencia al Script PlayerHealth
        public GameObject enemy;                // El prefab del enemigo que se usará en el spawn
        public float spawnTime = 3f;            // El tiempo que habrá entre cada spawn
        public Transform spawnPoint;         // An array of the spawn points this enemy can spawn from.


        void Start ()
        {
            // Llama a la función Spawn después de un tiempo de espera equivalente al spawnTime y luego vuelve a llamarlo despues de transcurrir este mismo tiempo
            // InvokeRepeating(nombre de la función, tiempo que esperará para que se ejecute la función por primera vez, tiempo que esperará para volver a repetir la función)
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }


        void Spawn ()
        {
            // ¿El jugador ya no tiene vida?
            if(playerHealth.currentHealth <= 0f)
            {
                // Salimos de la función
                return;
            }

            // Crea una instancia del prefab del enemigo en la posición escogida y con su rotacion
            // Instantiate (prefab, posicion, rotacion)
            Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }
}