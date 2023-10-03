using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chim2 : MonoBehaviour
{
    public float speed = 2.0f;
    public float moveDistance = 10.0f;
    public float resetTime = 10.0f;

    private Vector3 startPosition;
    private bool isMovingForward = true;
    private bool isFacingRight = true;

    private void Start()
    {
        startPosition = transform.position;
        StartCoroutine(MoveCharacter());
    }

    private IEnumerator MoveCharacter()
    {
        while (true)
        {
            if (isMovingForward)
            {
                // Di chuyển nhân vật từ trái qua phải
                transform.Translate(Vector3.right * speed * Time.deltaTime);

                if (transform.position.x >= startPosition.x + moveDistance)
                {
                    // Đã di chuyển đủ khoảng, chuyển hướng
                    isMovingForward = false;
                    FlipCharacter();
                    yield return new WaitForSeconds(resetTime);
                }
            }
            else
            {
                // Di chuyển nhân vật ngược lại vị trí ban đầu
                transform.Translate(Vector3.left * speed * Time.deltaTime);

                if (transform.position.x <= startPosition.x)
                {
                    // Về vị trí ban đầu, chuyển hướng lại
                    isMovingForward = true;
                    FlipCharacter();
                    yield return new WaitForSeconds(resetTime);
                }
            }

            yield return null;
        }
    }

    private void FlipCharacter()
    {
        // Đảo ngược hướng của nhân vật bằng cách đổi hướng scale theo trục X
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;

        // Cập nhật biến isFacingRight
        isFacingRight = !isFacingRight;
    }
}
