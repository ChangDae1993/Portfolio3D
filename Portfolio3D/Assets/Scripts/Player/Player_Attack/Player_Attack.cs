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
            Debug.Log("줌인");
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
            //Debug.Log("줌아웃");
        }
    }

    void PlayerShootFunc()
    {
        Debug.Log("Shoot");
        //Transform Shot_Pos받아와서 그 위치에서 총알 instantiate하기
        //instantiate는 산탄도에 따라 Random.Range로 생성하기(에임 안하고있는 기준)
        //총알 종류별로 다르게 resource.Load하기
    }


    void PlayerAimAttFunc()
    {
        //Transform Shot_Pos 받아와서 그 위치에서 총알 instantiate하기
        //instantiate는 줌하고있는 상태의 총기별 산탄도에 따라 Random.Range로 생성하기
        //총알 종류별로 다르게 resources.Load하기
        Debug.Log("AimShoot");
    }
}