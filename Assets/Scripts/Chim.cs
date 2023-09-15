using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chim : MonoBehaviour
{
    public float speed = 2.0f;
    public float resetPosition = -10.0f;
    public float resetTime = 10.0f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        StartCoroutine(FlyBird());
    }

    private IEnumerator FlyBird()
    {
        while (true)
        {
            transform.position = startPosition;

            // Di chuyển chú chim từ trái qua phải
            while (transform.position.x < resetPosition)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                yield return null;
            }

            // Chờ 10 giây trước khi di chuyển lại
            yield return new WaitForSeconds(resetTime);
        }
    }
}
