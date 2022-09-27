using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Ctrl : MonoBehaviour
{
    private void Start() => StartFunc();

    private void StartFunc()
    {
         
    }

    private void Update() => UpdateFunc();

    private void UpdateFunc()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(this.gameObject);
            Debug.Log("Hit");
        }
    }
}