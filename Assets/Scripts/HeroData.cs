using UnityEngine;



[System.Serializable]
public class HeroData
{
    public string heroName;
    public int maxHP;
    public int minDamage;
    public int maxDamage;
    public int maxSpecialDamage;
    public int minSpecialDamage;

    public AudioClip attackSfx;
    public AudioClip specialSfx;
}
