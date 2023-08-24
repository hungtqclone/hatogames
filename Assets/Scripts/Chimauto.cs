using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimauto : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnPoint;
    public float moveSpeed = 5.0f;
    public float despawnXPosition = 10.0f; // Vị trí biến mất

    private void Start()
    {
        StartCoroutine(SpawnObjectWithDelay());
    }

    private IEnumerator SpawnObjectWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(15.0f); // Đợi 5 giây trước khi tạo vật thể

            GameObject newObject = Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);
            SpriteRenderer spriteRenderer = newObject.GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true; // Đảo ngược hướng theo trục X

            StartCoroutine(MoveAndDespawnObject(newObject));
        }
    }

    private IEnumerator MoveAndDespawnObject(GameObject obj)
    {
        while (obj.transform.position.x < despawnXPosition)
        {
            obj.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(obj);
    }
    }
