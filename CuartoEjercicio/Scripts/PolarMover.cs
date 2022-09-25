using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarMover : MonoBehaviour
{
    [SerializeField] MyVector polarCoord;

    [Header("SpeedControls")]
    [SerializeField] float angularSpeed;
    [SerializeField] float radialSpeed;
    

   private void Update()
    {
        polarCoord.radius += radialSpeed * Time.deltaTime;
        polarCoord.angle += angularSpeed * Mathf.Deg2Rad * Time.deltaTime;
        transform.position = polarCoord.FromPolarToCartesian();
    }
}
