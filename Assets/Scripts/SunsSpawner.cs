using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunsSpawner : MonoBehaviour
{
    public GameObject Sun;
    public float XPos;
    public float YPos;
    private int SunCount = 1;

    public float speed = 0.2f;
    public float changeTime = 1.5f;
    float timer;
    private float dir;

    void Start()
    {
        dir = 1.0f;
        StartCoroutine(SunDrop());
    }

    void FixedUpdate()
    {
       this.gameObject.transform.Translate(Vector2.down * speed);
       
        if (transform.position.y < 4.0f)
            dir = Mathf.Abs(dir);
        else if (transform.position.y < -4.0f)
            dir = Mathf.Abs(dir) * 0;
    }

    
    IEnumerator SunDrop()
    {
        while (SunCount>-1)
        { 
            XPos = Random.Range(-6.66f,6.66f);
            YPos = 6.25f;
            Instantiate(Sun, new Vector2(XPos,YPos), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(10.0f, 15.0f));
            SunCount++;
        }
    }


}
