using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : Singleton<GameManager> {

    private static GameManager instance;
    private string _currentSceneName = string.Empty;
    List<AsyncOperation> _loadOps;


    public GameObject[] SystemPrefabs; //array of Prefabs meant to be created
    List<GameObject> _InstancedSystemPrefabs; //Created Prefabs that GameManager keeps track of

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _InstancedSystemPrefabs = new List<GameObject>();
        _loadOps = new List<AsyncOperation>();

        InstantiateSystemPrefabs();
        LoadScene("CharacterSelect");
    }    

    void OnLoadComplete(AsyncOperation async)
    {
        if (_loadOps.Contains(async)) //check that async op was loaded correctly
        {
            _loadOps.Remove(async); //remove from list
        }
        Debug.Log("Load complete.");
    }

    void OnUnloadComplete(AsyncOperation async)
    {
        Debug.Log("Unload complete.");
    }

    public void LoadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive); //Load scene in addition to already loaded scene
        if (async == null)
        {
            Debug.LogError("[GameManager] Unable to load " + sceneName);
            return;
        }
        async.completed += OnLoadComplete;
        _loadOps.Add(async);
        _currentSceneName = sceneName;

    }

    public void UnloadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.UnloadSceneAsync(sceneName);
        if (async == null)
        {
            Debug.LogError("[GameManager] Unable to unload " + sceneName);
            return;
        }
        async.completed += OnUnloadComplete;
        
    }

    void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;

        for (int i = 0; i < SystemPrefabs.Length; ++i) //iterate through array of prefabs
        {
            prefabInstance = Instantiate(SystemPrefabs[i]); //instantiate the prefab
            _InstancedSystemPrefabs.Add(prefabInstance); //add to list so GameManager has responsibility over them
        }
    }

    //Override the OnDestroy method from base class
    protected override void OnDestroy()
    {
        base.OnDestroy(); //still need to call base Destroy

        for (int i = 0; i < _InstancedSystemPrefabs.Count; ++i)
        {
            //destroy each of our instanced prefabs 
            Destroy(_InstancedSystemPrefabs[i]);
        }
        _InstancedSystemPrefabs.Clear();         

    }




}
