using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Ctrl : MonoBehaviour
{
    public float damage;

    private void Start()
    {
        damage = 10f;
    }

    //private void Update()
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Back_Ground") ||
            other.gameObject.layer == LayerMask.NameToLayer("Back_Wall") ||
            other.gameObject.layer == LayerMask.NameToLayer("Back_OBJ"))
        {
            Destroy(this.gameObject);
            Debug.Log("Ground_Hit");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") ||
            other.gameObject.layer == LayerMask.NameToLayer("Explode_OBJ"))
        {
            if (other.gameObject.TryGetComponent(out Enemy_State_Ctrl esc))
            {
                esc.Hit(damage);
            }
            //else if(other.gameObject.TryGetComponent(out Explode_OBJ_Ctrl eoc))
            //{
            //    eoc.Hit(damage);
            //}

            Destroy(this.gameObject);
            Debug.Log("Enemy_Hit");
        }
    }
}