using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XWing_UI : MonoBehaviour
{
    [Header("Player Info")]
    public Image HP_IMG;    //Temp

    [Header("RSkill UI")]
    public Camera cam;
    public Image skill3BG;
    public float skill3Alpha;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        skill3Alpha = 0.0f;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
