using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Skill1, //torphido
    Skill2, //repair
    Skill3, //dash
    Skill4, //hyperDrive
}


public class XWing_State_Ctrl : MonoBehaviour
{
    public float P_maxhp = 100;
    public float P_curhp;
    public float P_xp;
    public int killCount;

    public XWingState X_State;
    public XWingWeaponState XW_State;
    public XWingSkillState XS_State;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        P_curhp = P_maxhp;
        X_State = XWingState.IdleFly;
        XW_State = XWingWeaponState.oneShot;
        XS_State = XWingSkillState.noSkill;
    }
}