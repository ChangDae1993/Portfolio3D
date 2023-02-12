using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWing_Move : MonoBehaviour
{
    XWing_State_Ctrl x_State;
    XWing_Input X_Input;
    XWing_Rotate X_Rotate;

    float moveVelocity = 30.0f;    //평면 초당 이동 속도
    float idleVelocity = 3.0f;

    //float runSpeed = 20.0f;

    Vector3 MoveNextStep;   //보폭을 계산해 주기 위한 변수
    Vector3 MoveHStep;
    Vector3 MoveVStep;

    [SerializeField] private Transform X_Body;

    [SerializeField] private bool isRight;
    [SerializeField] private bool isLeft;

    [SerializeField] private bool isUp;
    [SerializeField] private bool isDown;

    //회전시 위치 관련 변수
    Vector3 originPos;
    Vector3 rightTurnPos;
    Vector3 leftTurnPos;

    //Coroutine Cache
    Coroutine rightTurn;
    Coroutine leftTurn;
    Coroutine resetTurn;

    void Start()
    {
        x_State = GetComponent<XWing_State_Ctrl>();
        X_Input = GetComponent<XWing_Input>();
        X_Rotate = GetComponent<XWing_Rotate>();
        X_Body = transform.GetChild(0).transform;

        originPos = new Vector3(0.0f, -4.5f, 10.5f);
        rightTurnPos = new Vector3(-7.0f, -4.5f, 10.5f);
        leftTurnPos = new Vector3(7.0f, -4.5f, 10.5f);
    }

    void Update()
    {

        if(X_Input.v > 0.0f)
        {
            x_State.X_State = XWingState.Fly;

            MoveVStep = transform.forward * X_Input.v;
            MoveNextStep = MoveVStep.normalized * moveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
        }
        else
        {
            MoveVStep = transform.forward;
            MoveNextStep = MoveVStep.normalized * idleVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
        }




        #region 상하 회전

        //if (X_Rotate.rv > 0.5f)
        //{
        //    isUp = true;
        //    isDown = false;
        //}
        //else if (X_Rotate.rv < -0.5f)
        //{
        //    isUp = false;
        //    isDown = true;
        //}
        //else if (X_Rotate.rv == 0.0f)
        //{
        //    isUp = false;
        //    isDown = false;
        //}

        //if (isUp)
        //{
        //    X_Body.localRotation = Quaternion.Euler(0.0f, 0, 0.0f);
        //}

        //if (isDown)
        //{
        //    X_Body.localRotation = Quaternion.Euler(20.0f, 0, 0.0f);
        //}

        //if (!isUp && !isDown)
        //{
        //    X_Body.localRotation = Quaternion.Euler(10.0f, 0, 0.0f);
        //}
        #endregion


        //X_Body.localPosition = new Vector3(X_Rotate.rh * -7.0f, -4.5f, 10.5f);
        //X_Body.localRotation = Quaternion.Euler(X_Rotate.rv * 10.0f, 0.0f, -X_Rotate.rh * 30.0f);
    }

    private void FixedUpdate()
    {
        #region 좌우 이동
        if (X_Rotate.rh > 0.8f)
        {
            isRight = true;
            isLeft = false;
        }
        else if (X_Rotate.rh < -0.8f)
        {
            isRight = false;
            isLeft = true;
        }
        else if (X_Rotate.rh == 0.0f)
        {
            isRight = false;
            isLeft = false;
        }

        if (isRight)
        {
            X_Body.localRotation = Quaternion.Euler(10.0f, 0, -30.0f);
            rightTurn = StartCoroutine(RightTurnCo());
        }


        if (isLeft)
        {
            X_Body.localRotation = Quaternion.Euler(10.0f, 0, 30.0f);
            leftTurn = StartCoroutine(LeftTurnCo());
        }

        #endregion

        #region 제자리 돌아오기
        if (!isRight && !isLeft)
        {
            X_Body.localRotation = Quaternion.Euler(10.0f, 0, 0);
            resetTurn = StartCoroutine(returnCo());
        }

        #endregion
    }

    IEnumerator RightTurnCo()
    {
        while (isRight)
        {
            X_Body.localPosition = Vector3.Lerp(X_Body.localPosition, rightTurnPos, Time.fixedDeltaTime * 0.5f);
            //Debug.Log(X_Body.localPosition.x);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator LeftTurnCo()
    {
        while (isLeft)
        {
            X_Body.localPosition = Vector3.Lerp(X_Body.localPosition, leftTurnPos, Time.fixedDeltaTime * 0.5f);
            //Debug.Log(X_Body.localPosition.x);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator returnCo()
    {
        X_Body.localPosition = Vector3.Lerp(X_Body.localPosition, originPos, Time.fixedDeltaTime * 5.0f);
        yield return new WaitForSeconds(0.5f);
    }
}