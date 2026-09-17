using System.Collections;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;

    private void Start()
    {
        StartCoroutine(AppleDropper());
    }

    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x < -leftAndRightEdge ||
            transform.position.x > leftAndRightEdge)
        {
            speed = -speed;
        }
        else if (Random.value < changeDirChance * Time.deltaTime)
        {
            speed = -speed;
        }
    }

    private IEnumerator AppleDropper()
    {
        while (true)
        {
            if (applePrefab != null)
            {
                Instantiate(applePrefab, transform.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(appleDropDelay);
        }
    }
}