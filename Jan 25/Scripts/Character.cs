using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum CharacterType
{
    Normal,
    Fire,
    Water,
    Earth,
    Wind
}

public class Character : MonoBehaviour
{
    [SerializeField] private bool isEnemy;

    public CharacterType characterType;

    [SerializeField] private Image hpImage;
    [SerializeField] private Image speedImage;

    public float maxHp;
    public float hp;
    [SerializeField] private float speedRate;
    [HideInInspector] public float speedTimer;

    [SerializeField] protected float attackDamage;

    public GameObject damageCanvas;//Attack Popup Damage Text Effect
    [SerializeField] protected int bonus;
    private int priceBonnus;

    private bool isDead;
    public Image bonusImage;
    public GameObject priceGo;

    public GameObject heroHurtEffect, enemyHurtEffect;

    private int count;

    private void Start()
    {
        hp = maxHp;
        hpImage.fillAmount = hp / maxHp;

        speedTimer = speedRate;
        bonusImage.gameObject.SetActive(false);
        priceGo.gameObject.SetActive(false);

        priceBonnus = bonus / 3;
    }

    private void Update()
    {
        if(hp <= 0 && isDead == false)
        {
            Death();
        }

        if (!isDead)
        {
            UpdateSpeed();
        }
        else
        {
            if (isEnemy)
            {
                bonusImage.fillAmount -= 0.0075f;
                if (bonusImage.fillAmount <= 0 && count < 3)
                {
                    bonusImage.fillAmount = 1;
                    count += 1;
                    UIManager.instance.AddGold(priceBonnus);
                    bonus -= priceBonnus;
                    priceGo.GetComponentInChildren<Text>().text = bonus.ToString();

                    UIManager.instance.totalIncome += priceBonnus;
                }

                if (count == 3)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                GameManager.instance.heroClones.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }

    public void HealthBar()
    {
        //Debug.Log("Health Bar function called");
        hpImage.fillAmount = hp / maxHp;
    }

    private void UpdateSpeed()
    {
        speedTimer -= Time.deltaTime;
        if(speedTimer <= 0)
        {
            Attack();
            speedTimer = speedRate;
        }
        speedImage.fillAmount = speedTimer / speedRate;
    }

    public virtual void TakenDamage(float _damage)
    {
        hp -= _damage;//TODO Damage Effect
        HealthBar();

        //Instantiate(damageCanvas, transform.position, Quaternion.identity);
        //damageCanvas.GetComponentInChildren<Text>().text = _damage.ToString();
    }

    protected virtual void Attack()
    {

    }

    protected virtual void Death()
    {
        if(isEnemy)
        {
            isDead = true;
            GameManager.instance.enemyClones.Remove(gameObject);

            bonusImage.gameObject.SetActive(true);
            priceGo.gameObject.SetActive(true);
            priceGo.GetComponentInChildren<Text>().text = bonus.ToString();

            UIManager.instance.killNum++;//MARKER 用于Option菜单记录【目标击败数】
        }
        else
        {
            isDead = true;
            GameManager.instance.heroClones.Remove(gameObject);

            //GameManager.instance.UpdateHeroPos();
            GameManager.instance.ResetHeroPos();

            GameManager.instance.SetAddButtonPos();//MARKER 重制购买按钮
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Detail");
    }

}
