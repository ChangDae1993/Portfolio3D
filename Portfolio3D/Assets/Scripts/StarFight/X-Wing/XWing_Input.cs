using UnityEngine;
using UnityEngine.UI;

public class XWing_Input : MonoBehaviour
{
    XWing_State_Ctrl x_State;
    XWing_Att x_Att;
    Animator animator;

    public Image Aim;

    public float v;
    //public float h;

    //무기 상태 변경하는 변수
    public int shotState;

    [Header("---SpotShot")]
    //점사 타이머
    [SerializeField] private bool is3Shot;
    [SerializeField] private float shotTimer;

    [Header("---BurstShot---")]
    //버스트 타이머
    [SerializeField] private bool isBurstShot;
    [SerializeField] private float shotBurstCoolTimer;  //연사 쿨타임


    //전투 모드 전환시 AIm위치 변경하기
    Vector3 aimOriginPos;
    Vector3 aimTargetPos;

    [Header("---Battle Timer---")]
    //전투 돌입 타이머
    public bool isBattleMode;
    public bool battleTime;
    public float battleTimer;

    //스킬 bool값
    public bool isSkill1;
    public bool isSKill2;
    public bool isRepairOn;
    public bool isSkill3;
    public bool isSKill4;

    //스킬 타이머
    public float skill1Cool;
    public float skill2Cool;
    public float skill3Cool;



    void Start()
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
        isRepairOn = false;
        isSkill3 = false;
        isSKill4 = false;


        skill1Cool = 3.0f;
        skill2Cool = 3.0f;
        skill3Cool = 3.0f;

        is3Shot = false;
        shotTimer = 1.0f;

        isBurstShot = false;
        shotBurstCoolTimer = 0.0f;

    }

    private void Update()
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

        #region 전투모드 전환
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

        if (isBattleMode)
        {
            //Aim옮기기 20 -> 60
            Aim.transform.localPosition = Vector3.Lerp(aimOriginPos, aimTargetPos, Time.fixedDeltaTime * 50.0f);
        }
        else
        {
            //Aim다시 60 -> 20으로 옮기기
            Aim.transform.localPosition = Vector3.Lerp(aimTargetPos, aimOriginPos, Time.fixedDeltaTime * 50.0f);
        }
        #endregion

        #region 전투 지속 시간 (15초 동안 피격이나 발사가 없으면 비전투 타임으로 돌아감)
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


        #region 무기 타입 변환
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


        #region 무기 타입별 발사

        #region 단발
        if (Input.GetKeyDown(KeyCode.Space))
        {
            battleTime = true;
            battleTimer = 15.0f;
            if (x_State.XW_State == XWingWeaponState.oneShot)
            {
                //단발
                x_Att.OneShotFunc();
            }
            else if (x_State.XW_State == XWingWeaponState.spotShot)
            {
                if (!is3Shot)
                {
                    x_Att.SpotShotFunc();
                    shotTimer = 1.0f;
                }
            }
        }
        #endregion

        #region 3점사
        if (shotTimer > 0)
        {
            shotTimer -= Time.deltaTime;
            is3Shot = true;
        }
        else
        {
            is3Shot = false;
        }
        #endregion

        #region 연사
        if (x_State.XW_State == XWingWeaponState.drillShot)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isBurstShot)
                {
                    x_Att.DrillShotFunc();
                    shotBurstCoolTimer = 10.0f;
                }

            }
        }

        if (shotBurstCoolTimer > 0)
        {
            shotBurstCoolTimer -= Time.deltaTime;
            isBurstShot = true;
        }
        else
        {
            isBurstShot = false;
        }
        #endregion

        #endregion

        #region 스킬 부분

        #region Q스킬
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("Q Skill Start");
            isSkill1 = true;
            if (skill1Cool >= 3.0f)
            {
                x_State.XS_State = XWingSkillState.Skill1;
                x_Att.Skill1();
            }
        }
        if (isSkill1)
        {
            skill1Cool -= Time.deltaTime;
            if (skill1Cool <= 0.0f)
            {
                isSkill1 = false;
                skill1Cool = 3.0f;
            }
        }
        #endregion

        #region E스킬
        if (Input.GetKeyDown(KeyCode.E))
        {
            isSKill2 = true;
            isRepairOn = true;
            if (skill2Cool >= 3.0f || isRepairOn)
            {
                x_State.XS_State = XWingSkillState.Skill2;
                x_Att.Skill2();
            }
        }
        if (isSKill2)
        {
            skill2Cool -= Time.deltaTime;
            if (skill2Cool <= 0.0f)
            {
                isSKill2 = false;
                skill2Cool = 3.0f;
            }
        }
        #endregion

        #region R스킬(궁)
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
            Debug.Log("Here for What");
        }
        #endregion

        #region Dash스킬
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSKill4 = true;
            x_Att.Skill4();
        }
        #endregion

        #endregion
    }
}