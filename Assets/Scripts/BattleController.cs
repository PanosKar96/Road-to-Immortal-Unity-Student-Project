using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class BattleController : MonoBehaviour
{
    //UI Elements
    public Image heroImage;
    public Image enemyImage;
    public AudioSource sfxSource;
    public Button attackButton;
    public Button specialButton;
    public Slider heroHP;
    public Slider enemyHP;

[Header("Hero Sprites")]
public Sprite juggernautSprite;
public Sprite drowSprite;
public Sprite kotlSprite;

[Header("Enemy Sprites")]
public Sprite creepsSprite;
public Sprite primalBeastSprite;
public Sprite roshanSprite;


    private float critChanceAttack = 0.15f;
    private float critChanceSpecial = 0.25f;
    private int critMultiplier = 2;

    private Color normalColor = Color.white;
    private Color hitColor = new Color(1f, 0.3f, 0.3f);
    private bool  specialUsed = false;
    private bool battleEnded = false;
    
     //stats
     public Text heroName;
     private HeroData hero;
     private int heroMaxHP;
     private int heroCurrentHP;
    

    public Text enemyName;
    private EnemyData enemy;
     private int enemyMaxHP;
     private int enemyCurrentHP;
   void Start()
{
    hero = GameManager.Instance.selectedHeroData;

    heroName.text = hero.heroName;
    heroMaxHP = hero.maxHP;


    if (GameManager.Instance.hasSavedHeroHP)
        heroCurrentHP = Mathf.Clamp(GameManager.Instance.savedHeroHP, 0, heroMaxHP);
    else
        heroCurrentHP = heroMaxHP;

    GameManager.Instance.savedHeroHP = heroCurrentHP;
    GameManager.Instance.hasSavedHeroHP = true;

    heroHP.maxValue = heroMaxHP;
    heroHP.value = heroCurrentHP;
    heroImage.sprite = GetHeroSprite(hero.heroName);

   
    enemy = GameManager.Instance.enemies[GameManager.Instance.currentLevel];

    enemyName.text = enemy.enemyName;

    enemyCurrentHP = enemy.maxHP;
    enemyHP.maxValue = enemy.maxHP;
    enemyHP.value = enemyCurrentHP;

    enemyImage.sprite = GetEnemySprite(enemy.enemyName);

    Debug.Log(hero.heroName + " HP: " + heroCurrentHP + "/" + heroMaxHP +
              "  Vs. " + enemy.enemyName + " HP: " + enemyCurrentHP);
}
    //Get hero sprite
    private Sprite GetHeroSprite(string heroName)
{
    if (heroName == "Juggernaut")
        return juggernautSprite;

    if (heroName == "Drow Ranger")
        return drowSprite;

    if (heroName == "Kotl")
        return kotlSprite;

    return null;
}
//Get enemy sprite
private Sprite GetEnemySprite(string enemyName)
{
    if (enemyName == "Dire Creeps")
        return creepsSprite;

    if (enemyName == "Primal Beast")
        return primalBeastSprite;

    if (enemyName == "Roshan")
        return roshanSprite;

    return null;
}

    //Calculate critical hit
        private int ApplyCrit(int baseDamage, float chance, out bool isCrit)
    {
        isCrit = Random.value < chance;
        return isCrit ? baseDamage * critMultiplier : baseDamage;
    }
    //Flash Red on damage
    private IEnumerator DamageFlash(Image img)
    {
        img.color = hitColor;
        yield return new WaitForSeconds(0.1f);
        img.color = normalColor;
    }

    //We  can shake any UI element by passing its RectTransform
    private IEnumerator UIShake(RectTransform target, float duration, float strength)
    {
        Vector2 originalPos = target.anchoredPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * strength;
            float y = Random.Range(-1f, 1f) * strength;

            target.anchoredPosition = originalPos + new Vector2(x, y);
            elapsed += Time.deltaTime;
            yield return null;
        }

        target.anchoredPosition = originalPos;
        
    }
    //Death effect coroutine
    private IEnumerator DeathEffect(Image target)
    {
        RectTransform rt = target.rectTransform;
        Color originalColor = target.color;

        for (int i = 0; i < 10; i++)
        {
            rt.localScale *= 0.9f;
            target.color = new Color(1f, 0.3f, 03f, target.color.a);
            yield return new WaitForSeconds(0.03f);
        }

        target.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }

  //
  private void PlayHeroSfx(AudioClip clip)
    {
        //Play Hero-specific sound effect
        if(sfxSource == null || clip == null) return;
        sfxSource.PlayOneShot(clip);
    }

    private IEnumerator LoseFlow()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("GameOverScene");
    }
    public void OnAttackButton()
    {   
         int baseHeroDamage = Random.Range(hero.minDamage, hero.maxDamage); 
         bool isCrit;
         int heroDamage = ApplyCrit(baseHeroDamage, critChanceAttack, out isCrit);

         int BaseEnemyDamage = Random.Range(10,20);//counter attack.
         bool enemyisCrit;
         int enemyDamage = ApplyCrit(BaseEnemyDamage, critChanceAttack, out enemyisCrit);

         if(isCrit || enemyisCrit)
        {
            Debug.Log("Critical Hit!");
        }

        //play attack sound effect
        PlayHeroSfx(hero.attackSfx);

         //When enemy take damage.
         enemyCurrentHP -= heroDamage;
         if(enemyCurrentHP <= 0)
         {
             enemyCurrentHP = 0;
             enemyHP.value = enemyCurrentHP;
             StartCoroutine(DeathEffect(enemyImage));
         }

        //When hero take damage.
        heroCurrentHP -= enemyDamage;

        if(heroCurrentHP <= 0)
        {
            heroCurrentHP = 0;
            heroHP.value = heroCurrentHP;
            StartCoroutine(DeathEffect(heroImage));
        }
            

        //Visual feedback.
        StartCoroutine(DamageFlash(enemyImage));
        StartCoroutine(DamageFlash(heroImage));
        StartCoroutine(UIShake(enemyImage.rectTransform, 0.2f, 8f));
        StartCoroutine(UIShake(heroImage.rectTransform, 0.2f, 8f));

        //Update health bar.
        enemyHP.value = enemyCurrentHP;
        heroHP.value = heroCurrentHP;

        Debug.Log("Hero dealt:  " + heroDamage +"| Enemy dealt:  " + enemyDamage);


        CheckBattleEnd();
    }

    public void OnSpecialButton()
    {
        if(specialUsed || battleEnded)
            return;

            specialUsed = true;
            specialButton.interactable = false;

            PlayHeroSfx(hero.specialSfx);
            

            int BaseHeroDamage =Random.Range(hero.minSpecialDamage, hero.maxSpecialDamage);// Hero special damage.
            bool isCrit;
            int heroDamage = ApplyCrit(BaseHeroDamage, critChanceSpecial, out isCrit);

            int BaseEnemyDamage = Random.Range(enemy.minDamage, enemy.maxDamage);//counter attack.
            bool enemyisCrit;
            int enemyDamage = ApplyCrit(BaseEnemyDamage, critChanceSpecial, out enemyisCrit);

            if(isCrit || enemyisCrit)
            {
                Debug.Log("Critical Hit!");
            }

            enemyCurrentHP -= heroDamage;
            if (enemyCurrentHP < 0) enemyCurrentHP = 0;

            heroCurrentHP -= enemyDamage;
            if (heroCurrentHP < 0) heroCurrentHP = 0;

            
            Debug.Log("Hero dealt: " + heroDamage + " | Enemy dealt: " + enemyDamage);

            //Update health bar.
            enemyHP.value = enemyCurrentHP;
            heroHP.value = heroCurrentHP;

            //Visual feedback.
            StartCoroutine(DamageFlash(enemyImage));
            StartCoroutine(DamageFlash(heroImage));
            StartCoroutine(UIShake(enemyImage.rectTransform, 0.3f, 12f));
            StartCoroutine(UIShake(heroImage.rectTransform, 0.2f, 8f));

            CheckBattleEnd();
    }

    private IEnumerator LoadAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
    private void CheckBattleEnd()
    {
        if(battleEnded)
        return;
    
        if(enemyCurrentHP <= 0 && !battleEnded)
        {
            battleEnded = true;

            attackButton.interactable = false;
            specialButton.interactable = false;

            int currentLevel = GameManager.Instance.currentLevel;

            if(currentLevel == 0)
            {
                GameManager.Instance.highestUnlockedLevel = 1;

                GameManager.Instance.savedHeroHP = heroCurrentHP;
                GameManager.Instance.hasSavedHeroHP = true;

                StartCoroutine(LoadAfterDelay("VictoryLevel1Scene"));
            }
            else if (currentLevel == 1)
            {
                GameManager.Instance.highestUnlockedLevel = 2;

                GameManager.Instance.savedHeroHP = heroCurrentHP;
                GameManager.Instance.hasSavedHeroHP = true;

                StartCoroutine(LoadAfterDelay("VictoryLevel2Scene"));
            }
            else if (currentLevel == 2)
            {

                GameManager.Instance.savedHeroHP = 0;
                GameManager.Instance.hasSavedHeroHP = false;
                StartCoroutine(LoadAfterDelay("FinalVictoryScene"));
            }

        } 
            else if (heroCurrentHP <= 0)
            {
                battleEnded =true;

                attackButton.interactable = false;
                specialButton.interactable  = false;

                StartCoroutine(LoseFlow());

                Debug.Log("YOU DIED! Dire Victory!");
            }
    }

}