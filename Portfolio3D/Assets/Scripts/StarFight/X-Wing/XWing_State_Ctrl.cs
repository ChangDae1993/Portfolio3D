using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum XWingState
{
    IdleFly,
    Fly,
    AttackFly,
    Attack,
    Dash,
    Dodge,
    Repair,
    Skill1,
    Skill2,
    Die,
}

public enum XWingWeaponState
{
    oneShot,
    drillShot,
    torphido,
}

public class XWing_State_Ctrl : MonoBehaviour
{

    public XWingState X_State;
    public XWingWeaponState XW_State;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        X_State = XWingState.IdleFly;
        XW_State = XWingWeaponState.oneShot;
    }
}