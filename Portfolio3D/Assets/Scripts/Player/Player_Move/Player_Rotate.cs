using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Rotate : MonoBehaviour
{
    public float rot_speed = 200.0f;

    private float rv;
    private float rh;

    private float mx;
    private float my;

    private Camera cam;

    private void Start() => StartFunc();

    private void StartFunc()
    {
        cam = Camera.main;
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        rh = Input.GetAxis("Mouse X");
        rv = Input.GetAxis("Mouse Y");

        //Vector3 dir = new Vector3(-rv, rh, 0);

        //transform.eulerAngles = dir * rot_speed * Time.deltaTime;

        mx += rh * rot_speed * Time.deltaTime;
        my += rv * rot_speed * Time.deltaTime;

        if(my >= 90)
        {
            my = 90;
        }

        if(my <= -90)
        {
            my = -90;
        }

        transform.eulerAngles = new Vector3(-my, mx, 0);

    }
}