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


    //���� ���� �����ϴ� ����
    public int shotState;


    //���� ���� Ÿ�̸�
    public bool isBattleMode;
    public bool battleTime;
    public float battleTimer;


    Animator animator;

    //���� ��� ��ȯ�� AIm��ġ �����ϱ�
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

        //������� ��ȯ
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
            //Aim�ű�� 20 -> 60
            Aim.transform.localPosition = Vector3.Lerp(aimOriginPos, aimTargetPos, Time.fixedDeltaTime * 50.0f);
        }
        else
        {
            //Aim�ٽ� 60 -> 20���� �ű��
            Aim.transform.localPosition = Vector3.Lerp(aimTargetPos, aimOriginPos, Time.fixedDeltaTime * 50.0f);
        }
        //������� ��ȯ

        //���� ���� �ð� (15�� ���� �ǰ��̳� �߻簡 ������ ������ Ÿ������ ���ư�)
        if (battleTime)
        {
            x_State.X_State = XWingState.Attack;
            battleTimer -= Time.deltaTime;
        }
        if (battleTimer <= 0)
        {
            battleTime = false;
        }
        //���� ���� �ð�

        //���� Ÿ�� ��ȯ
        if (Input.GetKeyDown(KeyCode.C))
        {
            shotState++;
            if (shotState > 3)
            {
                shotState = 0;
            }
            x_State.XW_State = (XWingWeaponState)shotState;
        }
        //���� Ÿ�� ��ȯ

        //���� Ÿ�Ժ� �߻�
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
        //���� Ÿ�Ժ� �߻�


    }
}