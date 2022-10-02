using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby_Mgr : MonoBehaviour
{

    public Button Play_Btn;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        if (Play_Btn != null)
            Play_Btn.onClick.AddListener(PlayBtnFunc);
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        
    }

    public void PlayBtnFunc()
    {
        SceneManager.LoadScene("StarFight_Tutorial");
    }
}