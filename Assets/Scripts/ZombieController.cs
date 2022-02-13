using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float speed;
    public float changeTime = 1.5f;

    bool alive = true;
    float timer;
    


    Rigidbody2D VirusRB2D;
    void Start()
    {
        VirusRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }
        Vector2 position = GetComponent<Rigidbody2D>().position;

        position.x = position.x - Time.deltaTime * speed;

        GetComponent<Rigidbody2D>().MovePosition(position);
    }
}
