using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
public Text ScoreText;
private int SunScore = 0;


void Start()
{
    SunScore = 0;
    SetCountText();

}

public void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if ((hit.collider !=null) && (GameObject.FindGameObjectWithTag ("Collectible") != null)) 
            {
                Destroy(hit.collider.gameObject);
                SunScore+=25;
                SetCountText();
            }
    }
}

void SetCountText()
{
    ScoreText.text = SunScore.ToString();
}

}
