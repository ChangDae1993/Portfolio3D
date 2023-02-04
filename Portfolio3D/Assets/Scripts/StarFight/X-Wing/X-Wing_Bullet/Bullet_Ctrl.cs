using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Ctrl : MonoBehaviour
{
    private void Start()
    {
        
    }

    //private void Update()
    //{
        
    //}

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.layer == LayerMask.NameToLayer("Back_Ground") ||
            other.gameObject.layer == LayerMask.NameToLayer("Back_Wall")||
            other.gameObject.layer == LayerMask.NameToLayer("Back_OBJ"))
        {
            Destroy(this.gameObject);
            Debug.Log("Ground_Hit");
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(this.gameObject);
            Debug.Log("Enemy_Hit");
        }
    }
}