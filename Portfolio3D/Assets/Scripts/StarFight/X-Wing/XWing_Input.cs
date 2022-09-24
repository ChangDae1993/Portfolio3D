using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class XWing_Input : MonoBehaviour
{
    XWing_State_Ctrl x_State;
    XWing_Att x_Att;


    public float v;
    //public float h;


    //무기 상태 변경하는 변수
    public int shotState;


    //전투 돌입 타이머
    public bool isBattleMode;
    public bool battleTime;
    public float battleTimer;


    Animator animator;


    private void Start() => StartFunc();

    private void StartFunc()
    {
        x_State = GetComponent<XWing_State_Ctrl>();
        x_Att = GetComponent<XWing_Att>();
        animator = GetComponentInChildren<Animator>();
        isBattleMode = false;
        battleTime = false;
        shotState = 0;
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