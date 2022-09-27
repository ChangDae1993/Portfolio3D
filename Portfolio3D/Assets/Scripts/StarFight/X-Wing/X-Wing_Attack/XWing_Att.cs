using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XWing_Att : MonoBehaviour
{
    public Transform[] ShotPos;
    int attNum = 0;
    public Transform TorphidoShotPos;

    public GameObject Laser;
    public Camera cam;
    public Image skill3BG;
    public float skill3Alpha;

    public GameObject skill3Show;

    //��ų ������
    public Image skill3Gage;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        skill3Alpha = 0.0f;
        skill3Show.gameObject.SetActive(false);
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    #region �ܹ�
    public void OneShotFunc()
    {
        if (attNum >= 4)
        {
            attNum = 0;
        }

        Debug.Log(ShotPos[attNum]);

        //������ ���� ����
        Instantiate(Laser, ShotPos[attNum].position, ShotPos[attNum].rotation);
        //������ ���� ����

        attNum++;
    }
    #endregion

    #region 3����
    public void SpotShotFunc()
    {
        Debug.Log("2Spot");
    }
    #endregion

    #region ����
    public void DrillShotFunc()
    {
        Debug.Log("Drill");
    }
    #endregion


    #region ��ų ���� �κ�
    public void Skill1()
    {
        Debug.Log("skill1");
    }

    public void Skill2()
    {
        Debug.Log("Skill2");
    }

    public void Skill3()
    {
        Debug.Log("SKill3");
        //ī�޶� ������ 80->65���� ���߱�
        cam.fieldOfView += Time.deltaTime * 50.0f;
        if(cam.fieldOfView >120)
        {
            cam.fieldOfView = 120;
        }
        //TimeScale 0.5�� �ٲٱ�
        Time.timeScale = 0.2f;

        //ĵ���� �� Ǫ�������� ��¦ �ٲٱ�
        skill3Alpha += Time.deltaTime * 10.0f;
        skill3BG.color = new Color(0/255f, 30/255f, 255/255f, (skill3Alpha)/255f);

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
}
