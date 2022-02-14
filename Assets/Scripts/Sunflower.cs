using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : plant
{
    private float sunTime = 8f;
    public GameObject _sun;


    void Update()
    {
        timer+= Time.deltaTime;
        if (timer>=sunTime)
        {
            timer = 0f;
            SpawnSun();
        }
    }

    private void SpawnSun()
    {
        GameObject sun = Instantiate(_sun, new Vector2(transform.position.x + Random.Range(-0.5f,0.5f), transform.position.y + Random.Range(-0.5f,0.5f)),
        Quaternion.identity, transform);
        sun.GetComponent<SunsSpawner>().sunFlowerMade = true;
    }
}
