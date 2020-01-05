using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Character> characters = new List<Character>();
    public List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    public void EnemyAttack(float _enemyAttack)
    {
        foreach(Character character in characters)
        {
            if(character != null)
            {
                character.Hurt(_enemyAttack);
            }
            else
            {
                return;
            }

        }
    }

    public void CharacterAttack(float _characterAttack)
    {
        foreach(Enemy enemy in enemies)
        {
            if(enemy != null)
            {
                enemy.Hurt(_characterAttack);
            }
            else
            {
                return;
            }
        }
    }

}
