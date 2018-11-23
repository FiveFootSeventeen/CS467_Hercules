using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentLoader : MonoBehaviour {

    public GameObject UICanvas;
    public GameObject Audio;
    private GameObject player;

    public GameObject[] playerOptions;
    public Vector3 spawnPos = new Vector3(.004f, .004f, -0.04801377f);


    // Use this for initialization
    void Start () {
		if (UIFade.instance == null)
        {
           UIFade.instance = Instantiate(UICanvas).GetComponent<UIFade>();
        }
        
        if (PlayerController.instance == null)
        {
            player = Instantiate(playerOptions[0]);
            PlayerController.instance = player.GetComponent<PlayerController>();
        }
        
        if (AudioManager.Instance == null)
        {
            AudioManager.Instance = Instantiate(Audio).GetComponent<AudioManager>();
        }
       
	}

    public void OnCharacterSelect(int characterChoice)
    {
        if (player != null)
        {
            Destroy(player);
            player = null;
           
        }

        PlayerController.instance = Instantiate(playerOptions[characterChoice]).GetComponent<PlayerController>();
        SceneManager.LoadScene("Game.MainScene");

    }
}
