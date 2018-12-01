﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour {

    public Weapon currentWeapon;
    public bool isAttacking = false;
    public GameObject player;
    private List<string> unattackable = new List<string>();
    private Attack attackCreated;
    private GameObject weaponPrefab;

    private GameObject _instance;
    public GameObject damageAnim;
    public float delay = 0f;

    void Start () {
       
        currentWeapon.weaponPreb.transform.position = new Vector3(0, 0, 0);
        currentWeapon.weaponPreb.transform.rotation = Quaternion.identity;
        weaponPrefab = Instantiate(currentWeapon.weaponPreb, gameObject.transform, false);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(!isAttacking && unattackable.Count > 0)  //After the attack is over clear out the list
        {
            unattackable.Clear();
        }
       
    }

    //Triggered by the child weapon prefab instantiated in Start()
    public void PullTrigger(Collider2D collision)
    {
        GameObject colObject = collision.gameObject;
        CharacterStats_SO stats;

        if (colObject.tag == "Player" || colObject.tag == "Enemy" && isAttacking && Attackable(colObject.name))
        {
            AddEnemy(colObject.name);   //Add the enemies name to the list of enemies already attacked

            _instance = Instantiate(damageAnim, colObject.transform.position, Quaternion.identity);        //Instantiate and destroy the take damage animation
            Destroy(_instance, _instance.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);

            attackCreated = currentWeapon.ExecuteAttack(player);        //Create a new attack for this collision with the current player

            print(gameObject.name + " did " + attackCreated.Damage + " damage to " + colObject.name);

            stats = colObject.GetComponent<EnemyStats>().characterDefinition;
            stats.TakeDamage(attackCreated.Damage);
        }
    }

    //Check if the enemy name is in the list of enemies that have already been dealt damage to
    //Return false if it is
    bool Attackable(string enemyName)
    {
        foreach(string name in unattackable)
        {
            if (enemyName == name)
                return false;
        }
        return true;
    }

    //Add the enemy name to the list of enemies that cannot be attacked at this time
    void AddEnemy(string enemyName)
    {
        foreach (string name in unattackable)
        {
            if (enemyName == name)
                return;
        }
        unattackable.Add(enemyName);
    }

    public void EquipWeapon(int weaponID)
    {
        Debug.Log("Equipped weapon");
        Weapon newWeapon = GameController.control.refWeapons[weaponID];
        weaponPrefab = Instantiate(newWeapon.weaponPreb, gameObject.transform, false);
        currentWeapon.weaponPreb.transform.position = new Vector3(0, 0, 0);
        currentWeapon.weaponPreb.transform.rotation = Quaternion.identity;
    }

    public void UnequipWeapon()
    {
        Destroy(weaponPrefab);
    }
}

