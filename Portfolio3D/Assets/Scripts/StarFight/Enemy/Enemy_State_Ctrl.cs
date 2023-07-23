using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_State_Ctrl : MonoBehaviour
{

    public float detectAreaRadius;

    [SerializeField] private Collider[] detectCol;
    public bool detectOn;
    public Color gizmoColor;

    // Start is called before the first frame update
    void Start()
    {
        detectOn = false;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void E_Hit(float damage)
    {
        Debug.Log("hit" + damage);
    }

    //Update is called once per frame
    void Update()
    {
        DetectArea(this.transform.position, detectAreaRadius);

    }

    #region Player Detect
    public void DetectArea(Vector3 detect, float radius)
    {
        detectCol = Physics.OverlapSphere(detect, radius);

        foreach (var detectcols in detectCol)
        {
            if (detectcols.gameObject.CompareTag("Player"))
            {
                detectOn = true;

                this.transform.rotation = Quaternion.LookRotation(detectcols.transform.position - this.transform.position);
                //Debug.Log("Detect!");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(this.transform.position, detectAreaRadius);
    }
    #endregion
}
