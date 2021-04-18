using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public List<Skill> allSkills = new List<Skill>();
}


public class Skill : MonoBehaviour
{
    public string name;
    public bool unlocked;
    public bool active;

    public Skill(string _name, bool _unlocked)
    {
        name = _name;
        unlocked = _unlocked;
        active = false;
    }
}    
