using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum XWingState
{
    IdleFly,
    Fly,
    Attack,
    Dash,
    Dodge,
    Repair,
    Die,
}

public enum XWingWeaponState
{
    oneShot,
    spotShot,
    drillShot,
}

public enum XWingSkillState
{
    noSkill,
    Skill1, //torphido Q
    Skill2, //repair E
    Skill3, //R skill
    Skill4, //dash L+Shift
}


public class XWing_State_Ctrl : MonoBehaviour
{
    public float P_maxhp = 100;
    public float P_curhp;
    public float P_xp;

    public float damage;

    public int killCount;

    public XWingState X_State;
    public XWingWeaponState XW_State;
    public XWingSkillState XS_State;

    void Start()
    {
        P_curhp = P_maxhp;
        X_State = XWingState.IdleFly;
        XW_State = XWingWeaponState.oneShot;
        XS_State = XWingSkillState.noSkill;
    }

    public void P_Hit(int damage)
    {
        Debug.Log("hit" + damage);
    }
}