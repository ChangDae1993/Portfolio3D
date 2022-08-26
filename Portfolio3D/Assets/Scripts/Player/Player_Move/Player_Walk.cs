using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Walk : MonoBehaviour
{
    Player_State_Ctrl Pl_State;
    Player_Input P_Input;

    private float v;
    private float h;
    
    Animator animator;

    float m_MoveVelocity = 3.0f;    //평면 초당 이동 속도

    float runSpeed = 20.0f;

    Vector3 MoveNextStep;   //보폭을 계산해 주기 위한 변수
    Vector3 MoveHStep;
    Vector3 MoveVStep;

    //---키보드 입력 이동 관련 변수 선언

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
        KeyBDMove();
    }

    private void KeyBDMove()
    {

        if (P_Input.h == 0.0f && P_Input.v == 0.0f)
        {
            animator.SetBool("IsMove", false);
        }

        if (0.0f < P_Input.v)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
            animator.SetBool("IsMove", true);

            MoveVStep = transform.forward * P_Input.v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;

            //정면으로 걸을 때 Dash추가
            if (P_Input.isDash)
            {
                Pl_State.P_State = PlayerMoveState.Run;
                animator.SetBool("IsRun", true);
                MoveVStep = transform.forward * P_Input.v * runSpeed;
                MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
                transform.position = transform.position + MoveNextStep;
            }
            else
            {
                animator.SetBool("IsRun", false);
                MoveVStep = transform.forward * P_Input.v;
            }
        }
        else
        {
            animator.SetBool("IsMove", false);
        }

        if (0.0f < P_Input.h)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
            animator.SetBool("IsRMove", true);
            MoveHStep = transform.right * P_Input.h;
            MoveNextStep = MoveHStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
        }
        else
        {
            animator.SetBool("IsRMove", false);
        }

        if (P_Input.h < 0.0f)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
            animator.SetBool("IsLMove", true);
            MoveHStep = transform.right * P_Input.h;
            MoveNextStep = MoveHStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
        }
        else
        {
            animator.SetBool("IsLMove", false);
        }


        if (P_Input.v < 0.0f)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
            animator.SetBool("IsBMove", true);

            MoveVStep = transform.forward * P_Input.v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
        }
        else
        {
            animator.SetBool("IsBMove", false);
        }


    }
}