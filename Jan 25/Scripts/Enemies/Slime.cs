using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//攻击模式：攻击第一个人
public class Slime : Character
{
    protected override void Attack()
    {
        if (GameManager.instance.heroClones.Count == 0) return;
        if (GameManager.instance.heroClones[0] != null)
        {
            GameManager.instance.heroClones[0].GetComponent<Character>().TakenDamage(attackDamage);

            //CORE 错误写法
            //Instantiate(damageCanvas, GameManager.instance.heroClones[0].transform.position, Quaternion.identity);
            //damageCanvas.GetComponentInChildren<Text>().text = attackDamage.ToString();

            GameObject go = Instantiate(damageCanvas, GameManager.instance.heroClones[0].transform.position, Quaternion.identity);
            go.GetComponentInChildren<Text>().text = attackDamage.ToString();

            Instantiate(heroHurtEffect, GameManager.instance.heroClones[0].transform.position, Quaternion.identity);
        }
    }

    protected override void Death()
    {
        base.Death();
    }
}
