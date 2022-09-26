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
    torphido,
}

public enum XWingSkillState
{
    noSkill,
    Skill1,
    Skill2,
    Skill3,
}

public class XWing_State_Ctrl : MonoBehaviour
{

    public XWingState X_State;
    public XWingWeaponState XW_State;
    public XWingSkillState XS_State;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        X_State = XWingState.IdleFly;
        XW_State = XWingWeaponState.oneShot;
        XS_State = XWingSkillState.noSkill;
    }
}