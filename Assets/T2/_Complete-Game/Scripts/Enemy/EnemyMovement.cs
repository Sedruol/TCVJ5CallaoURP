using UnityEngine;
using System.Collections;
//=============================================================================
//añadir la liberia que nos permita usar NavMeshAgent
using UnityEngine.AI;
//=============================================================================

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;               // Nos ayudará a saber la posición del player
        PlayerHealth playerHealth;      // Nos ayudará a saber la vida del player
        EnemyHealth enemyHealth;        // Nos ayudará a saber la vida del enemigo
        NavMeshAgent nav;               // Referencia al componente de pathfinding


        void Awake()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();         //le asignamos el componente de pathfinding
        }


        void Update()
        {
            //Revisamos si el enemigo y el jugador aun tienen vida con un if{
            //Datos a saber: enemyHealth.currentHealth y playerHealth.currentHealth son las
            //variables que almacenan la vida del enemigo y player respectivamente
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                //cambia el destino del Componente de Pathfinding para que vaya donde el player
                // ... "Componente de Pathfinding".SetDestination(posicion del player) nos permite realizar el movimiento
                nav.SetDestination(player.position);
                //}
            }
            // caso contrario... else{
            else
            {
                // ... desactivamos el componente de Pathfinding.
                nav.enabled = false;
            }
            //}
        }
    }
}