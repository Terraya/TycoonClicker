using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyAfterTime(10f));
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
