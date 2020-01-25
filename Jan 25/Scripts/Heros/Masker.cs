using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//我方第六人：AOE，Earch元素三倍伤害
public class Masker : Character
{
    private bool isEarth;

    protected override void Attack()
    {
        if (GameManager.instance.enemyClones.Count == 0) return;

        for(int i = 0; i < GameManager.instance.enemyClones.Count; i++)
        {
            float _damage;

            if(GameManager.instance.enemyClones[i].GetComponent<Character>().characterType == CharacterType.Earth)
            {
                _damage = attackDamage * 10f;
            }
            else
            {
                _damage = attackDamage;
            }

            //Debug.Log(_damage);
            GameManager.instance.enemyClones[i].GetComponent<Character>().TakenDamage(_damage);

            GameObject go = Instantiate(damageCanvas, GameManager.instance.enemyClones[i].transform.position, Quaternion.identity);
            go.GetComponentInChildren<Text>().text = _damage.ToString("F0");

            Instantiate(enemyHurtEffect, GameManager.instance.enemyClones[i].transform.position, Quaternion.identity);
        }
    }

}
