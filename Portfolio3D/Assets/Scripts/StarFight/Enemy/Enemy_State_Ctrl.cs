using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_State_Ctrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void E_Hit(float damage)
    {
        Debug.Log("hit" + damage);
    }
}
