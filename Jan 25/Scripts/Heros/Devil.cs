using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//我方第五个角色：优先攻击速度最快的敌人
public class Devil : Character
{
    private Character fastestGo;

    protected override void Attack()
    {
        if (GameManager.instance.enemyClones.Count == 0) return;

        GetFastEnemy();
        fastestGo.TakenDamage(attackDamage);

        GameObject go = Instantiate(damageCanvas, fastestGo.transform.position, Quaternion.identity);
        go.GetComponentInChildren<Text>().text = attackDamage.ToString();

        Instantiate(enemyHurtEffect, fastestGo.transform.position, Quaternion.identity);
        Debug.Log("Devil Attack");
    }

    private Character GetFastEnemy()
    {
        float fastestSpeed = Mathf.Infinity;

        if (GameManager.instance.enemyClones.Count != 0)
        {
            foreach(GameObject enemy in GameManager.instance.enemyClones)
            {
                if(enemy.GetComponent<Character>().speedTimer < fastestSpeed)
                {
                    fastestSpeed = enemy.GetComponent<Character>().speedTimer;
                    fastestGo = enemy.GetComponent<Character>();
                }
            }
        }

        return fastestGo;
    }

}
