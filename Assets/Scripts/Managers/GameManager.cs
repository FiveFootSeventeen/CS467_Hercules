using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using System;

public class GameManager : Manager<GameManager>
{

    public static GameManager instance;

    public CharacterStats player;
    

    public class GameStats
    {
        public int gemsCollected = 0;
        public int keysCollected = 0;
        public int weaponsCollected = 0;
        public int enemiesKilled = 0;
        public int bossesKilled = 0;
        public bool voidPortalActive = true;
        public bool twilightPortalActive = true;
        public bool plasmaPortalActive = true;
    }


    void Start()
    {
        if (instance == null)
        {
            
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);

        GameStats gameStats = new GameStats();
        
    }

    public void Save()
    {
       
    }

    public void Load()
    {

    }
    
}
 