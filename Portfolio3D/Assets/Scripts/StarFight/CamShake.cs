using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magitude)
    {
        Debug.Log("HERE");

        Vector3 originpos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magitude;
            float y = Random.Range(-1f, 1f) * magitude;
            float z = Random.Range(-1f, 1f) * magitude;

            transform.localPosition = new Vector3(x, y, z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originpos;
    }
}
