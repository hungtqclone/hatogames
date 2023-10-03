using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBounds : MonoBehaviour
{
    public Transform leftLimit;  // Thêm đối tượng đại diện giới hạn bên trái
    public Transform rightLimit; // Thêm đối tượng đại diện giới hạn bên phải

    private CinemachineVirtualCamera virtualCamera;
    private Transform cameraTransform;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cameraTransform = virtualCamera.transform;
    }

    private void LateUpdate()
    {
        if (leftLimit != null && rightLimit != null)
        {
            // Lấy tọa độ x của camera và giới hạn bên trái/bên phải
            float cameraX = cameraTransform.position.x;
            float leftX = leftLimit.position.x;
            float rightX = rightLimit.position.x;

            // Đảm bảo camera không vượt quá giới hạn
            float clampedX = Mathf.Clamp(cameraX, leftX, rightX);
            Vector3 newCameraPosition = new Vector3(clampedX, cameraTransform.position.y, cameraTransform.position.z);
            cameraTransform.position = newCameraPosition;
        }
    }
}
