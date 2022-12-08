using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private CameraFallow mainCamera;
    [SerializeField] private Transform followTransform;
    [SerializeField] private bool cameraPositionWithMouse;
    private GameObject button;

    [SerializeField] private Texture2D cursorTexture;

    private Vector2 cursorHotSpot;

    private Vector3 mouseWorldPosition;

    private void Start()
    {
        cursorHotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera.Setup(GetCameraPosition);
    }
    
    private void Update()
    {
        mouseWorldPosition = mainCamera.myCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;
    }

    private Vector3 GetCameraPosition() {
        if (cameraPositionWithMouse) {   
            Vector3 playerToMouseDirection = mouseWorldPosition - followTransform.position;
            return followTransform.position + playerToMouseDirection * 0.2f;
        } else {
            return followTransform.position;
        }
    }
}
