using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class XWing_Rotate : MonoBehaviour
{
    public float rot_speed = 100.0f;

    public float rv;
    public float rh;

    private float mx;
    [SerializeField] private float rmx;
    private float my;

    [SerializeField] private Camera cam;
    public float rotateSpeed;
    public float rotateResetSpeed;
    //[SerializeField] private Vector3 camRightTurnPos;
    //[SerializeField] private Vector3 camLeftTurnPos;
    [SerializeField] private Vector3 camReturnPos = Vector3.zero;
    //public bool left;
    //public bool right;
    //public bool stop;

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

        rmx = Input.GetAxisRaw("Mouse X");

        //camRightTurnPos = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, -5f);
        //camRightTurnPos = new Vector3(0f, 0f, -5f);
        //camLeftTurnPos = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, 5f);
        //camLeftTurnPos = new Vector3(0f, 0f, 5f);

        CamTurn(rmx);

        //Debug.Log(rh);

        //Vector3 dir = new Vector3(-rv, rh, 0);

        //transform.eulerAngles = dir * rot_speed * Time.deltaTime;

        mx += rh * rot_speed * Time.deltaTime;
        my += rv * rot_speed * Time.deltaTime;

        //Debug.Log(mx);
        //if (rmx > 0.8f)
        //{
        //    right = true;
        //    stop = false;
        //    left = false;
        //}
        //else if (rmx == 0)
        //{
        //    stop = true;
        //    right = false;
        //    left = false;
        //}
        //else if (rmx < 0.8f)
        //{
        //    left = true;
        //    right = false;
        //    stop = false;
        //}

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

    public void CamTurn(float xx)
    {
        if (xx > 0f)
        {
            //cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, -rotateSpeed * Time.fixedDeltaTime);
            //cam.transform.eulerAngles = Vector3.Lerp(cam.transform.eulerAngles, camRightTurnPos, rotateSpeed * Time.deltaTime);
            //cam.transform.Rotate(Vector3.Lerp(cam.transform.eulerAngles, camRightTurnPos, rotateSpeed * Time.deltaTime));
            cam.transform.Rotate(new Vector3(0f, 0f, -5f) * (rotateSpeed * Time.deltaTime));
            //Debug.Log("오른쪽 회전");
        }

        if (xx < -0f)
        {
            //cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, rotateSpeed * Time.fixedDeltaTime);
            //cam.transform.eulerAngles = Vector3.Lerp(cam.transform.eulerAngles, camLeftTurnPos, rotateSpeed * Time.deltaTime);
            //cam.transform.Rotate(Vector3.Lerp(cam.transform.eulerAngles, camLeftTurnPos, rotateSpeed * Time.deltaTime));
            cam.transform.Rotate(new Vector3(0f, 0f, 5f) * (rotateSpeed * Time.deltaTime));
            //Debug.Log("왼쪽 회전");
        }

        if (xx == 0f)
        {
            //cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, 0f * Time.fixedDeltaTime);
            //cam.transform.eulerAngles = Vector3.Lerp(cam.transform.eulerAngles, camReturnPos, rotateSpeed * Time.deltaTime);
            //cam.transform.Rotate(Vector3.Lerp(cam.transform.eulerAngles, camReturnPos, rotateSpeed * Time.deltaTime));
            //cam.transform.Rotate(new Vector3(0f, 0f, 0f) * (rotateSpeed * Time.deltaTime));
            cam.transform.localRotation = Quaternion.Lerp(cam.transform.localRotation, Quaternion.Euler(0f, 0f, 0f), rotateResetSpeed * Time.deltaTime);
            //Debug.Log("원 위치");
        }
    }
}