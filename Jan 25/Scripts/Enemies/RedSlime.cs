using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//NO.2 Enemy Red Slime 攻击模式：攻击随机一个人
public class RedSlime : Character
{
    private int randomNum;

    protected override void Attack()
    {
        if (GameManager.instance.heroClones.Count == 0) return;
        randomNum = Random.Range(0, GameManager.instance.heroClones.Count);

        //if (GameManager.instance.heroClones.Count == 0) return;
        if (GameManager.instance.heroClones[randomNum] != null)
        {
            GameManager.instance.heroClones[randomNum].GetComponent<Character>().TakenDamage(attackDamage);

            GameObject go = Instantiate(damageCanvas, GameManager.instance.heroClones[randomNum].transform.position, Quaternion.identity);
            go.GetComponentInChildren<Text>().text = attackDamage.ToString();

            Instantiate(heroHurtEffect, GameManager.instance.heroClones[randomNum].transform.position, Quaternion.identity);
        }
    }

    protected override void Death()
    {
        base.Death();
    }


}
