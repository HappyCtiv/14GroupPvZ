using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour
{
    public float speed = 0.2f;
    private float RanStop;

    void Start()
    {
        RanStop = Random.Range(-4.0f, 4.0f);
    }

    void FixedUpdate()
    {
        this.gameObject.transform.Translate(Vector2.down * speed);
        if (this.gameObject.transform.position.y < RanStop)
            speed = 0;
    }
}
