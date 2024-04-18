using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletV2 : MonoBehaviour
{
    public static int damage = 20;//variable de daño
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dmg: " + damage);
        if (other.gameObject.CompareTag("Enemy"))
        {
            MeteorHP meteorHP = other.gameObject.GetComponent<MeteorHP>();
            if (meteorHP != null)
            {
                // ... el enemigo sufrirá daño.
                meteorHP.TakeDamage(damage, other.transform.position);
            }
            Destroy(this.gameObject);
        }
    }
}