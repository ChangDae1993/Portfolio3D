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

    float a_CalcRotY = 0.0f;
    float rotSpeed = 150.0f;    //�ʴ� 150�� ȸ���϶�� �ӵ�
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

        if (0.0f != P_Input.h || 0.0f < P_Input.v)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
            animator.SetBool("IsMove", true);
            //---�Ϲ����� �̵� ����
            a_CalcRotY = transform.eulerAngles.y;
            a_CalcRotY = a_CalcRotY + (P_Input.h * rotSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0.0f, a_CalcRotY, 0.0f);

            MoveVStep = transform.forward * P_Input.v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
            //---�Ϲ����� �̵� ����
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
            //---�Ϲ����� �̵� ����
            a_CalcRotY = transform.eulerAngles.y;
            a_CalcRotY = a_CalcRotY + (P_Input.h * rotSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0.0f, a_CalcRotY, 0.0f);

            MoveVStep = transform.forward * P_Input.v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
            //---�Ϲ����� �̵� ����
        }
        else
        {
            animator.SetBool("IsBMove", false);
        }
    }
}