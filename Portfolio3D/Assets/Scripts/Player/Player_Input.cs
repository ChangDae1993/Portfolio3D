using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    Player_State_Ctrl Pl_State;

    public float v;
    public float h;

    private void Awake()
    {
        CameraCtrl a_CamCtrl = Camera.main.GetComponent<CameraCtrl>();
        if (a_CamCtrl != null)
            a_CamCtrl.InitCamera(this.gameObject);
    }

    private void Start() => StartFunc();

    private void StartFunc()
    {
        Pl_State = GetComponent<Player_State_Ctrl>();

    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {

        //---가감속 없이 이동 처리 하는 방법
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        //---가감속 없이 이동 처리 하는 방법

        if (0.0f != h || 0.0f < v)
        {
            //Debug.Log("A");
            Pl_State.P_State = PlayerState.Walk;
        }
    }
}