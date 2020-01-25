using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public Text nameText;
    public Text typeText;
    public Text skillText;

    public Image displayImage;

    public Text hpText;
    public Text speedText;
    public Text attackText;
    public Text priceText;

    public HeroData defaultData;

    private void Start()
    {
        DisplayDetail(defaultData);
    }

    //MARKER This function will be called on each Monster buttonn OnClick() Section
    public void DisplayDetail(HeroData _data)
    {
        nameText.text = _data.playerName;
        typeText.text = "[" + _data.playerType + "]";
        skillText.text = _data.playerSkill;

        displayImage.sprite = _data.playerSprite;

        hpText.text = _data.playerHp.ToString();
        speedText.text = _data.playerSpeed.ToString();
        attackText.text = _data.playerAtt.ToString();
        priceText.text = "" + _data.playerPrice;
    }

    //MARKER Call on Purchase button on Shop MENU
    public void PurchaseButton()
    {
        if (UIManager.instance.gold < UIManager.instance.selectedButton.GetComponent<CharacterButton>().data.playerPrice || GameManager.instance.heroClones.Count == 18)
        {
            Debug.Log("NOT ENOUGH MONEY");
        }
        else
        {
            UIManager.instance.gold -= UIManager.instance.selectedButton.GetComponent<CharacterButton>().data.playerPrice;
            UIManager.instance.UpdateGold();

            Debug.Log("INSTANTIATE " + UIManager.instance.selectedButton.GetComponent<CharacterButton>().data.playerName);
            GameManager.instance.heros.Add(UIManager.instance.selectedButton.GetComponent<CharacterButton>().data.playerReference);
            GameManager.instance.heroClones.Add(Instantiate(GameManager.instance.heros[GameManager.instance.heros.Count - 1], GameManager.instance.heroTrans[GameManager.instance.heroClones.Count].position, Quaternion.identity));
            //MARKER 上面：当我们只有一个Hero时，添加新的角色，生成位置应该位于HeorsTrans也是1的位置，heroTrans位置从0开始，即：第二个角色出现在第二个位置，数组的第二位，序列号为1

            GameManager.instance.SetAddButtonPos();

            UIManager.instance.summonNum++;//MARKER 用于Option菜单记录【总召唤数】
        }
    }

}
