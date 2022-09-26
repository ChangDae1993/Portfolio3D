using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class XWing_Input : MonoBehaviour
{
    XWing_State_Ctrl x_State;
    XWing_Att x_Att;
    Animator animator;

    public Image Aim;

    public float v;
    //public float h;

    //���� ���� �����ϴ� ����
    public int shotState;


    //���� ��� ��ȯ�� AIm��ġ �����ϱ�
    Vector3 aimOriginPos;
    Vector3 aimTargetPos;

    //���� ���� Ÿ�̸�
    public bool isBattleMode;
    public bool battleTime;
    public float battleTimer;

    //��ų bool��
    public bool isSkill1;
    public bool isSKill2;
    public bool isSkill3;

    //��ų Ÿ�̸�
    public float skill1Cool;
    public float skill2Cool;
    public float skill3Cool;



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



        isSkill1 = false;
        isSKill2 = false;
        isSkill3 = false;

        skill1Cool = 3.0f;
        skill2Cool = 3.0f;
        skill3Cool = 3.0f;
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

        #region ������� ��ȯ
        if (Input.GetKeyDown(KeyCode.G))
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
        #endregion

        #region ���� ���� �ð� (15�� ���� �ǰ��̳� �߻簡 ������ ������ Ÿ������ ���ư�)
        if (battleTime)
        {
            x_State.X_State = XWingState.Attack;
            battleTimer -= Time.deltaTime;
        }
        if (battleTimer <= 0)
        {
            battleTime = false;
        }
        #endregion


        #region ���� Ÿ�� ��ȯ
        if (Input.GetKeyDown(KeyCode.C))
        {
            shotState++;
            if (shotState > 3)
            {
                shotState = 0;
            }
            x_State.XW_State = (XWingWeaponState)shotState;
        }
        #endregion


        #region ���� Ÿ�Ժ� �߻�
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
        #endregion

        #region ��ų �κ�

        if (Input.GetKeyDown(KeyCode.Q))
        {
            isSkill1 = true;
        }
        if(isSkill1)
        {
            x_Att.Skill1();
            skill1Cool -= Time.deltaTime;

            if(skill1Cool<= 0.0f)
            {
                isSkill1 = false;
                skill1Cool = 3.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            isSKill2 = true;
        }
        if(isSKill2)
        {
            x_Att.Skill2();
            skill2Cool -= Time.deltaTime;

            if(skill2Cool <= 0.0f)
            {
                isSKill2 = false;
                skill2Cool = 3.0f;
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            isSkill3 = true;

        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            isSkill3 = false;
            x_Att.Skill3Fire();
        }

        if (isSkill3)
        {
            x_Att.Skill3();
        }
        else
        {

        }
        #endregion
    }
}