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
            Debug.Log("¾ÕÀ¸·Î");
        }
        else if(v < 0)
        {
            Debug.Log("µÚ·Î");
        }
        else
        {
            Debug.Log("¾ÕµÚ ¸ØÃã");
        }

        //if(h >0)
        //{
        //    Debug.Log("¿À¸¥ÂÊ");
        //}
        //else if( h <0)
        //{
        //    Debug.Log("¿ÞÂÊ");
        //}
        //else
        //{
        //    Debug.Log("ÁÂ¿ì ¸ØÃã");
        //}
    }
}