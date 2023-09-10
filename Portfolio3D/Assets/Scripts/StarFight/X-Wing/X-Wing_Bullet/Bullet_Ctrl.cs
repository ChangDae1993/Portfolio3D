using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾� �� Bullet
public class Bullet_Ctrl : MonoBehaviour
{
    [SerializeField] private XWing_State_Ctrl xState;

    private void Start()
    {
        xState = FindObjectOfType<XWing_State_Ctrl>();
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
            //ȿ���� �ҷ����� || �ٸ� �ۿ� �߰�
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") ||
            other.gameObject.layer == LayerMask.NameToLayer("Explode_OBJ"))
        {
            if (other.gameObject.TryGetComponent(out Enemy_AI esc))
            {
                esc.E_Hit(xState.damage);
            }
            //else if (other.gameObject.TryGetComponent(out Explode_OBJ_Ctrl eoc))
            //{
            //    eoc.Hit(damage);
            //}

            Destroy(this.gameObject);
            Debug.Log("Enemy_Hit");
        }
    }
}