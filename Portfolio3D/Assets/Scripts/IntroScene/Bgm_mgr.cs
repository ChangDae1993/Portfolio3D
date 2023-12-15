using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm_mgr : MonoBehaviour
{
    private void Awake()
    {
        //var obj = FindObjectsOfType<Bgm_mgr>();
        //if (obj.Length == 1) 
        //{ 
        //    DontDestroyOnLoad(gameObject); 
        //} 
        //else 
        //{ 
        //    Destroy(gameObject); 
        //} 

    }


    private void Start()
    {

        AkSoundEngine.PostEvent("BGM_Intro", this.gameObject);
    }
}
