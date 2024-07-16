using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPuas : MonoBehaviour
{
    public int damagePuas = 15;
    public float timeToMakeDamage = 3f;
    private float time;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            time = 0f;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            time += Time.deltaTime;
            if (time >= timeToMakeDamage)
            {
                time = 0;
                Debug.Log("player hp pre daño: " + PlayerMoveV2.playerHP);
                PlayerMoveV2.playerHP -= damagePuas;
                Debug.Log("player hp post daño: " + PlayerMoveV2.playerHP);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            time = 0f;
        }
    }
}
