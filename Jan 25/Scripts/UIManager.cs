using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text goldText;
    public int gold;

    public GameObject[] menus;//labelMenu, shopMenu, optionMenu, tutorialMenu
    [SerializeField] private bool[] menuStats;//f,f,f,f TODO private later

    public GameObject selectedButton;

    public Text playTimeText;
    public Text incomeText;
    public Text sumNumText;
    public Text killNumText;

    private Timer timer;
    [HideInInspector] public int totalIncome;
    public int summonNum;
    public int killNum;

    public string playerName;
    public InputField inputField;
    public Text nameText;
    public Text stageText;

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
        timer = FindObjectOfType<Timer>();
        totalIncome = gold;
        UpdateGold();

        DisplayOptionData();
        stageText.text = "STAGE " + GameManager.instance.stage.ToString();
    }

    private void Update()
    {
        DisplayOptionData();
    }

    public void AddGold(int _bonus)
    {
        gold += _bonus;
        UpdateGold();
    }

    public void UpdateGold()
    {
        goldText.text = gold.ToString();
    }

    public void menuButton(int _id)
    {
        if(menuStats[_id] == false)
        {
            GameManager.instance.isPaused = true;

            for (int i = 0; i < menus.Length; i++)
            {
                if (i == _id)
                {
                    menus[i].gameObject.SetActive(true);
                    menuStats[i] = true;
                }
                else
                {
                    menus[i].gameObject.SetActive(false);
                    menuStats[i] = false;
                }
            }
        }
        else
        {
            GameManager.instance.isPaused = false;

            for(int i = 0; i < menus.Length; i++)
            {
                menus[i].gameObject.SetActive(false);
                menuStats[i] = false;
            }
        }
    }

    //MARKER 在Tutorial菜单中点击按钮弹出网站
    public void OpenURL(string _url)
    {
        Application.OpenURL(_url);
    }

    //MARKER 显示Option菜单中总游戏时间
    public void DisplayOptionData()
    {
        #region
        float seconds = Mathf.Floor(timer.timer % 60);
        float mins = Mathf.Floor((timer.timer % 3600) / 60);
        float hours = Mathf.Floor((timer.timer % 216000) / 3600);

        playTimeText.text = hours.ToString("00") + ":" + mins.ToString("00") + ":" + seconds.ToString("00");
        #endregion

        #region 
        incomeText.text = totalIncome.ToString();
        #endregion

        #region
        sumNumText.text = summonNum.ToString();
        #endregion

        #region
        killNumText.text = killNum.ToString();
        #endregion
    }

    //MARKER 在InputField调用
    public void NameChange()
    {
        playerName = inputField.text;//input组件Text属性的String变量【赋值】String类型变量playName
        nameText.text = playerName;//再将String类变量playName显示再Input子物体nameText中的Text属性中，显示出来
    }

    ////MARKER Option菜单负责游戏暂停开关
    //public void SetStepBool(bool _bool)
    //{
    //    isStopped = _bool;
    //}

    public void GiveUpButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToTitleButton()
    {
        //TODO SAVE AND LOAD
        SceneManager.LoadScene(0);
    }


}
