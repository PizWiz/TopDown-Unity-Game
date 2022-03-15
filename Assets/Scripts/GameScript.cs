using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    //CREATE WAY TOO MANY STATIC VARIABLES SO I CAN FINISH THIS GAME QUICKLY!!!
    public static float spawnFrequency;
    public static float enemyDamage;
    public static float enemySpeed ;
    public static float enemyHealth;
    public static float playerHealth;
    public static float playerMaxHealth;
    public static float playerBulletSpread;
    public static float playerBulletSize;
    public static float playerBulletSpeed;
    public static float playerReloadSpeed;
    public static float playerBulletDamage;
    public static float playerSpeed;
    public static float highScore;
    public static float screenShake;
    public static int score;
    void Start()
    {
        //SET STARTING NUMBERS
        spawnFrequency = 200;
        enemyDamage = 3;
        enemySpeed = 50;
        enemyHealth = 1;
        playerHealth = 100;
        playerMaxHealth = 100;
        playerBulletSpread = 0;
        playerBulletSize = 0.25f;
        playerBulletSpeed = 1f;
        playerReloadSpeed = 4;
        playerBulletDamage = 1;
        playerSpeed = 400;
        score = 0;
        screenShake=0;
    }
    void FixedUpdate() 
    {
        //slow screenshake
        if (screenShake>0)
        {
            screenShake-=0.04f;
        }
        else
        {
            screenShake=0;
        }

        //SLOWLY INCREASE DIFFICULTY AND PLAYER POWER OVER TIME
        enemyDamage+=0.001f;
        enemySpeed+=0.02f;
        spawnFrequency-=0.001f;
        playerBulletSpread+=0.001f;
        playerReloadSpeed-=0.0001f;
        playerBulletSpeed+=0.0001f;
        playerSpeed+=0.01f;

        //GAMEOVER
        if (playerHealth<=0)
        {
            //CHECK FOR HIGHSCORE
            if(score>=highScore)
            {
                highScore=score;
            }

            SceneManager.LoadScene(sceneName:"StartmenuScene");
        }
    }
}
