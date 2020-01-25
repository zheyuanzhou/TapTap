using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create Stage", fileName ="Stage")]
public class StageData : ScriptableObject
{
    public int stageLv;
    public List<Character> enemies = new List<Character>();
}
