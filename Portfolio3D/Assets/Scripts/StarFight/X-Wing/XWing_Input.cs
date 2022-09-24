using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class XWing_Input : MonoBehaviour
{
    XWing_State_Ctrl x_State;
    XWing_Att x_Att;

    public Image Aim;


    public float v;
    //public float h;


    //무기 상태 변경하는 변수
    public int shotState;


    //전투 돌입 타이머
    public bool isBattleMode;
    public bool battleTime;
    public float battleTimer;


    Animator animator;

    //전투 모드 전환시 AIm위치 변경하기
    Vector3 aimOriginPos;
    Vector3 aimTargetPos;


    private void Start() => StartFunc();

    private void StartFunc()
    {
        x_State = GetComponent<XWing_State_Ctrl>();
        x_Att = GetComponent<XWing_Att>();
        animator = GetComponentInChildren<Animator>();
        isBattleMode = false;
        battleTime = false;
        shotState = 0;
        aimOriginPos = new Vector3(6, 20, -400);
        aimTargetPos = new Vector3(6, 60, -400);
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        //h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (/*h == 0 &&*/ v == 0)
        {
            x_State.X_State = XWingState.IdleFly;
        }
        else
        {
            x_State.X_State = XWingState.Fly;
        }

        //전투모드 전환
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isBattleMode)
            {
                isBattleMode = false;
                animator.SetBool("isBattle", false);


            }
            else
            {
                isBattleMode = true;
                animator.SetBool("isBattle", true);

            }
        }

        if(isBattleMode)
        {
            //Aim옮기기 20 -> 60
            Aim.transform.localPosition = Vector3.Lerp(aimOriginPos, aimTargetPos, Time.fixedDeltaTime * 50.0f);
        }
        else
        {
            //Aim다시 60 -> 20으로 옮기기
            Aim.transform.localPosition = Vector3.Lerp(aimTargetPos, aimOriginPos, Time.fixedDeltaTime * 50.0f);
        }
        //전투모드 전환

        //전투 지속 시간 (15초 동안 피격이나 발사가 없으면 비전투 타임으로 돌아감)
        if (battleTime)
        {
            x_State.X_State = XWingState.Attack;
            battleTimer -= Time.deltaTime;
        }
        if (battleTimer <= 0)
        {
            battleTime = false;
        }
        //전투 지속 시간

        //무기 타입 변환
        if (Input.GetKeyDown(KeyCode.C))
        {
            shotState++;
            if (shotState > 3)
            {
                shotState = 0;
            }
            x_State.XW_State = (XWingWeaponState)shotState;
        }
        //무기 타입 변환

        //무기 타입별 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            battleTime = true;
            battleTimer = 15.0f;
            if(x_State.XW_State == XWingWeaponState.oneShot)
            {
                x_Att.OneShotFunc();
            }
            else if(x_State.XW_State == XWingWeaponState.spotShot)
            {
                x_Att.SpotShotFunc();
            }
        }

        if(x_State.XW_State == XWingWeaponState.drillShot)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                x_Att.DrillShotFunc();
            }
        }
        //무기 타입별 발사


    }
}