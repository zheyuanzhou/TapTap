using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//我放三号人物，随机进攻，吸血50%AttackDamage
public class Bat : Character
{
    private int randomNum;
    public GameObject HealthCanvas;

    protected override void Attack()
    {
        if (GameManager.instance.enemyClones.Count == 0) return;
        randomNum = Random.Range(0, GameManager.instance.enemyClones.Count);

        if(GameManager.instance.enemyClones[randomNum] != null)
        {
            GameManager.instance.enemyClones[randomNum].GetComponent<Character>().TakenDamage(attackDamage);

            GameObject go = Instantiate(damageCanvas, GameManager.instance.enemyClones[randomNum].transform.position, Quaternion.identity);
            go.GetComponentInChildren<Text>().text = attackDamage.ToString();

            Instantiate(enemyHurtEffect, GameManager.instance.enemyClones[randomNum].transform.position, Quaternion.identity);

            Vampire(0.5f);
        }
    }

    private void Vampire(float _amount)
    {
        float healthAmount = attackDamage * _amount;
        hp += healthAmount;
        if(hp >= maxHp)
        {
            hp = maxHp;
        }

        GameObject go = Instantiate(HealthCanvas, transform.position, Quaternion.identity);
        go.GetComponentInChildren<Text>().text = healthAmount.ToString();

        HealthBar();
        //TODO HEALTH DAMAGE
    }

}
