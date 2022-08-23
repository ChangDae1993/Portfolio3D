using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walk,
    Run,
    runGuard,
    Ducking,
    Jump,
    noAim,
    Aim,
    AimShoot,
    Shoot,
    AutoShoot,
    BurstShoot,
    Reload,
    Hit,
    Die
}


public class HeroCtrl : MonoBehaviour
{
    public PlayerState P_State;

    float m_MoveVelocity = 3.0f;    //평면 초당 이동 속도

    //---키보드 입력 이동 관련 변수 선언
    float h = 0, v = 0;
    Vector3 MoveNextStep;   //보폭을 계산해 주기 위한 변수
    Vector3 MoveHStep;
    Vector3 MoveVStep;

    float a_CalcRotY = 0.0f;
    float rotSpeed = 150.0f;    //초당 150도 회전하라는 속도
    //---키보드 입력 이동 관련 변수 선언

    Animator animator;

    private void Awake()
    {
        CameraCtrl a_CamCtrl = Camera.main.GetComponent<CameraCtrl>();
        if (a_CamCtrl != null)
            a_CamCtrl.InitCamera(this.gameObject);

        animator = GetComponent<Animator>();
    }

    private void Start() => StartFunc();

    private void StartFunc()
    {
        P_State = PlayerState.Idle;
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        KeyBDMove();

        if(Input.GetMouseButton(1))
        {
            P_State = PlayerState.Aim;

            if(P_State == PlayerState.Aim)
            {
                PlayerAimFunc();
            }
        }
        else
        {
            Debug.Log("AimX");
        }
    }

    void KeyBDMove()    //키보드 이동
    {
        //---가감속 없이 이동 처리 하는 방법
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        //---가감속 없이 이동 처리 하는 방법

        //Debug.Log(v);

        if (0.0f != h || 0.0f < v)
        {
            P_State = PlayerState.Walk;
            animator.SetBool("IsMove", true);
            //---일반적인 이동 계산법
            a_CalcRotY = transform.eulerAngles.y;
            a_CalcRotY = a_CalcRotY + (h * rotSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0.0f, a_CalcRotY, 0.0f);

            MoveVStep = transform.forward * v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
            //---일반적인 이동 계산법
        }
        else
        {
            P_State = PlayerState.Idle;
            animator.SetBool("IsMove", false);
        }

        if (v < 0.0f)
        {
            P_State = PlayerState.Walk;
            animator.SetBool("IsBMove", true);
            //---일반적인 이동 계산법
            a_CalcRotY = transform.eulerAngles.y;
            a_CalcRotY = a_CalcRotY + (h * rotSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0.0f, a_CalcRotY, 0.0f);

            MoveVStep = transform.forward * v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
            //---일반적인 이동 계산법
        }
        else
        {
            animator.SetBool("IsBMove", false);
        }
    }

    void PlayerAimFunc()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Aim");
        }
    }
}