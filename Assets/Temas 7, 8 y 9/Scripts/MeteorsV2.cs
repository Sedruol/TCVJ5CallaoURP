using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsV2 : MonoBehaviour
{
    [SerializeField] private GameObject meteorite;//prefab del meteoro
    [SerializeField] private float timeCreation;//tiempo que pasará entre cada creación de meteoros
    [SerializeField] private Transform meteoriteParent;//objeto donde almacenaremos todos los meteoros
    private float time = 0f;//tiempo que usaremos de contador
    private Vector3 meteoritePosition;//posicion del meteoro

    private void CreateMeteors()
    {
        time += Time.deltaTime;
        if (time >= timeCreation)
        {
            time = 0f;
            meteoritePosition = new Vector3(Random.Range(-2f, 2.01f), 6f, 0f);
            Instantiate(meteorite, meteoritePosition, Quaternion.identity, meteoriteParent);
        }
    }

    void Update()
    {
        if (PlayerMoveV2.playerHP > 0)
            CreateMeteors();
    }
}