using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private int plantID;
    public int index;
    private float speed = 100f;
    private static int[] costs = new int[2] {50,100};

    

    PlayerController gm;
    canvas can;
    void Awake()
    {
        plantID = Random.Range(0,2);
    }

    void Start()
    {
        can = GameObject.Find("Canvas").GetComponent<canvas>();
        gm = GameObject.Find("_GM").GetComponent<PlayerController>();
        index = 0;
    }

    void Update()
    {
        manageMovement();
    }

    private void manageMovement()
    {
        if (index >0 )
        {
            transform.position = Vector2.MoveTowards(
            transform.position,
            can.btnPositions[index],
            speed
            );
        }
        if (transform.position.y < -Screen.height/10f)
        {
            transform.position = can.btnPositions[0];
            index = 0;
        }
    }

    public void clicked()
    {
        if (gm.SunCount >= costs[plantID])
        {
            gm.setPlantID(plantID);
            gm.SunCount -= costs[plantID];
            gm.SetCountText(gm.SunCount);
        }
    }


    public void increment()
    {
        index++;
    }
}
