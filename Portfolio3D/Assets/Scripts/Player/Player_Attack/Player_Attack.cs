using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    Player_State_Ctrl Pl_State;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        Pl_State = GetComponent<Player_State_Ctrl>();
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        if(Pl_State.P_AttaState == PlayerAttackState.Shoot)
        {
            PlayerShootFunc();
        }

        if(Pl_State.P_AttaState == PlayerAttackState.AimShoot)
        {
            PlayerAimFunc();
        }
    }

    void PlayerShootFunc()
    {
        Debug.Log("Shoot");
    }


    void PlayerAimFunc()
    {
        Debug.Log("AimShoot");
    }
}