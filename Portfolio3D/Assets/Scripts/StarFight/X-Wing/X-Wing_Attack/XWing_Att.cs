using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class XWing_Att : MonoBehaviour
{

    XWing_State_Ctrl xState;
    XWing_Input xInput;

    [Header("Normal bullet ShotPos")]
    public Transform[] ShotPos;

    [Header("Q skill Shot Pos")]
    public Transform TorphidoShotPos;

    [Header("Normal bullet Prefab")]
    public GameObject Laser;

    [Header("Q skill bullet Prefab")]
    public GameObject Q_Bullet;

    [Header("E skill value")]
    public float repairCost;

    public Camera cam;
    public Image skill3BG;
    public float skill3Alpha;

    public GameObject skill3Show;

    [Header("---1Shot---")]
    [SerializeField] private int attNum = 0;

    [Header("---3Shot---")]
    //3연발 관련
    [SerializeField] private int att3Num = 0;
    [SerializeField] private bool upShot;

    [Header("---BurstShot---")]
    [SerializeField] private int a = 0;

    //R스킬 게이지
    public Image skill3Gage;

    // Start is called before the first frame update
    void Start()
    {
        xState = GetComponent<XWing_State_Ctrl>();
        xInput = GetComponent<XWing_Input>();
        cam = GetComponent<Camera>();
        skill3Alpha = 0.0f;
        skill3Show.gameObject.SetActive(false);
        upShot = true;

        repairCost = 0.1f;
    }


    #region 단발
    public void OneShotFunc()
    {
        if (attNum >= 4)
        {
            attNum = 0;
        }
        //레이저 생성 구간
        Instantiate(Laser, ShotPos[attNum].position, ShotPos[attNum].rotation);
        //레이저 생성 구간

        attNum++;
    }
    #endregion

    #region 3연발
    public void SpotShotFunc()
    {
        if (upShot)
        {
            StartCoroutine(Upshot3AttCo());
        }
        else
        {
            StartCoroutine(Downshot3AttCo());
        }
    }

    IEnumerator Upshot3AttCo()
    {
        int a = 0;
        while (a < 3)
        {
            Instantiate(Laser, ShotPos[0].position, ShotPos[0].rotation);
            Instantiate(Laser, ShotPos[1].position, ShotPos[1].rotation);
            yield return new WaitForSeconds(0.1f);
            a++;
            if (a >= 3)
            {
                upShot = false;
                yield break;
            }
        }
    }
    IEnumerator Downshot3AttCo()
    {
        int a = 0;
        while (a < 3)
        {
            Instantiate(Laser, ShotPos[2].position, ShotPos[2].rotation);
            Instantiate(Laser, ShotPos[3].position, ShotPos[3].rotation);
            yield return new WaitForSeconds(0.1f);
            a++;
            if (a >= 3)
            {
                upShot = true;
                yield break;
            }
        }
    }
    #endregion

    #region 버스트샷
    public void DrillShotFunc()
    {
        StartCoroutine(BurstShotCo());
    }

    IEnumerator BurstShotCo()
    {
        Debug.Log("Test Here");
        while (a < 20)
        {
            Instantiate(Laser, ShotPos[0].position, ShotPos[0].rotation);
            Instantiate(Laser, ShotPos[1].position, ShotPos[1].rotation);
            Instantiate(Laser, ShotPos[2].position, ShotPos[2].rotation);
            Instantiate(Laser, ShotPos[3].position, ShotPos[3].rotation);
            yield return new WaitForSeconds(0.1f);
            a++;
            if (a >= 20)
            {
                a = 0;
                yield break;
            }
        }
    }
    #endregion


    #region 스킬 구현 부분

    #region Q스킬
    public void Skill1()
    {
        QbulletFire();
    }

    public void QbulletFire()
    {
        //우선 폭탄 생성하고
        Instantiate(Q_Bullet, TorphidoShotPos.position, TorphidoShotPos.rotation);
    }
    #endregion

    #region E스킬
    public void Skill2()
    {
        //E skill for healing skillj
        //repair start -> hp++ -> up by percentage?
        if (xState.P_curhp < xState.P_maxhp)
        {
            StartCoroutine(repairCo());
        }
        else
        {
            Debug.Log("Repair no need");
        }
        Debug.Log("Skill2");
    }

    IEnumerator repairCo()
    {
        while(xInput.isRepairOn)
        {
            xState.P_curhp += repairCost;

            if(xState.P_curhp >= xState.P_maxhp || xInput.skill2Cool <= 1f)
            {
                xInput.isRepairOn = false;
            }
            yield return null;
        }

    }

    #endregion

    #region R스킬
    public void Skill3()
    {
        Debug.Log("SKill3");
        //카메라 사이즈 80->65까지 낮추기
        cam.fieldOfView += Time.deltaTime * 50.0f;
        if (cam.fieldOfView > 120)
        {
            cam.fieldOfView = 120;
        }
        //TimeScale 0.5로 바꾸기
        Time.timeScale = 0.2f;

        //캔버스 색 푸른색으로 살짝 바꾸기
        skill3Alpha += Time.deltaTime * 10.0f;
        skill3BG.color = new Color(0 / 255f, 30 / 255f, 255 / 255f, (skill3Alpha) / 255f);

        //게이지 표출 + 깎기
        skill3Show.gameObject.SetActive(true);
        skill3Gage.fillAmount -= Time.deltaTime * 0.3f;

    }

    public void Skill3Fire()
    {
        Debug.Log("1");

        //TimeScale 1.0으로 되돌리기
        Time.timeScale = 1.0f;
        //캔버스 색 원래대로 바꾸기
        skill3BG.color = new Color(0, 0, 0, 0);
        //카메라 사이즈 65->80으로 바꾸기
        cam.fieldOfView = 80;

        //게이지 끄기
        skill3Show.gameObject.SetActive(false);
        skill3Gage.fillAmount = 1.0f;

        //궁발사


    }
    #endregion

    #endregion
}
