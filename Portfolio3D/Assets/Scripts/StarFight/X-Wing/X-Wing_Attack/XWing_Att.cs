using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWing_Att : MonoBehaviour
{
    public Transform[] ShotPos;
    int attNum = 0;
    public Transform TorphidoShotPos;

    public GameObject Laser;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    #region �ܹ�
    public void OneShotFunc()
    {
        if (attNum >= 4)
        {
            attNum = 0;
        }

        Debug.Log(ShotPos[attNum]);

        //������ ���� ����
        Instantiate(Laser, ShotPos[attNum].position, ShotPos[attNum].rotation);
        //������ ���� ����

        attNum++;
    }
    #endregion

    #region 3����
    public void SpotShotFunc()
    {
        Debug.Log("2Spot");
    }
    #endregion

    #region ����
    public void DrillShotFunc()
    {
        Debug.Log("Drill");
    }
    #endregion
}
