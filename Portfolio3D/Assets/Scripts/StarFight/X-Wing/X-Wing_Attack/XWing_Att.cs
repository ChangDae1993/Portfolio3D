using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWing_Att : MonoBehaviour
{
    public Transform[] ShotPos;
    int attNum = 0;

    public Transform TorphidoShotPos;

    XWing_State_Ctrl x_State;
    XWing_Input x_Input;

    // Start is called before the first frame update
    void Start()
    {
        x_State = GetComponent<XWing_State_Ctrl>();
        x_Input = GetComponent<XWing_Input>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OneShotFunc()
    {
        if (attNum >= 4)
        {
            attNum = 0;
        }

        Debug.Log(ShotPos[attNum]);
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
