using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScene_mgr : MonoBehaviour
{
    public Image fadein_img;
    public Text title_txt;
    public Text sub_title_txt;

    // Start is called before the first frame update
    void Start()
    {
        this.sub_title_txt.GetComponent<Text>();
        this.title_txt.gameObject.SetActive(false);
        this.sub_title_txt.gameObject.SetActive(false);

        Application.targetFrameRate = 60; //실행 프레임 속도 60프레임으로 고정 시키기.. 코드

        QualitySettings.vSyncCount = 0; //모니터 주사율(플레임율)이 다른 컴퓨터일 경우 캐릭터 조작시 빠르게 움직일 수 있다.
    }

    // Update is called once per frame
    void Update()
    {
        FontComeUp();

        Invoke("SubTitle", 2.0f);


    }

    void FontComeUp()
    {
        this.title_txt.gameObject.SetActive(true);
        if (this.title_txt.fontSize <= 200)
        {
            this.title_txt.GetComponent<Text>().fontSize += 6;

        }
    }

    void SubTitle()
    {
        if (200 < this.title_txt.fontSize)
        {
            this.sub_title_txt.gameObject.SetActive(true);
            Invoke("FadeOut", 4.0f);
        }

    }

    void FadeOut()
    {
        this.fadein_img.fillAmount += 0.005f;
        if (this.fadein_img.fillAmount == 1.0f)
        {
            SceneManager.LoadScene("2.LobbyScene");
        }
    }
}
