using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twiPuzzleInteraction : MonoBehaviour {

    ParticleSystem[] ps;
    public int sfxSource;
    GameObject exitPortal;

    private void Awake()
    {
        exitPortal = GameObject.Find("Twilight_Portal_Exit");
        if(exitPortal && GameController.control.twilightPortalStatus != 3)
            exitPortal.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((GameController.control.twilightPortalStatus == 0) && (gameObject.name == "Location1"))
        {            
            //Destroy(this.gameObject);
            GameController.control.twilightPortalStatus = 1;
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);

            GetComponentInChildren<ParticleSystem>().startColor = new Color(0, 255, 0);

            ps = GetComponentsInChildren<ParticleSystem>();
            for(int i = 0; i < ps.Length; i++)
            {
                ps[i].startColor = new Color(0, 255, 0);
            }
            AudioManager.Instance.PlaySFX(sfxSource);
            //AudioManager.Instance.EffectsSource.PlayOneShot(activationEffect);
        }
        else if ((GameController.control.twilightPortalStatus == 1) && (gameObject.name == "Location2"))
        {
            //Destroy(this.gameObject);
            GameController.control.twilightPortalStatus = 2;
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);

            GetComponentInChildren<ParticleSystem>().startColor = new Color(0, 255, 0);

            ps = GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < ps.Length; i++)
            {
                ps[i].startColor = new Color(0, 255, 0);
            }
            AudioManager.Instance.PlaySFX(sfxSource);
            //AudioManager.Instance.EffectsSource.PlayOneShot(activationEffect);
        }
        else if ((GameController.control.twilightPortalStatus == 2) && (gameObject.name == "Location3"))
        {
            //Destroy(this.gameObject);
            GameController.control.twilightPortalStatus = 3;
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);

            GetComponentInChildren<ParticleSystem>().startColor = new Color(0, 255, 0);

            ps = GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < ps.Length; i++)
            {
                ps[i].startColor = new Color(0, 255, 0);
            }
            AudioManager.Instance.PlaySFX(sfxSource);
            //AudioManager.Instance.EffectsSource.PlayOneShot(activationEffect);
            exitPortal.SetActive(true);
        }
    }
}
