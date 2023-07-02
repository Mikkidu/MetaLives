using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + Vector3.back * 10;
        }
    }
}
