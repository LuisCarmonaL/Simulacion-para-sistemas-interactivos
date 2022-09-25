using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarExperiments : MonoBehaviour
{
    [SerializeField] private float angleDeg;

    [SerializeField] private float radius = 1;

    private float angularSpeed = 5;
    
    // Update is called once per frame
    void Update()
    {



        PolarToCartesian(angleDeg, radius).Draw(Color.yellow);
        angleDeg = angleDeg + 0.1f;
    }

    private MyVector PolarToCartesian(float angleDeg, float rad)
    {
        float x = Mathf.Cos(angleDeg * Mathf.Deg2Rad);
        float y = Mathf.Sin(angleDeg * Mathf.Deg2Rad);
        return new MyVector(x * radius, y * radius);
    }
    
}
