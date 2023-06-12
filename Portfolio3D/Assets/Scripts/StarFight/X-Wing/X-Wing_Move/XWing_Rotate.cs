using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class XWing_Rotate : MonoBehaviour
{
    public float rot_speed = 100.0f;

    public float rv;
    public float rh;

    private float mx;
    private float my;

    private Camera cam;

    //Todo : player 좌표 값 받아두기
    //회전 값을 본인의 각도의 차이만큼 구하는게 훨씬 안정적!
    //각도를 직접 회전이 아닌, 

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        rh = Input.GetAxis("Mouse X");
        rv = Input.GetAxis("Mouse Y");

        //Debug.Log(rh);

        //Vector3 dir = new Vector3(-rv, rh, 0);

        //transform.eulerAngles = dir * rot_speed * Time.deltaTime;

        mx += rh * rot_speed * Time.deltaTime;
        my += rv * rot_speed * Time.deltaTime;

        if (my >= 40)
        {
            my = 40;
        }

        if (my <= -40)
        {
            my = -40;
        }

        transform.eulerAngles = new Vector3(-my, mx, 0);

    }
}