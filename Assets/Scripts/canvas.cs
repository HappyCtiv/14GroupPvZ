using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvas : MonoBehaviour
{
    public Button[] buttons;
    public Sprite[] plantIc;
    public Sprite[] plantSp;

    [HideInInspector]
    public Vector2[] btnPositions;
    [HideInInspector]
    public Image gameover;
    void Start()
    {
        btnPositions = new Vector2[buttons.Length + 1];
        for (int i = 0; i < buttons.Length; i++)
        {
            btnPositions[i] = buttons[i].transform.position;
        }
        btnPositions[buttons.Length] = new Vector2(btnPositions[0].x, -Screen.height/10f);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addButton()
    {
        foreach(Button b in buttons)
        {
            b.GetComponent<ButtonScript>().increment();
            if (b.GetComponent<ButtonScript>().index==1)
            {
                return;
            }
        }
    }
}
