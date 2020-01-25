using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//在完成了初步所有角色的进攻逻辑后，在做Shop菜单时做的
[CreateAssetMenu(menuName = "Create Character", fileName = "Character")]
public class HeroData : ScriptableObject
{
    public int playerIndex;
    public GameObject playerReference;

    public string playerName;
    public CharacterType playerType;
    [TextArea]
    public string playerSkill;
    public Sprite playerSprite;

    public int playerLv;
    public float playerHp;
    public float playerSpeed;
    public float playerAtt;
    public int playerPrice;

}
