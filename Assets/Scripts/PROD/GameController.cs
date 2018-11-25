using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

    public static GameController control;
    private CharacterStats playerStats;

    //Game Stats
    [Header("Game Stats")]
    public int gemsCollected;
    public int weaponsCollected;
    public int voidPortalStatus;
    public int plasmaPortalStatus;
    public int twilightPortalStatus;
    public int enemiesKilled;
    public int bossesKilled;
    public bool gameWon;


    void Awake () {

        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
	}
    void Start()
    {
        playerStats = CharacterStats.instance;
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void QuitMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");

        GameData data = new GameData
        {
            playerHealth = playerStats.GetCurrentHealth(),
            playerSanity = playerStats.GetCurrentSanity(),
            playerLvl = playerStats.GetLevel(),
            playerXP = playerStats.GetXP(),
            voidPortalStatus = voidPortalStatus,
            plasmaPortalStatus = plasmaPortalStatus,
            twilightPortalStatus = twilightPortalStatus,
            gemsCollected = gemsCollected,
            gameWon = gameWon
        
    };

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            playerStats.characterDefinition.currentHealth = data.playerHealth;
            playerStats.characterDefinition.currentSanity = data.playerSanity;
            voidPortalStatus = data.voidPortalStatus;
            plasmaPortalStatus = data.plasmaPortalStatus;
            twilightPortalStatus = data.twilightPortalStatus;
            gameWon = data.gameWon;
            gemsCollected = data.gemsCollected;
           
        }
    }
}

[Serializable]
class GameData
{
    public int playerHealth;
    public int playerSanity;
    public int playerXP;
    public int playerXPRequired;
    public int playerLvl;   
    public int gemsCollected;
    public int weaponsCollected;
    public int enemiesKilled;
    public int bossesKilled;
    public int voidPortalStatus;
    public int twilightPortalStatus;
    public int plasmaPortalStatus;
    public bool gameWon;
}