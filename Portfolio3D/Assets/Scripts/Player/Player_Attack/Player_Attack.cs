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
        PlayerAimFunc();

        if (Pl_State.P_AttaState == PlayerAttackState.Shoot)
        {
            PlayerShootFunc();
        }

        if (Pl_State.P_AttaState == PlayerAttackState.AimShoot)
        {
            PlayerAimAttFunc();
        }
    }


    void PlayerAimFunc()
    {
        if(P_Input.isAim)
        {
            Debug.Log("����");
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
            //Debug.Log("�ܾƿ�");
        }
    }

    void PlayerShootFunc()
    {
        Debug.Log("Shoot");
        //Transform Shot_Pos�޾ƿͼ� �� ��ġ���� �Ѿ� instantiate�ϱ�
        //instantiate�� ��ź���� ���� Random.Range�� �����ϱ�(���� ���ϰ��ִ� ����)
        //�Ѿ� �������� �ٸ��� resource.Load�ϱ�
    }


    void PlayerAimAttFunc()
    {
        //Transform Shot_Pos �޾ƿͼ� �� ��ġ���� �Ѿ� instantiate�ϱ�
        //instantiate�� ���ϰ��ִ� ������ �ѱ⺰ ��ź���� ���� Random.Range�� �����ϱ�
        //�Ѿ� �������� �ٸ��� resources.Load�ϱ�
        Debug.Log("AimShoot");
    }
}