using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    public Text priceText;
    public HeroData data;

    private void Start()
    {
        priceText.text = data.playerPrice.ToString();
    }

    public void Click()
    {
        UIManager.instance.selectedButton = gameObject;
    }
}
