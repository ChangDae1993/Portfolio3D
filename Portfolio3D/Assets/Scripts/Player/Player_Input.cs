using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    Player_State_Ctrl Pl_State;

    public float v;
    public float h;

    //������ �״��� ���״��� Ȯ���ϴ� bool��
    [SerializeField] bool isAim;

    private void Awake()
    {
        CameraCtrl a_CamCtrl = Camera.main.GetComponent<CameraCtrl>();
        if (a_CamCtrl != null)
            a_CamCtrl.InitCamera(this.gameObject);
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
        //---������ ���� �̵� ó�� �ϴ� ���
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        //---������ ���� �̵� ó�� �ϴ� ���

        if (0.0f != h || 0.0f < v)
        {
            Pl_State.P_State = PlayerMoveState.Walk;
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