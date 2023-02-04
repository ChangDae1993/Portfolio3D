using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Mgr : MonoBehaviour
{
    // fadeOut UI
    public Image fadeOutImg;
    Coroutine fadeOut;
    [SerializeField] private float fadeOutAlpha;

    // 튜토리얼 대화시 일시정지 하기 위한 항목들
    public bool isInstructionOn;
    [SerializeField] private XWing_Input x_Input;
    [SerializeField] private XWing_Move x_Move;
    [SerializeField] private XWing_Rotate x_Rotate;


    private void Awake()
    {
        x_Input = FindObjectOfType<XWing_Input>();
        x_Move = FindObjectOfType<XWing_Move>();
        x_Rotate = FindObjectOfType<XWing_Rotate>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isInstructionOn = true;

        fadeOutAlpha = 1f;

        if (fadeOutImg != null)
        {
            fadeOut = StartCoroutine(blackPanelFadeOutCo());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //튜토리얼 On/Off를 확인하기위한 임시 키값
        if(Input.GetKeyDown(KeyCode.H))
        {
            isInstructionOn = !isInstructionOn;
        }


        //x-wingInput및 일시정지 할 것들 (지속적으로 추가필요)
        if(isInstructionOn)
        {
            x_Input.enabled = false;
            x_Move.enabled = false;
            x_Rotate.enabled = false;
        }
        else
        {
            x_Input.enabled = true;
            x_Move.enabled = true;
            x_Rotate.enabled = true;
        }
    }

    IEnumerator blackPanelFadeOutCo()
    {
        while(fadeOutAlpha >= 0f)
        {
            fadeOutAlpha -= 0.05f;
            fadeOutImg.color = new Color(0f, 0f, 0f, fadeOutAlpha);
            yield return new WaitForSeconds(0.11f);
            //Debug.Log(fadeOutAlpha);
        }
    }
}
