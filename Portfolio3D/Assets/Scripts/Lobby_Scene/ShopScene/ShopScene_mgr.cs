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
        Application.targetFrameRate = 60; //���� ������ �ӵ� 60���������� ���� ��Ű��.. �ڵ�

        QualitySettings.vSyncCount = 0; //����� �ֻ���(�÷�����)�� �ٸ� ��ǻ���� ��� ĳ���� ���۽� ������ ������ �� �ִ�.

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
