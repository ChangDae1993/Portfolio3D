using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScene_mgr : MonoBehaviour
{
    public Button back_btn;
    public Button beskar_btn;
    public Image back_btn_click_img;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; //실행 프레임 속도 60프레임으로 고정 시키기.. 코드

        QualitySettings.vSyncCount = 0; //모니터 주사율(플레임율)이 다른 컴퓨터일 경우 캐릭터 조작시 빠르게 움직일 수 있다.

        if (back_btn != null)
            back_btn.onClick.AddListener(BackBtnFunc);

        if (beskar_btn != null)
            beskar_btn.onClick.AddListener(BeskarBtnFunc);
    }

    // Update is called once per frame
    void Update()
    {
        if (back_btn_click_img.gameObject.GetComponent<Image>().fillAmount == 1.0f)
        {
            SceneManager.LoadScene("2.LobbyScene");
        }
    }

    void BackBtnFunc()
    {
        back_btn_click_img.gameObject.SetActive(true);
    }

    void BeskarBtnFunc()
    {
        SceneManager.LoadScene("5_1.BeskarShopScene");
    }
}
