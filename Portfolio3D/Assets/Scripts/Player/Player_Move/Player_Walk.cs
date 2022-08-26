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

    float m_MoveVelocity = 3.0f;    //��� �ʴ� �̵� �ӵ�


    Vector3 MoveNextStep;   //������ ����� �ֱ� ���� ����
    Vector3 MoveHStep;
    Vector3 MoveVStep;

    //---Ű���� �Է� �̵� ���� ���� ����

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
        ////---������ ���� �̵� ó�� �ϴ� ���
        //h = Input.GetAxisRaw("Horizontal");
        //v = Input.GetAxisRaw("Vertical");
        ////---������ ���� �̵� ó�� �ϴ� ���

        if (0.0f < P_Input.v)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
            animator.SetBool("IsMove", true);

            MoveVStep = transform.forward * P_Input.v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
            //---�Ϲ����� �̵� ����
        }

        if (P_Input.v < 0.0f)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
            animator.SetBool("IsBMove", true);

            MoveVStep = transform.forward * P_Input.v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
            //---�Ϲ����� �̵� ����
        }
        else
        {
            animator.SetBool("IsBMove", false);
        }

        if (0.0f < P_Input.h)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
            animator.SetBool("IsMove", true);
            MoveHStep = transform.right * P_Input.h;
            MoveNextStep = MoveHStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
        }

        if(P_Input.h < 0.0f)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
            animator.SetBool("IsMove", true);
            MoveHStep = transform.right * P_Input.h;
            MoveNextStep = MoveHStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
        }

        if (P_Input.h == 0.0f && P_Input.v == 0.0f)
        {
            animator.SetBool("IsMove", false);
        }



    }
}