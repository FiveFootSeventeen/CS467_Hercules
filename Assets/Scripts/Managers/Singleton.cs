using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    //create templated base class to be extended, class is public and available anywhere in the project. Extends monobehavior 
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    public static bool IsInitialized
    {
        get { return instance != null; }
    }

    protected virtual void Awake() //Can be accessed and overridden by classes that extend Singleton
    {
        if (instance != null)
        {
            Debug.LogError("[Singleton] Singleton trying to be instantiated more than once.");
        }
        else
        {
            instance = (T)this; //cast to object type T
        }
    }
    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

}
