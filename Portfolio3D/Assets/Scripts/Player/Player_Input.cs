using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    Player_State_Ctrl Pl_State;

    public float v;
    public float h;

    //에임을 켰는지 안켰는지 확인하는 bool값
    public bool isAim;

    private void Awake()
    {
    }

    private void Start() => StartFunc();

    private void StartFunc()
    {
        Pl_State = GetComponent<Player_State_Ctrl>();
        isAim = false;
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        //---가감속 없이 이동 처리 하는 방법
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        //---가감속 없이 이동 처리 하는 방법

        if (0.0f != h || 0.0f < v)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
        }
        else
        {
            Pl_State.P_State = PlayerMoveState.Idle;
        }

        if(Input.GetMouseButton(1))
        {
            Pl_State.P_AttaState = PlayerAttackState.Aim;
            isAim = true;
        }
        else
        {
            isAim = false;
            Pl_State.P_AttaState = PlayerAttackState.noAim;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Pl_State.P_AttaState = PlayerAttackState.Shoot;

            if(isAim == true)
            {
                Pl_State.P_AttaState = PlayerAttackState.AimShoot;
            }
        }

    }
}