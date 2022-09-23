using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWing_Move : MonoBehaviour
{
    XWing_State_Ctrl x_State;
    XWing_Input X_Input;
    XWing_Rotate X_Rotate;

    float moveVelocity = 30.0f;    //평면 초당 이동 속도

    float runSpeed = 20.0f;

    Vector3 MoveNextStep;   //보폭을 계산해 주기 위한 변수
    Vector3 MoveHStep;
    Vector3 MoveVStep;

    [SerializeField] private Transform X_Body;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        x_State = GetComponent<XWing_State_Ctrl>();
        X_Input = GetComponent<XWing_Input>();
        X_Rotate = GetComponent<XWing_Rotate>();
        X_Body = transform.GetChild(0).transform;
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        if(X_Input.v > 0.0f)
        {
            x_State.X_State = XWingState.Fly;

            MoveVStep = transform.forward * X_Input.v;
            MoveNextStep = MoveVStep.normalized * moveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
        }
        else if(X_Input.v < 0.0f)
        {
            x_State.X_State = XWingState.Fly; 
            MoveVStep = transform.forward * X_Input.v;
            MoveNextStep = MoveVStep.normalized * moveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
        }

        if(X_Rotate.rh > 0.0f)
        {
            X_Body.localRotation = Quaternion.Euler(0, 0, -20.0f);
        }
    }
}