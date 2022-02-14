using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunsSpawner : MonoBehaviour
{
    public GameObject Sun;
    public float XPos;
    public float YPos;


    public float speed = 0.2f;
    public float changeTime = 1.5f;
    private float timer;
    private float lifeSpan = 8f;
    private bool fade;
    private float fadeSpeed = 0.05f;
    public bool sunFlowerMade;


    private float dir;

    void Start()
    {
        fade = false;
        dir = 1.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeSpan)
        {
            death();
        }

        if (!sunFlowerMade)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (fade)
        {
            Color spColor = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(
                spColor.r,
                spColor.g,
                spColor.b,
                spColor.a - fadeSpeed
            );
            if (spColor.a <=0)
            {
                Destroy(gameObject);
            }
        }


        
    }

    void FixedUpdate()
    {
       this.gameObject.transform.Translate(Vector2.down * speed);
       
        if (transform.position.y < 4.0f)
            dir = Mathf.Abs(dir);
        else if (transform.position.y < -4.0f)
            dir = Mathf.Abs(dir) * 0;
    }

    public void death()
    {
        fade = true;
    }


}
