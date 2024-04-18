using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    [SerializeField] GameObject meteorite;//prefab del meteoro
    [SerializeField] float timeCreation;//tiempo que pasará entre cada creación de meteoros
    [SerializeField] Transform meteoriteParent;//objeto donde almacenaremos todos los meteoros
    private float time = 0f;//tiempo que usaremos de contador
    private Vector3 meteoritePosition;//posicion del meteoro
    [Header("Object Pooling")]
    [SerializeField] List<GameObject> meteorites = new List<GameObject>(5);//lista para almacenar los meteoritos

    // Start is called before the first frame update
    void Start()
    {
        //GenerateMeteors();
    }
    //private void GenerateMeteors()
    //{
    //    for (int i = 0; i < meteorites.Count; i++)
    //    {
    //        meteorites[i] = Instantiate(meteorite, new Vector3(0f, 6f, 0f), Quaternion.identity, transform);
    //        meteorites[i].SetActive(false);
    //    }
    //}
    
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

    // Update is called once per frame
    void Update()
    {
        CreateMeteors();
        //CreateMeteorsOptimizated();
    }
    //private void CreateMeteorsOptimizated()
    //{
    //    time += Time.deltaTime;
    //    if (time >= timeCreation)
    //    {
    //        time = 0f;
    //        for (int i = 0; i < meteorites.Count; i++)
    //        {
    //            if (!meteorites[i].activeSelf)
    //            {
    //                meteorites[i].transform.position = new Vector3(Random.Range(-2f, 2.01f), 6f, 0f);
    //                meteorites[i].SetActive(true);
    //                break;
    //            }
    //        }
    //    }
    //}
}
