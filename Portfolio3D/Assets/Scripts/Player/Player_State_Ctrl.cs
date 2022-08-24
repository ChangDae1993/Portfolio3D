using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walk,
    Run,
    runGuard,
    Ducking,
    Jump,
    noAim,
    Aim,
    AimShoot,
    Shoot,
    AutoShoot,
    BurstShoot,
    Reload,
    Hit,
    Die
}

public class Player_State_Ctrl : MonoBehaviour
{
    public PlayerState P_State;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        P_State = PlayerState.Idle;
    }
}