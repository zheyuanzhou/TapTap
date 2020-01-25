using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//NO.1 Purple Worm Wizard 攻击模式：攻击全体敌人，AOE 随机攻击力
public class Wizard : Character
{
    protected override void Attack()
    {
        if (GameManager.instance.enemyClones.Count == 0) return;

        for(int i = 0; i < GameManager.instance.enemyClones.Count; i++)
        {
            float _damage = attackDamage + Random.Range(-attackDamage, attackDamage);
            Debug.Log("Random Damage " + _damage);
            GameManager.instance.enemyClones[i].GetComponent<Character>().TakenDamage(_damage);

            GameObject go = Instantiate(damageCanvas, GameManager.instance.enemyClones[i].transform.position, Quaternion.identity);
            go.GetComponentInChildren<Text>().text = _damage.ToString("F0");

            Instantiate(enemyHurtEffect, GameManager.instance.enemyClones[i].transform.position, Quaternion.identity);
        }
    }

}
