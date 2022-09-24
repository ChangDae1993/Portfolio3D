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

    #region 단발
    public void OneShotFunc()
    {
        if (attNum >= 4)
        {
            attNum = 0;
        }

        Debug.Log(ShotPos[attNum]);

        //레이저 생성 구간
        Instantiate(Laser, ShotPos[attNum].position, ShotPos[attNum].rotation);
        //레이저 생성 구간

        attNum++;
    }
    #endregion

    #region 3연발
    public void SpotShotFunc()
    {
        Debug.Log("2Spot");
    }
    #endregion

    #region 연사
    public void DrillShotFunc()
    {
        Debug.Log("Drill");
    }
    #endregion
}
