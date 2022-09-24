using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWing_Att : MonoBehaviour
{
    public Transform[] ShotPos;
    int attNum = 0;

    public Transform TorphidoShotPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void OneShotFunc()
    {
        if (attNum >= 4)
        {
            attNum = 0;
        }

        Debug.Log(ShotPos[attNum]);

        Instantiate(Resources.Load("X-Wing/XWing_Laser"), ShotPos[attNum].position, Quaternion.identity);
        //饭捞历 积己 备埃

        //饭捞历 积己 备埃

        attNum++;
    }

    public void SpotShotFunc()
    {
        Debug.Log("2Spot");
    }

    public void DrillShotFunc()
    {
        Debug.Log("Drill");
    }
}
