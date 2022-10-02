using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionScene_mgr : MonoBehaviour
{
    public Button back_btn;
    public Image back_btn_click_img;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; //���� ������ �ӵ� 60���������� ���� ��Ű��.. �ڵ�

        QualitySettings.vSyncCount = 0; //����� �ֻ���(�÷�����)�� �ٸ� ��ǻ���� ��� ĳ���� ���۽� ������ ������ �� �ִ�.

        if (back_btn != null)
            back_btn.onClick.AddListener(BackBtnFunc);
    }

    //Update is called once per frame
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
}
