using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

    public static GameController control;

    //Player Stats
    [Header("Player Stats")]
    public int gemsCollected;
    public int keysCollected;
    public int weaponsCollected;
    public int enemiesKilled;
    public int bossesKilled;
    
    //Game Stats
    [Header("Game Stats")]
    public int voidPortalStatus;
    public int twilightPortalStatus;
    public int plasmaPortalStatus;

    //Enemy Stats
    [Header("Enemy Stats")]
    public float goblinHealth;
    public float bossHealth;
    public float voidMonsterHealth;
    public float plasmaMonsterHealth;
    public float twilightMonsterHealth;
    public float goblinCount;
    public float voidCount;
    public float plasmaCount;
    public float twilightCount;
    
    

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


    /*
    void OnGUI()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.StartsWith("Game."))
        {
            GUI.Label(new Rect(10, 50, 100, 30), "Gems: " + gemsCollected + "/6");
            GUI.Label(new Rect(10, 70, 100, 30), "Keys: " + keysCollected + "/1");
        }
    }
    */
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");

        GameData data = new GameData
        {
            
            voidPortalStatus = voidPortalStatus,
            plasmaPortalStatus = plasmaPortalStatus,
            twilightPortalStatus = twilightPortalStatus,
            
            voidMonsterHealth = voidMonsterHealth,
            plasmaMonsterHealth = plasmaMonsterHealth,
            twilightMonsterHealth = twilightMonsterHealth,
            
            gemsCollected = gemsCollected,
            keysCollected = keysCollected
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

                       
            voidPortalStatus = data.voidPortalStatus;
            plasmaPortalStatus = data.plasmaPortalStatus;
            twilightPortalStatus = data.twilightPortalStatus;
            
            
            voidMonsterHealth = data.voidMonsterHealth;
            plasmaMonsterHealth = data.plasmaMonsterHealth;
            twilightMonsterHealth = data.twilightMonsterHealth;
            ;
            
            //musicVol = data.musicVol;  TODO
            //soundFXVol = data.soundFXVol; TODO
            gemsCollected = data.gemsCollected;
            keysCollected = data.keysCollected;
        }
    }
}

[Serializable]
class GameData
{
    public int gemsCollected;
    public int keysCollected;
    public int weaponsCollected;
    public int enemiesKilled;
    public int bossesKilled;
    public int voidPortalStatus;
    public int twilightPortalStatus;
    public int plasmaPortalStatus;
    public float voidMonsterHealth;
    public float plasmaMonsterHealth;
    public float twilightMonsterHealth;
}