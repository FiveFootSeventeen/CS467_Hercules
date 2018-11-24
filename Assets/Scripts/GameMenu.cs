using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMenu : MonoBehaviour {

    public GameObject menu;

    public TextMeshProUGUI nameText, hpText, sanityText, lvlText, xpText;
    public Slider xpSlider;
    public Image playerImg;

    private CharacterStats playerStats;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Cancel"))
        {
            if (menu.activeInHierarchy)
            {
                menu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                PlayerController.instance.canMove = true;
            }
            else
            {
                UpdateMainStats();
                menu.SetActive(true);
                Cursor.visible = true;
                Time.timeScale = 0;
                PlayerController.instance.canMove = false;

            }
        }

	}

    public void UpdateMainStats()
    {
        playerStats = CharacterStats.instance;
        nameText.text = playerStats.characterDefinition.charName;
        hpText.SetText("HP: {0}/{1}", playerStats.GetCurrentHealth(), playerStats.GetMaxHealth());
        sanityText.SetText("Sanity: {0}/{1} ", playerStats.GetCurrentSanity(), playerStats.GetMaxSanity());
        lvlText.SetText("Lvl: {0}", playerStats.GetLevel());
        xpText.SetText("{0}/{1}", playerStats.GetXP(), playerStats.GetRequiredXP());
        xpSlider.maxValue = playerStats.GetRequiredXP();
        xpSlider.value = playerStats.GetXP();
        playerImg.sprite = playerStats.characterDefinition.sprite;
    }
}
