using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private GameObject m_Player = null;
    private Vector3 m_TargetPos = Vector3.zero;

    //---ī�޶� ��ġ ���� ����
    private float m_RotH = 0.0f;        //���콺 �¿� ���۰� ���� ����
    private float m_RotV = 0.0f;        //���콺 ���� ���۰� ���� ����
    private float hSpeed = 5.0f;        //���콺 �¿� ȸ���� ���� ī�޶� ȸ�� ���ǵ�
    private float vSpeed = 2.4f;        //���콺 ���� ȸ���� ���� ī�޶� ȸ�� ���ǵ�
    private float vMinLimit = -7.0f;    //�� �Ʒ� ���� ����
    private float vMaxLimit = 80.0f;    //�� �Ʒ� ���� ����
    private float zoomSpeed = 1.0f;     //���콺 �� ���ۿ� ���� ���ξƿ� ���ǵ� ����
    private float maxDist = 50.0f;      //���콺 �� �ƿ� �ִ� �Ÿ� ���� ��
    private float minDist = 3.0f;       //���콺 ���� �ּ� �Ÿ� ���Ѱ�
    //---ī�޶� ��ġ ���� ����

    //---���ΰ��� �������� �� ������� �� ��ǥ�� ������ �ʱⰪ
    private float m_DefaltRotH = 0.0f;  //��� ������ ȸ�� ����
    private float m_DefaltRotV = 25.0f; //27.0f;    //���� ������ ȸ�� ����
    private float m_DefaltDist = 5.2f;  //Ÿ�ٿ��� ī�޶������ �Ÿ�
    //---���ΰ��� �������� �� ������� �� ��ǥ�� ������ �ʱⰪ

    //---��꿡 �ʿ��� ������
    private Quaternion a_BuffRot;
    private Vector3 a_BasicPos = Vector3.zero;
    private float distance = 17.0f;
    private Vector3 a_BuffPos;
    //---��꿡 �ʿ��� ������

    public void InitCamera(GameObject a_Player)
    {
        m_Player = a_Player;
    }

    private void Start() => StartFunc();

    private void StartFunc()
    {
        if (m_Player == null)
            return;

        m_TargetPos = m_Player.transform.position;
        m_TargetPos.y = m_TargetPos.y + 1.4f;

        //---ī�޶� ��ġ ��� ����(�� ��ǥ�踦 ���� ��ǥ��� ȯ���ϴ� �κ�)
        m_RotH = m_DefaltRotH;  //��� ������ ȸ�� ����
        m_RotV = m_DefaltRotV;  //���� ������ ȸ�� ����
        distance = m_DefaltDist;

        a_BuffRot = Quaternion.Euler(m_RotV, m_RotH, 0);
        a_BasicPos.x = 0.0f;
        a_BasicPos.y = 0.0f;
        a_BasicPos.z = -distance;

        a_BuffPos = (a_BuffRot * a_BasicPos) + m_TargetPos;

        transform.position = a_BuffPos; //<-ī�޶� ������ǥ�� ������ ��ġ

        transform.LookAt(m_TargetPos);
        //---ī�޶� ��ġ ��� ����
    }

    //private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        
    }

    private void LateUpdate()
    {
        if (m_Player == null)
            return;

        m_TargetPos = m_Player.transform.position;
        m_TargetPos.y = m_TargetPos.y + 1.4f;

        if(Input.GetMouseButton(1))
        {
            //���콺�� �¿�� �������� �� ��
            m_RotH += Input.GetAxis("Mouse X") * hSpeed;
            //���콺�� ���Ʒ��� �������� �� ��
            m_RotV -= Input.GetAxis("Mouse Y") * vSpeed;

            m_RotV = ClampAngle(m_RotV, vMinLimit, vMaxLimit);
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0 && distance < maxDist)
        {
            distance += zoomSpeed;
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0 && distance > minDist)
        {
            distance -= zoomSpeed;
        }

        a_BuffRot = Quaternion.Euler(m_RotV, m_RotH, 0);
        a_BasicPos.x = 0.0f;
        a_BasicPos.y = 0.0f;
        a_BasicPos.z = -distance;

        a_BuffPos = a_BuffRot * a_BasicPos + m_TargetPos;

        transform.position = a_BuffPos;
        //ī�޶��� ������ǥ�� ������ ��ġ

        transform.LookAt(m_TargetPos);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}