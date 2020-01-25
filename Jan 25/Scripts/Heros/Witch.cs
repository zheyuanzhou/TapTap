using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//攻击模式：攻击第一个人
public class Witch : Character
{
    protected override void Attack()
    {
        if (GameManager.instance.enemyClones.Count == 0) return;
        if (GameManager.instance.enemyClones[0] != null)
        {
            GameManager.instance.enemyClones[0].GetComponent<Character>().TakenDamage(attackDamage);

            //CORE 错误写法
            //Instantiate(damageCanvas, GameManager.instance.enemyClones[0].transform.position, Quaternion.identity);
            //damageCanvas.GetComponentInChildren<Text>().text = attackDamage.ToString();

            GameObject go = Instantiate(damageCanvas, GameManager.instance.enemyClones[0].transform.position, Quaternion.identity);
            go.GetComponentInChildren<Text>().text = attackDamage.ToString();

            Instantiate(enemyHurtEffect, GameManager.instance.enemyClones[0].transform.position, Quaternion.identity);
        }
    }
}
