using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWing_Input : MonoBehaviour
{
    XWing_State_Ctrl x_State;

    public float v;
    //public float h;

    private void Start() => StartFunc();

    private void StartFunc()
    {
         x_State = GetComponent<XWing_State_Ctrl>();
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        //h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (/*h == 0 &&*/ v == 0)
        {
            x_State.X_State = XWingState.IdleFly;
        }
        else
        {
            x_State.X_State = XWingState.Fly;
        }

        if(v > 0)
        {
            Debug.Log("������");
        }
        else if(v < 0)
        {
            Debug.Log("�ڷ�");
        }
        else
        {
            Debug.Log("�յ� ����");
        }

        //if(h >0)
        //{
        //    Debug.Log("������");
        //}
        //else if( h <0)
        //{
        //    Debug.Log("����");
        //}
        //else
        //{
        //    Debug.Log("�¿� ����");
        //}
    }
}