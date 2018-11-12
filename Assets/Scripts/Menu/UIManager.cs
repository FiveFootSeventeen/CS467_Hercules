using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager> {

    [SerializeField]
    private SplashScreen _splashScreen;
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _splashScreen.FadeOut();
        }
    }

}
