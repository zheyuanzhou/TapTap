using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Image hpImage;
    public Image speedImage;

    [SerializeField] private float maxHp;
    [HideInInspector] public float hp;
    [SerializeField] private float speed;
    [HideInInspector] public float speedTimer;

    public float attack;
    public GameObject damageCanvas;

    private void Start()
    {
        hp = maxHp;
        speedTimer = speed;
    }

    private void Update()
    {
        SpeedRate();
        HealthBar();
    }

    public void Hurt(float _enemyAmount)
    {
        damageCanvas.GetComponentInChildren<Text>().text = _enemyAmount.ToString();
        Instantiate(damageCanvas, transform.position, Quaternion.identity);
        hp -= _enemyAmount;
      

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void HealthBar()
    {
        hpImage.fillAmount = hp / maxHp;
    }

    private void SpeedRate()
    {
        speedTimer -= Time.deltaTime;
        if (speedTimer <= 0)
        {
            GameManager.instance.CharacterAttack(attack);
            speedTimer = speed;
        }

        speedImage.fillAmount = speedTimer / speed;
    }

}
