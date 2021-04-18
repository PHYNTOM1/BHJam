using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public List<Skill> currSkillSet = new List<Skill>();

    [SerializeField]
    private int maxSkillsAmount = 4;
    [SerializeField]
    private int selectedSkill = 0;

    [SerializeField]
    private float activationTimer = 10f;


    public PlayerShooting plsh;
    public PlayerMovement plmo;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectedSkill = 0;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            selectedSkill = 1;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            selectedSkill = 2;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            selectedSkill = 3;
        }

        if (activationTimer > 0)
        {
            activationTimer -= Time.deltaTime;
        }
        else
        {
            ActivateSelectedSkill();            
        }

        ExecuteActiveSkill();
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
                switch (s.name)
                {
                    case "effect_reload":

                        //refill max ammo
                        plsh.ReloadCurrAmmo();
                        break;
                    case "effect_overheat":

                        //set player effect: burning
                        break;
                    case "effect_dash":

                        //make player dash
                        plmo.Dash();
                        break;
                    case "weapon_slingshot":

                        //set active weapon
                        plsh.SetWeapon(0);
                        break;
                    case "weapon_wand1":

                        //set active weapon
                        plsh.SetWeapon(1);
                        break;
                    case "weapon_wand2":

                        //set active weapon
                        plsh.SetWeapon(2);
                        break;
                    case "weapon_poopoogun":

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
