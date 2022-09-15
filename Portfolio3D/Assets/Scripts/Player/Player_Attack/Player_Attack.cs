using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    Player_State_Ctrl Pl_State;
    Player_Input P_Input;
    [SerializeField] private Camera cam;
    Animator animator;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        Pl_State = GetComponent<Player_State_Ctrl>();
        P_Input = GetComponent<Player_Input>();
        animator = GetComponent<Animator>();
        cam = GetComponentInChildren<Camera>();
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        if (Pl_State.P_AttaState == PlayerAttackState.Shoot)
        {
            PlayerShootFunc();
        }

        PlayerAimFunc();

        if (Pl_State.P_AttaState == PlayerAttackState.AimShoot)
        {
            PlayerAimAttFunc();
        }

        if (P_Input.isAim)
        {

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
            cam.fieldOfView -= Time.deltaTime * 150.0f;

            if(cam.fieldOfView <= 50)
            {
                cam.fieldOfView = 50;
            }
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
            cam.fieldOfView += Time.deltaTime * 150.0f;

            if (cam.fieldOfView >= 70)
            {
                cam.fieldOfView = 70;
            }
            animator.SetBool("IsIdleAim", false);
            //Debug.Log("¡‹æ∆øÙ");
        }
    }


    void PlayerAimAttFunc()
    {
        Debug.Log("AimShoot");
    }
}