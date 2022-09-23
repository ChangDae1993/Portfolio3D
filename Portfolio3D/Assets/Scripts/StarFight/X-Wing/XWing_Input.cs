using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWing_Input : MonoBehaviour
{
    XWing_State_Ctrl x_State;

    public float v;
    //public float h;

    public bool isBattle;

    Animator animator;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        x_State = GetComponent<XWing_State_Ctrl>();
        animator = GetComponentInChildren<Animator>();
        isBattle = false;
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

        if(Input.GetKeyDown(KeyCode.C))
        {
            if(isBattle)
            {
                isBattle = false;
                animator.SetBool("isBattle", false);
            }
            else
            {
                isBattle = true;
                animator.SetBool("isBattle", true);
            }

        }
    }
}