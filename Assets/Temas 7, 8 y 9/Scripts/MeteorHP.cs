using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHP : MonoBehaviour
{
    public int hp = 100;
    public int damageMeteor = 20;
    public void TakeDamage(int damage, Vector3 position)
    {
        hp -= damage;
        Debug.Log("posicion de impacto: " + position);
        if (hp <= 0)
            Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("player hp: " + PlayerMoveV2.playerHP);
        PlayerMoveV2.playerHP -= damageMeteor;
        Debug.Log("player hp: " + PlayerMoveV2.playerHP);
        Destroy(this.gameObject);
    }
}