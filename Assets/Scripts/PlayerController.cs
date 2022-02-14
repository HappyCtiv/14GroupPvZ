using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
public Text ScoreText;


private int plantActiveID = -1;



public GameObject p_sunflower;
public GameObject p_pea;
public GameObject p_sun;
public GameObject p_zombie;

public GameObject canvas;
public GameObject plantTemp;
public GameObject tile;
public Color c1;
public Color c2;


private int SunScore;
public int SunCount{
    get{return SunScore; } 
    set{ SunScore = value;
    if (SunScore<0)
    {
        SunScore = 0;
    }
    }

}


void Start()
{
    SunScore = 0;
    SetCountText(SunScore);


    InvokeRepeating("spawnSun", 5f, 5f);
    
}

public void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        mouseClick();
    }
    mouseHover();
    plantTempMng();
}

public void SetCountText(int amount)
{
    ScoreText.text = amount.ToString();
}


private void plantTempMng()
{
    if (plantActiveID > -1)
    {
        plantTemp.GetComponent<SpriteRenderer>().enabled = true;
        plantTemp.GetComponent<SpriteRenderer>().sprite = canvas.GetComponent<canvas>().plantSp[plantActiveID];
    }
    else
    {
        plantTemp.GetComponent<SpriteRenderer>().enabled = false;
    }
}


private void mouseHover()
{
    Ray ray;
    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit))
    {
        if (hit.transform.gameObject.tag == "tile")
        {
            plantTemp.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.2f,0);
        }
    }
    else
    {
        plantTemp.transform.position = new Vector3(
        Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 0.2f, 0);       
    }
}


public void addSun(int amount)
{
    SunScore += amount;
}

private void mouseClick()
{
    Ray ray;
    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit))
    {
        if (hit.transform.gameObject.tag == "tile" && plantActiveID > -1 && !hit.transform.gameObject.GetComponent<tile>().hasPlant)
        {
            hit.transform.gameObject.GetComponent<tile>().plant(getPlant(plantActiveID));
            plantActiveID = -1;
        }

        else if ((hit.transform.gameObject.tag == "Collectible") && (hit.collider !=null)) 
        {
            hit.transform.gameObject.GetComponent<SunsSpawner>().death();
            addSun(25);
            SetCountText(SunScore);
        }
    }
}

private void spawnSun()
{
    float XPos = Random.Range(-6.0f,6.0f);
    GameObject sun = Instantiate (p_sun, new Vector2(XPos,6.25f), Quaternion.identity);
}


private GameObject getPlant(int id)
{
    switch (id)
    {
        case 0:return p_sunflower;
        case 1:return p_pea;
        default: return p_sunflower;
    }
}

public void setPlantID(int id) 
{
    plantActiveID = id;
}

}
