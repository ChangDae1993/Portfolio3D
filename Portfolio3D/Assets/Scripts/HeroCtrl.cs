using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroCtrl : MonoBehaviour
{


    private void Start() => StartFunc();

    private void StartFunc()
    {

    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {

        if (Input.GetMouseButton(1))
        {
            //P_State = PlayerState.Aim;

            //if (P_State == PlayerState.Aim)
            //{
            //    PlayerAimFunc();
            //}
        }
        else
        {
            Debug.Log("AimX");
        }
    }

    void PlayerAimFunc()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Aim");
        }
    }
}