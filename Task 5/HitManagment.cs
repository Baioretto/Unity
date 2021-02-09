using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManagment : MonoBehaviour
{
    float hp=100;
    bool dead=false;
    void GetHit(float damage)
    {
        hp=hp-damage;
        if(hp<0)
        {
            hp=0;
            dead=!dead; // dead=true;
        }            
    }
}
