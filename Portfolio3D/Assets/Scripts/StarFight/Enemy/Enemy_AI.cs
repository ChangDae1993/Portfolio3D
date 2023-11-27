using System.Collections;
using System.Collections.Generic;
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
    public float detectAlertGage = 0f;
    public float detectSpeed;


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
                currentCoroutine = StartCoroutine(EnemyIdle());
                break;
            case EnemyState.patrol:
                currentCoroutine = StartCoroutine(EnemyPatrol());
                break;
            case EnemyState.detect:
                currentCoroutine = StartCoroutine(EnemyDetect());
                break;
            case EnemyState.alert:
                currentCoroutine = StartCoroutine(EnemyAlert());
                break;
            case EnemyState.attack:
                currentCoroutine = StartCoroutine(EnemyAttack());
                break;
            default:
                break;
        }
        //yield return null;
    }

    IEnumerator EnemyIdle()
    {
        //if (idletTest)
        //{
        //    e_state = EnemyState.patrol;
        //}

        if (detectOn)
        {
            e_state = EnemyState.detect;
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            e_state = EnemyState.patrol;
        }
        //Debug.Log("Idle");
        yield return null;
        EnemyStateChangePattern();
    }

    IEnumerator EnemyPatrol()
    {
        //if (!idletTest)
        //{
        //    e_state = EnemyState.idle;
        //}
        while (e_state == EnemyState.patrol)
        {
            if (detectOn)
            {
                e_state = EnemyState.detect;
            }
            else
            {
                Debug.Log("랜덤으로 움직이기 here");
                yield return new WaitForSeconds(Random.Range(2f, 5f));
                e_state = EnemyState.idle;
            }
        }

        //Debug.Log("Patroling");

        yield return null;
        EnemyStateChangePattern();
    }

    IEnumerator EnemyDetect()
    {
        while (e_state == EnemyState.detect)
        {
            //Debug.Log("Detect On");
            if (!detectOn)
            {
                e_state = EnemyState.idle;
            }

            if (detectAlertGage >= 100f)
            {
                e_state = EnemyState.alert;
            }
            //DetectArea(this.transform.position, detectAreaRadius);
            yield return null;
        }
        EnemyStateChangePattern();
    }

    IEnumerator EnemyAlert()
    {
        while (e_state == EnemyState.alert)
        {
            if (!detectOn)
            {
                detectAlertGage = 0f;
                e_state = EnemyState.detect;
            }
            //Debug.Log("alert");


            if (detectAlertGage >= 100f)
            {
                //if 주변에 몬스터가 3마리 이상이라면
                //alert를 켠다 (alert가 어떤 방식인지는 제작 해야함)
                //else 혼자라면 바로 attack모드로

                e_state = EnemyState.attack;
            }

            yield return null;
        }

        EnemyStateChangePattern();
    }


    public float attackMoveSpeed;
    public float rotateSpeed;

    IEnumerator EnemyAttack()
    {
        while (e_state == EnemyState.attack)
        {
            Vector3 lookDIr = targetPlayer.transform.position - this.transform.position;
            this.transform.rotation =
                Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(lookDIr),
                Time.deltaTime * rotateSpeed);

            //this.transform.position =
            yield return null;

        }
    }

    public void E_Hit(float damage)
    {
        Debug.Log("hit" + damage);
    }

    //Update is called once per frame
    void Update()
    {
        if (e_state == EnemyState.detect)
        {
            //Debug.Log("!!!");
            if (detectAlertGage <= 100f)
            {
                detectAlertGage += detectSpeed;
            }
            else
                detectAlertGage = 100f;
        }
        else if (e_state == EnemyState.retreat)
        {
            if (detectAlertGage > 0f)
                detectAlertGage = 0f;
        }
        else
        {
            //Debug.Log("???");
            if (detectAlertGage >= 0f)
            {
                detectAlertGage -= detectSpeed;
            }
            else
                detectAlertGage = 0f;
        }

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
            //rotation돌아가는 기준을 identity로 잡지 않고 detect 상태에 들어가면서
            //기존의 rotation값을 저장 한 후 그뒤에 rotate 시작,
            //detectOn이 끝난 후 Quaterion.Lerp의 값을 저장한 detect 시작 전 rotation값으로 Lerp시키기
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
