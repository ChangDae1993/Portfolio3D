using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    Player_State_Ctrl Pl_State;
    Player_Input P_Input;

    Animator animator;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        Pl_State = GetComponent<Player_State_Ctrl>();
        P_Input = GetComponent<Player_Input>();
        animator = GetComponent<Animator>();
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        if(Pl_State.P_AttaState == PlayerAttackState.Shoot)
        {
            PlayerShootFunc();
        }

        PlayerAimFunc();

        if (Pl_State.P_AttaState == PlayerAttackState.AimShoot)
        {
            PlayerAimAttFunc();
        }
    }

    void PlayerShootFunc()
    {
        Debug.Log("Shoot");
    }

    void PlayerAimFunc()
    {
        if(P_Input.isAim)
        {
            Debug.Log("¡‹¿Œ");
            if(Pl_State.P_State == PlayerMoveState.Idle)
            {
                animator.SetBool("IsIdleAim", true);
            }

            if(Pl_State.P_State != PlayerMoveState.Idle)
            {
                animator.SetBool("IsIdleAim", false);
            }
        }
        else
        {
            animator.SetBool("IsIdleAim", false);
            //Debug.Log("¡‹æ∆øÙ");
        }
    }


    void PlayerAimAttFunc()
    {
        Debug.Log("AimShoot");
    }
}