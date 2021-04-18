using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    public List<Skill> allSkills = new List<Skill>();

    public List<Skill> currSkillSet = new List<Skill>();

    [SerializeField]
    private int maxSkillsAmount = 4;
    [SerializeField]
    private int selectedSkill = 0;

    [SerializeField]
    private float activationTimer = 10f;

    public PlayerShooting plsh;
    public PlayerMovement plmo;

    public Image skill1;
    public Image skill2;
    public Image skill3;
    public Image skill4;
    public Image skillSelection;
    public Image timer;

    void Update()
    {
        ProcessInputs();

        if (activationTimer > 0)
        {
            activationTimer -= Time.deltaTime;
        }
        else
        {
            ActivateSelectedSkill();            
        }

        timer.fillAmount = activationTimer / 10f;

        ExecuteActiveSkill();
    }

    private void ProcessInputs()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectedSkill = 0;
            skillSelection.transform.position = skill1.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            selectedSkill = 1;
            skillSelection.transform.position = skill2.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            selectedSkill = 2;
            skillSelection.transform.position = skill3.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            selectedSkill = 3;
            skillSelection.transform.position = skill4.transform.position;
        }
    }

    public void ChangeSkill(Skill _new, int _s)
    {
        if (_s < maxSkillsAmount)
        {
            currSkillSet[_s] = _new;
        }
    }

    private void ActivateSelectedSkill()
    {
        foreach (Skill s in currSkillSet)
        {
            s.active = false;
        }

        currSkillSet[selectedSkill].active = true;
        activationTimer = 10f;
    }

    private void ExecuteActiveSkill()
    {
        foreach (Skill s in currSkillSet)
        {
            if (s.active)
            {
                switch (s.description)
                {
                    case "a_reload":

                        //refill max ammo
                        plsh.ReloadCurrAmmo();
                        break;
                    case "a_overheat":

                        //set player effect: burning
                        break;
                    case "a_dash":

                        //make player dash
                        plmo.Dash();
                        break;
                    case "w_slingshot":

                        //set active weapon
                        plsh.SetWeapon(0);
                        break;
                    case "w_wand1":

                        //set active weapon
                        plsh.SetWeapon(1);
                        break;
                    case "w_wand2":

                        //set active weapon
                        plsh.SetWeapon(2);
                        break;
                    case "w_pistol":

                        //set active weapon
                        plsh.SetWeapon(3);
                        break;
                    default:

                        Debug.LogWarning("ERROR AT EXECUTING ACTIVE SKILL IN PLAYERSKILLS!");
                        break;
                }

                s.active = false;
                return;
            }
        }
    }    
}
