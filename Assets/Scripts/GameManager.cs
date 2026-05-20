using Unity.Mathematics;
using  UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentLevel = 0;//The current level the player is on

    public HeroData juggernaut;
    public HeroData drow;
    public HeroData kotl;

    public HeroData selectedHeroData; // The hero selected by the player.
    public EnemyData[] enemies; 
    public EnemyData currentEnemy;

   [Header("Run (HP Persistence)")]
    public int savedHeroHP = 0;
    public bool hasSavedHeroHP = false;


    public int highestUnlockedLevel;
    public int totalLevels = 3; // Levels 0, 1, 2
    public void ResetRun()
{
    currentLevel = 0;
    highestUnlockedLevel = 0;

    hasSavedHeroHP = false;
    savedHeroHP = 0;
}
public void ForceFullHPNextBattle()
{
    // Next battle should start with full HP
    hasSavedHeroHP = false;
    savedHeroHP = 0;
}
    void Awake()
    {

        
        //Singleton Patern: Ensure only one instance of GameManager exists
        if(Instance == null)
        {
            if(juggernaut == null) juggernaut = new HeroData();
            if(drow == null ) drow = new HeroData();
            if(kotl == null) kotl = new HeroData();

            if( enemies == null || enemies.Length != 3)
            {
                enemies = new EnemyData[3];
                for (int i = 0; i < enemies.Length; i++)
                     enemies[i] = new EnemyData();
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);//It does not get destroyed when loading a new scene
        }
        else
        {
            Destroy(gameObject);//Destroy duplicate instance
        }
    }
}
