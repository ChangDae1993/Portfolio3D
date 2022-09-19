using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMoveState
{
    Idle,
    Walk,
    Run,
    runGuard,
    Ducking,
    Jump
}

public enum PlayerAttackState
{
    noShoot,
    noAim,
    Shoot,
    WalkShoot,
    Aim,
    AimWalkShoot,
    AimShoot,
    AutoShoot,
    BurstShoot,
    Reload,
}

public enum WeaponState
{
    singleShot = 0,
    tripleShot = 1,
    fullautoShot = 2 ,
}

public enum PlayerHitState
{
    noHit,
    Hit,
    Die
}

public class Player_State_Ctrl : MonoBehaviour
{
    public PlayerMoveState P_State;
    public PlayerAttackState P_AttaState;
    public PlayerHitState P_HitState;
    public WeaponState P_WeaponState;
    private void Start() => StartFunc();

    private void StartFunc()
    {
        P_State = PlayerMoveState.Idle;
        P_AttaState = PlayerAttackState.noShoot;
        P_HitState = PlayerHitState.noHit;
        P_WeaponState = WeaponState.singleShot;
    }
}