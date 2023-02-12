using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby_Mgr : MonoBehaviour
{

    public Button Play_Btn;
    public Button Shop_Btn;
    public Button Setting_Btn;

    void Start()
    {
        if (Play_Btn != null)
            Play_Btn.onClick.AddListener(PlayBtnFunc);

        if (Shop_Btn != null)
            Shop_Btn.onClick.AddListener(ShopBtnFunc);

        if (Setting_Btn != null)
            Setting_Btn.onClick.AddListener(SettingBtnFunc);
    }

    //private void Update()
    //{
        
    //}

    public void PlayBtnFunc()
    {
        SceneManager.LoadScene("StarFight_Tutorial");
    }

    public void ShopBtnFunc()
    {
        //shop Scene 넘어가기
        Debug.Log("Shop Scene");
    }

    public void SettingBtnFunc()
    {
        //setting Scene 넘어가기
        Debug.Log("Setting Scene");
    }
}