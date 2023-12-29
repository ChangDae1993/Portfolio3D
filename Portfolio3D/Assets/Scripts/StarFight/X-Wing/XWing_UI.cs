using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class XWing_UI : MonoBehaviour
{
    [SerializeField] private XWing_State_Ctrl xState;

    [Header("Player Info")]
    public Image P_HPImg;
    public Image P_HPBGImg;

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


    [SerializeField] private float blinkTimer = 0.5f;
    public bool blinkShow = false;
    [SerializeField] private bool blink = false;

    public IEnumerator HPUIBlink()
    {
        while (blinkTimer > 0f)
        {
            blinkShow = true;
            blinkTimer -= Time.deltaTime;

            Debug.Log("Repair no need");
            Debug.Log("Hp UI blink effect add here");
            yield return null;
        }

        P_HPBGImg.color = Color.white;
        blinkShow = false;
        blinkTimer = 1.0f;
    }
}
