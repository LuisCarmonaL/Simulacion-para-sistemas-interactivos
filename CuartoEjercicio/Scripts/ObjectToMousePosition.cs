using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToMousePosition : MonoBehaviour
{
    private void Update()
    {
        transform.position = GetWorldMousePosition();
    }
    private Vector3 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
}
