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
    //3���� ����
    [SerializeField] private int att3Num = 0;
    [SerializeField] private bool upShot;

    [Header("---BurstShot---")]
    [SerializeField] private int a = 0;

    //R��ų ������
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


    #region �ܹ�
    public void OneShotFunc()
    {
        if (attNum >= 4)
        {
            attNum = 0;
        }
        //������ ���� ����
        Instantiate(Laser, ShotPos[attNum].position, ShotPos[attNum].rotation);
        //������ ���� ����

        attNum++;
    }
    #endregion

    #region 3����
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

    #region ����Ʈ��
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


    #region ��ų ���� �κ�

    #region Q��ų
    public void Skill1()
    {
        QbulletFire();
    }

    public void QbulletFire()
    {
        //�켱 ��ź �����ϰ�
        Instantiate(Q_Bullet, TorphidoShotPos.position, TorphidoShotPos.rotation);
    }
    #endregion

    #region E��ų
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

    #region R��ų
    public void Skill3()
    {
        Debug.Log("SKill3");
        //ī�޶� ������ 80->65���� ���߱�
        cam.fieldOfView += Time.deltaTime * 50.0f;
        if (cam.fieldOfView > 120)
        {
            cam.fieldOfView = 120;
        }
        //TimeScale 0.5�� �ٲٱ�
        Time.timeScale = 0.2f;

        //ĵ���� �� Ǫ�������� ��¦ �ٲٱ�
        skill3Alpha += Time.deltaTime * 10.0f;
        skill3BG.color = new Color(0 / 255f, 30 / 255f, 255 / 255f, (skill3Alpha) / 255f);

        //������ ǥ�� + ���
        skill3Show.gameObject.SetActive(true);
        skill3Gage.fillAmount -= Time.deltaTime * 0.3f;

    }

    public void Skill3Fire()
    {
        Debug.Log("1");

        //TimeScale 1.0���� �ǵ�����
        Time.timeScale = 1.0f;
        //ĵ���� �� ������� �ٲٱ�
        skill3BG.color = new Color(0, 0, 0, 0);
        //ī�޶� ������ 65->80���� �ٲٱ�
        cam.fieldOfView = 80;

        //������ ����
        skill3Show.gameObject.SetActive(false);
        skill3Gage.fillAmount = 1.0f;

        //�ù߻�


    }
    #endregion

    #endregion
}
