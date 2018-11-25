using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public CharacterStats_SO characterDefinition_Template;
    public CharacterStats_SO characterDefinition;
    public Inventory charInv;
    public GameObject characterWeaponSlot;

    public static CharacterStats instance;
  
    #region Constructors
    public CharacterStats()
    {
        charInv = Inventory.instance;
    }
    #endregion

    #region Initializations
    private void Awake()
    {
        if (characterDefinition_Template != null)
            characterDefinition = Instantiate(characterDefinition_Template);  
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
        if (characterDefinition.isPlayer)
        {
            characterDefinition.SetCharacterLevel(0);
        }
    }
    #endregion

    #region Stat Increasers
    public void ApplyHealth(int hpAmt)
    {
        characterDefinition.ApplyHP(hpAmt);
    }

    public void ApplySanity(int sanityAmt)
    {
        characterDefinition.ApplySanity(sanityAmt);
    }

    public void GiveWealth(int gemAmt)
    {
        characterDefinition.ApplyGems(gemAmt);
    }

    public void IncreaseXP(int xp)
    {
        characterDefinition.GiveXP(xp);
    }

    #endregion

    #region Stat Reducers
    public void TakeDamage(int amount)
    {
        characterDefinition.TakeDamage(amount);
    }

    public void ReduceSanity(int amount)
    {
        characterDefinition.ReduceSanity(amount);
    }
    #endregion

    #region Weapon Change
    public void ChangeWeapon(LootItem weaponPickUp)
    {
        if (!characterDefinition.UnEquipWeapon(weaponPickUp, charInv, characterWeaponSlot))
        {
            characterDefinition.EquipWeapon(weaponPickUp, charInv, characterWeaponSlot);
        }
    }

    #endregion

    #region Reporters
    public int GetCurrentHealth()
    {
        return characterDefinition.currentHealth;
    }

    public int GetCurrentSanity()
    {
        return characterDefinition.currentSanity;
    }
    public int GetMaxHealth()
    {
        return characterDefinition.maxHealth;
    }

    public int GetMaxSanity()
    {
        return characterDefinition.maxSanity;
    }

    public int GetXP()
    {
        return characterDefinition.charExperience;
    }

    public int GetLevel()
    {
        return characterDefinition.charLevel;
    }
    public int GetRequiredXP()
    {
        return characterDefinition.charLevels[GetLevel()].requiredXP;
    }
    public Weapon GetCurrentWeapon()
    {
        if (characterDefinition.weapon != null)
        {
            return characterDefinition.weapon.itemDefinition.weaponSlotObject;
        }
        else
        {
            return null;
        }
    }

    public int GetDamage()
    {
        return characterDefinition.currentDamage;
    }


    #endregion

    #region Initializers

    public void SetInitialHP(int hp)
    {
        characterDefinition.maxHealth = hp;
        characterDefinition.currentHealth = hp;
    }

    public void SetInitialSanity(int sanity)
    {
        characterDefinition.maxSanity = sanity;
        characterDefinition.currentSanity = sanity;
    }

    public void SetInitialDamage(int damage)
    {
        characterDefinition.baseDamage = damage;
        characterDefinition.currentDamage = damage;
    }


    #endregion
}