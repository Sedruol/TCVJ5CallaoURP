using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshController : MonoBehaviour
{
    [SerializeField] private Transform objective;
    private NavMeshAgent agent;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = objective.position;
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        //agent.destination = enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = objective.position;
        //agent.destination = enemy.transform.position;
    }
}