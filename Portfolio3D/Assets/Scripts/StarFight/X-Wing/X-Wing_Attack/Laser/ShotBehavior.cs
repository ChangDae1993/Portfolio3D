using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{
    GameObject player;

    public enum LaserType
    {
        laser,
        torphido,
        grenade,
    }

    public LaserType laserType;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (laserType)
        {
            case LaserType.laser:
                transform.Translate(Vector3.forward * 5.0f);
                Destroy(this.gameObject, 5.0f);
                break;
            case LaserType.torphido:
                transform.Translate(Vector3.forward * 1.0f);
                Destroy(this.gameObject, 5.0f);
                break;
            default:
                break;
        }

    }
}
