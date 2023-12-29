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
        AkSoundEngine.PostEvent("Main_Title", this.gameObject);
    }
}
