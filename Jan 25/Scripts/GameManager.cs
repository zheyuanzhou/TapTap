using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //MARKER Have to LOCATE on Enemy Position 所以类型选择GameObject而不是Character
    //public List<Character> heros = new List<Character>();
    //public List<Character> enemies = new List<Character>();

    //MARKER Save Prefab 存放预制体，用来生成克隆体的本体
    public List<GameObject> heros = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();

    //MARKER Save clone we Instantiate 存放生成的克隆体
    public List<GameObject> heroClones = new List<GameObject>();
    public List<GameObject> enemyClones = new List<GameObject>();

    public Transform[] enemyOddTrans;
    public Transform[] enemyEvenTrans;
    public Transform[] heroTrans;
    public GameObject addHeroButton;

    public bool isPaused;

    public int stage = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if(isPaused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    private void Init()
    {
        for(int i = 0; i < heros.Count; i++) 
        {
            //Instantiate(heros[i], heroTrans[i].position, Quaternion.identity);
            heroClones.Add(Instantiate(heros[i], heroTrans[i].position, Quaternion.identity));
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            if(enemies.Count % 2 == 0)//Enemy Count is Even Number
            {
                //Instantiate(enemies[i], enemyEvenTrans[i].position, Quaternion.identity);//CORE create one clone on scene. We need to change this clone later, have to use List to store
                enemyClones.Add(Instantiate(enemies[i], enemyEvenTrans[i].position, Quaternion.identity));
            }
            else
            {
                //Instantiate(enemies[i], enemyOddTrans[i].position, Quaternion.identity);//CORE create one clone on scene
                enemyClones.Add(Instantiate(enemies[i], enemyOddTrans[i].position, Quaternion.identity));
            }
        }

        SetAddButtonPos();
    }

    public void SetAddButtonPos()
    {
        //int index = heros.Count;
        int index = heroClones.Count;

        if(index < 18)
        {
            addHeroButton.gameObject.SetActive(true);

            addHeroButton.gameObject.transform.SetParent(heroTrans[index]);
            addHeroButton.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
        }
        else
        {
            addHeroButton.gameObject.SetActive(false);
        }
    }

    public void UpdateHeroPos()
    {
        if (heroClones.Count == 0) return;

        for(int i = 0; i < heroClones.Count; i++)
        {
            heroClones[i].transform.position = heroTrans[i].position;
        }
    }

    //TODO Call later Buy button onn Shop Menu
    public void PurchaseButton(GameObject _heroGo)
    {
        GameObject go = Instantiate(_heroGo);
        heros.Add(go);
        go.transform.position = heroTrans[heros.Count - 1].position; 

        SetAddButtonPos();
    }

    //MARKER If player die, Reset all players' positions
    public void ResetHeroPos()
    {
        if (heroClones.Count == 0) return;

        for (int i = 0; i < heroClones.Count; i++)
        {
            heroClones[i].transform.position = heroTrans[i].position;
            //SetAddButtonPos();
        }
    }

    public void NextStage()
    {

    }

    public void LastStage()
    {

    }


}
