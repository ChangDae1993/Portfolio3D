using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XWing_UI : MonoBehaviour
{
    [SerializeField] private XWing_State_Ctrl xState;

    [Header("Player Info")]
    public Image P_HPImg;

    [Header("RSkill UI")]
    public Camera cam;
    public Image skill3BG;
    public float skill3Alpha;



    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        xState = GetComponent<XWing_State_Ctrl>();
        skill3Alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        P_HPImg.fillAmount = xState.P_curhp * 0.01f;
    }
}
