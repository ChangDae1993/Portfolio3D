using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCtrl : MonoBehaviour
{
    float m_MoveVelocity = 3.0f;    //��� �ʴ� �̵� �ӵ�

    //---Ű���� �Է� �̵� ���� ���� ����
    float h = 0, v = 0;
    Vector3 MoveNextStep;   //������ ����� �ֱ� ���� ����
    Vector3 MoveHStep;
    Vector3 MoveVStep;

    float a_CalcRotY = 0.0f;
    float rotSpeed = 150.0f;    //�ʴ� 150�� ȸ���϶�� �ӵ�
    //---Ű���� �Է� �̵� ���� ���� ����

    Animator animator;

    private void Awake()
    {
        CameraCtrl a_CamCtrl = Camera.main.GetComponent<CameraCtrl>();
        if (a_CamCtrl != null)
            a_CamCtrl.InitCamera(this.gameObject);

        animator = GetComponent<Animator>();
    }

    private void Start() => StartFunc();

    private void StartFunc()
    {
         
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        KeyBDMove();
    }

    void KeyBDMove()    //Ű���� �̵�
    {
        //---������ ���� �̵� ó�� �ϴ� ���
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        //---������ ���� �̵� ó�� �ϴ� ���


        Debug.Log(v);

        if (0.0f < h || 0.0f < v)
        {
            animator.SetBool("IsMove", true);
            //---�Ϲ����� �̵� ����
            a_CalcRotY = transform.eulerAngles.y;
            a_CalcRotY = a_CalcRotY + (h * rotSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0.0f, a_CalcRotY, 0.0f);

            MoveVStep = transform.forward * v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
            //---�Ϲ����� �̵� ����
        }
        else
        {
            animator.SetBool("IsMove", false);
        }

        if (v < 0.0f)
        {
            animator.SetBool("IsBMove", true);
            //---�Ϲ����� �̵� ����
            a_CalcRotY = transform.eulerAngles.y;
            a_CalcRotY = a_CalcRotY + (h * rotSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0.0f, a_CalcRotY, 0.0f);

            MoveVStep = transform.forward * v;
            MoveNextStep = MoveVStep.normalized * m_MoveVelocity * Time.deltaTime;
            transform.position = transform.position + MoveNextStep;
            //---�Ϲ����� �̵� ����
        }
        else
        {
            animator.SetBool("IsBMove", false);
        }
    }
}