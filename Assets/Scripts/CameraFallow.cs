using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFallow : MonoBehaviour
{
    public Camera myCamera;
    public Transform target;
    public Transform targetAim;
    public float something;

    public Vector2 maxPos;
    public Vector2 minPos;
    private Vector3 targetPos;

    private Func<Vector3> GetCameraFollowPositionFunc;

    public void Setup(Func<Vector3> GetCameraFollowPositionFunc) {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }

    private void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            targetPos = new Vector3(target.position.x, target.position.y, -10f);

            transform.position = Vector3.Lerp(transform.position, targetPos, something);
        }

        HandleMovement();
    }

    private void HandleMovement() {
        if (GetCameraFollowPositionFunc == null) return;

        Vector3 targetAim = GetCameraFollowPositionFunc();
        targetAim.z = transform.position.z;
        transform.position = new Vector3(targetAim.x, targetAim.y + 1f, targetAim.z);
    }
}
