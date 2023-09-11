using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public enum EnemyState
    {
        idle,
        patrol,
        detect,
        chase,
        attack,
        retreat,
        die,
        repair,
        alert,
    }

    public bool idletTest = false;
    public bool detectOn;

    public EnemyState e_state = EnemyState.idle;

    public float detectAreaRadius;

    public GameObject targetPlayer;


    private Coroutine currentCoroutine;


    private void Awake()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }


    // Start is called before the first frame update
    void Start()
    {
        detectOn = false;
        //StartCoroutine(EnemyStateChangePattern());
        EnemyStateChangePattern();
    }


    public void EnemyStateChangePattern()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        switch (e_state)
        {
            case EnemyState.idle:
                StartCoroutine(EnemyIdle());
                break;
            case EnemyState.patrol:
                StartCoroutine(EnemyPatrol());
                break;
            case EnemyState.detect:
                StartCoroutine(EnemyDetect());
                break;
            default:
                break;

        }
        //yield return null;
    }

    IEnumerator EnemyIdle()
    {
        while (e_state == EnemyState.idle)
        {
            if (idletTest)
            {
                e_state = EnemyState.patrol;
            }
            else if (detectOn)
            {
                e_state = EnemyState.detect;
            }
            //Debug.Log("Idle");
            yield return null;
        }
        //yield return null;
        EnemyStateChangePattern();
    }

    IEnumerator EnemyPatrol()
    {
        while (e_state == EnemyState.patrol)
        {
            if (!idletTest)
            {
                e_state = EnemyState.idle;
            }
            else if (detectOn)
            {
                e_state = EnemyState.detect;
            }
            //Debug.Log("Patroling");
            yield return null;
        }
        //yield return null;
        EnemyStateChangePattern();
    }

    IEnumerator EnemyDetect()
    {
        while (e_state == EnemyState.detect)
        {
            //Debug.Log("Detect On");
            if (!detectOn)
            {
                e_state = EnemyState.patrol;
            }
            //DetectArea(this.transform.position, detectAreaRadius);
            yield return null;
        }
        EnemyStateChangePattern();
    }

    public void E_Hit(float damage)
    {
        Debug.Log("hit" + damage);
    }

    //Update is called once per frame
    void Update()
    {
        DetectArea();
        //DetectArea(this.transform.position, detectAreaRadius);
    }

    #region Player Detect 1st try

    //[SerializeField] private Collider[] detectCol;
    //public Color gizmoColor;

    //public void DetectArea(Vector3 detect, float radius)
    //{
    //    detectCol = Physics.OverlapSphere(detect, radius);

    //    foreach (var detectcols in detectCol)
    //    {
    //        if (detectcols.gameObject.CompareTag("Player"))
    //        {
    //            detectOn = true;

    //            this.transform.rotation = Quaternion.LookRotation(detectcols.transform.position - this.transform.position);
    //            //Debug.Log("Detect!");
    //        }
    //        else
    //        {
    //            detectOn = false;
    //        }
    //    }
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = gizmoColor;
    //    Gizmos.DrawSphere(this.transform.position, detectAreaRadius);
    //}
    #endregion

    #region Player Detect 2nd try

    public float detectDist;
    public void DetectArea()
    {
        detectDist = Vector2.Distance(this.transform.position, targetPlayer.transform.position);

        if (detectDist > detectAreaRadius)
        {
            //this.transform.rotation = Quaternion.identity;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.identity, 1f * Time.deltaTime);
            detectOn = false;
        }
        else
        {
            //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetPlayer.transform.rotation, 1f * Time.deltaTime);
            //this.transform.rotation = Quaternion.Lerp(targetPlayer.transform.rotation,
            //    Quaternion.LookRotation(targetPlayer.transform.position - this.transform.position),
            //    2f * Time.deltaTime);
            this.transform.rotation = Quaternion.LookRotation(targetPlayer.transform.position - this.transform.position);
            detectOn = true;
        }
    }
    #endregion
}
