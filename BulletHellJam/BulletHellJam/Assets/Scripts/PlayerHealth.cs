using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    public int currHealth;

    public float iframeCounter;
    public float realIframeCounter;

    public bool isHurt = false;
    public bool hurtMode = false;
    public bool isDead = false;

    public GameObject hpGreen1;
    public GameObject hpGreen2;
    public GameObject hpGreen3;

    public GameObject hpGray1;
    public GameObject hpGray2;
    public GameObject hpGray3;

    public GameObject hpRed;

    //private SoundManagement sm;

    private float deathTimer = 1.25f;

    void Start()
    {
       // sm = SoundManagement.Instance;
       //sm.gameObject.GetComponent<PauseMenuControl>().loadingAwake = false;

        currHealth = maxHealth;

        hpGreen1.SetActive(true);
        hpGreen2.SetActive(true);
        hpGreen3.SetActive(true);

        hpGray1.SetActive(false);
        hpGray2.SetActive(false);
        hpGray3.SetActive(false);

        hpRed.SetActive(false);
    }

    void Update()
    {
        if (realIframeCounter > 0)
        {
            realIframeCounter -= Time.deltaTime;
        }
    }

    public void GetDamaged(int d)
    {
        if (realIframeCounter > 0)
        {
            return;
        }
        else
        {
            realIframeCounter = iframeCounter;
        }

        //sm.PlayOneShot("playerhit");
        //sm.PlayOneShot("playerhit2");

        hurtMode = true;
        isHurt = true;

        currHealth -= d;

        switch (currHealth / 3)
        {
            case 0:

                hpRed.SetActive(false);
                hpGray3.SetActive(true);
                break;
            case 1:
                hpRed.SetActive(true);
                hpGreen3.SetActive(false);
                hpGreen2.SetActive(false);
                hpGray2.SetActive(true);
                break;
            case 2:
                hpGray1.SetActive(true);
                hpGreen1.SetActive(false);
                break;
            default:
                break;
        }

        if (currHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        //sm.Play("powerdown", 0.25f);
        //Debug.Log("PLAYER DIED!");
        GetComponent<PlayerMovement>().enabled = false;
    }

    public void DieForReal()
    {
        //reload Scene in Scenemanager
    }

    private void OnDestroy()
    {
        //SoundManagement.Instance.GetComponent<PauseMenuControl>().anim.SetTrigger("isOut");
    }
}

