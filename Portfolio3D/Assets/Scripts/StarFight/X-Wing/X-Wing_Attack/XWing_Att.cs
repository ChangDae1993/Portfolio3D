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

    //스킬 게이지
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

    #region 단발
    public void OneShotFunc()
    {
        if (attNum >= 4)
        {
            attNum = 0;
        }

        Debug.Log(ShotPos[attNum]);

        //레이저 생성 구간
        Instantiate(Laser, ShotPos[attNum].position, ShotPos[attNum].rotation);
        //레이저 생성 구간

        attNum++;
    }
    #endregion

    #region 3연발
    public void SpotShotFunc()
    {
        Debug.Log("2Spot");
    }
    #endregion

    #region 연사
    public void DrillShotFunc()
    {
        Debug.Log("Drill");
    }
    #endregion


    #region 스킬 구현 부분
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
        //카메라 사이즈 80->65까지 낮추기
        cam.fieldOfView += Time.deltaTime * 50.0f;
        if(cam.fieldOfView >120)
        {
            cam.fieldOfView = 120;
        }
        //TimeScale 0.5로 바꾸기
        Time.timeScale = 0.2f;

        //캔버스 색 푸른색으로 살짝 바꾸기
        skill3Alpha += Time.deltaTime * 10.0f;
        skill3BG.color = new Color(0/255f, 30/255f, 255/255f, (skill3Alpha)/255f);

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
}
