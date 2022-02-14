using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    [SerializeField]
    protected int hp;
    protected float timer;

    public void updateHp(int amount)
    {
        hp += amount;
        if (hp<=0)
        {
            Destroy(gameObject);
        }
    }
}
