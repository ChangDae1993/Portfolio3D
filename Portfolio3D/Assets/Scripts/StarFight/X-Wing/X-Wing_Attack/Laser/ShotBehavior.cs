using UnityEngine;

public class ShotBehavior : MonoBehaviour
{
    GameObject player;

    public float shotSpeed;

    public enum LaserType
    {
        laser,
        torphido,
        grenade,
    }

    public LaserType laserType;

    public float q_fireDelayTimer;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        q_fireDelayTimer = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (laserType)
        {
            case LaserType.laser:
                transform.Translate(Vector3.forward * shotSpeed);
                Destroy(this.gameObject, 5.0f);
                break;
            case LaserType.torphido:
                q_fireDelayTimer -= Time.deltaTime;
                if (q_fireDelayTimer > 0f)
                {
                    shotSpeed = 0f;
                    this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 3.0f, player.transform.position.z);
                }
                else
                {
                    shotSpeed = 1f;
                    transform.Translate(Vector3.forward * shotSpeed);
                }
                Destroy(this.gameObject, 20.0f);
                break;
            case LaserType.grenade:
                break;
            default:
                break;
        }

    }
}
