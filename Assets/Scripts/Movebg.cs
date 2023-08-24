using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movebg : MonoBehaviour
{
    public Camera mainCamera;
    private Transform mainCameraTransform;
    private SpriteRenderer spriteRenderer;
    private Vector2 spriteSize;

    private void Start()
    {
        mainCameraTransform = mainCamera.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.bounds.size;
    }

    private void Update()
    {
        float cameraX = mainCameraTransform.position.x;
        float backgroundX = transform.position.x;

        float diff = cameraX - backgroundX;
        int loops = Mathf.FloorToInt(diff / spriteSize.x);
        float newPositionX = backgroundX + spriteSize.x * loops;

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
