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

    Vector3 MoveNextStep;   //보폭을 계산해 주기 위한 변수
    Vector3 MoveHStep;
    Vector3 MoveVStep;

    float a_CalcRotY = 0.0f;
    float rotSpeed = 150.0f;    //초당 150도 회전하라는 속도
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
        ////---가감속 없이 이동 처리 하는 방법
        //h = Input.GetAxisRaw("Horizontal");
        //v = Input.GetAxisRaw("Vertical");
        ////---가감속 없이 이동 처리 하는 방법

        if (0.0f != P_Input.h || 0.0f < P_Input.v)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
            animator.SetBool("IsMove", true);
            //---일반적인 이동 계산법
            a_CalcRotY = transform.eulerAngles.y;
            a_CalcRotY = a_CalcRotY + (P_Input.h * rotSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0.0f, a_CalcRotY, 0.0f);

            MoveVStep = transform.forward * P_Input.v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
            //---일반적인 이동 계산법
        }
        else
        {
            //P_State = PlayerMoveState.Idle;
            animator.SetBool("IsMove", false);
        }

        if (P_Input.v < 0.0f)
        {
            //P_State = PlayerMoveState.Walk;
            animator.SetBool("IsBMove", true);
            //---일반적인 이동 계산법
            a_CalcRotY = transform.eulerAngles.y;
            a_CalcRotY = a_CalcRotY + (P_Input.h * rotSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0.0f, a_CalcRotY, 0.0f);

            MoveVStep = transform.forward * P_Input.v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
            //---일반적인 이동 계산법
        }
        else
        {
            animator.SetBool("IsBMove", false);
        }
    }
}