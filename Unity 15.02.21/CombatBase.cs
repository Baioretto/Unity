using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBase : MonoBehaviour
{
    public float fHealth=100;
    public float fDamage=15;
    
    List<CombatBase> enemyList =new List<CombatBase>();
    //var enemyList = new HashSet<CombatBase>(); 
    void TryAttack(CombatBase enemy)
    {
        enemy.TakeDamage(fDamage);
    }
    void TakeDamage(float incDmg)
    {
        fHealth-=incDmg;
    }
    private void OnCollisionEnter(Collision other) {    
        float fOponentDist;    
        float fDistToFirstComparsion=1000.0f;
        CombatBase cbEnemyToAttack;
        enemyList.Add(other.gameObject.GetComponent<CombatBase>());  

        foreach (var oponent in enemyList)
        {
            fOponentDist = Vector3.Distance(oponent.position, transform.position);
            if(fOponentDist<distToFirstComparsion)
            {
                enemyToAttack=oponent;
                distToFirstComparsion=fOponentDist;
            }  
        }  
        if(enemyToAttack)
                TryAttack(enemyToAttack);
    }
    private void OnCollisionExit(Collision other) {
        foreach (var oponent in enemyList)
        {
            enemyList.Remove(other);
        } 
    }
}
