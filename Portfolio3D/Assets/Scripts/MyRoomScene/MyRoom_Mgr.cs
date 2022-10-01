using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyRoom_Mgr : MonoBehaviour
{
    public Button back_btn;
    public Image back_btn_click_img;

    // Start is called before the first frame update
    void Start()
    {
        if (back_btn != null)
            back_btn.onClick.AddListener(BackBtnFunc);

        this.back_btn_click_img.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(back_btn_click_img.fillAmount == 1.0f)
        {
            SceneManager.LoadScene("2.LobbyScene");
        }
    }

    void BackBtnFunc()
    {
        this.back_btn_click_img.gameObject.SetActive(true);

    }
}
