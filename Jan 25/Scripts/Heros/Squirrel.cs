using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//我方四号人物：attack hp(low)
public class Squirrel : Character
{
    private Character lowestHpGo;
    public GameObject missCanvas;

    protected override void Attack()
    {
        if (GameManager.instance.enemyClones.Count == 0) return;

        GetLowEnemy();
        lowestHpGo.TakenDamage(attackDamage);

        GameObject go = Instantiate(damageCanvas, lowestHpGo.transform.position, Quaternion.identity);
        go.GetComponentInChildren<Text>().text = attackDamage.ToString();

        Instantiate(enemyHurtEffect, lowestHpGo.transform.position, Quaternion.identity);

        //Debug.Log("SQ Attack");
    }

    private Character GetLowEnemy()
    {
        float lowestHp = Mathf.Infinity;

        if(GameManager.instance.enemyClones.Count != 0)
        {
            for (int i = 0; i < GameManager.instance.enemyClones.Count; i++)
            {
                if (GameManager.instance.enemyClones[i].GetComponent<Character>().hp < lowestHp)
                {
                    lowestHp = GameManager.instance.enemyClones[i].GetComponent<Character>().hp;
                    lowestHpGo = GameManager.instance.enemyClones[i].GetComponent<Character>();
                }
            }
        }

        return lowestHpGo;
    }

}
