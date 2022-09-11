using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVelocity : MonoBehaviour
{

    Vector position;
    [SerializeField] Vector displacement;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        position.Draw(Color.blue);
        displacement.Draw2(position,Color.green);
        Move();

        
    }

    public void Move()
    {
        position += displacement;

        if (Mathf.Abs(position.x) >= 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            displacement.x *= -1;

        }
        if (Mathf.Abs(position.y) >= 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            displacement.y *= -1;
        }

        transform.position = position;
    }
}
