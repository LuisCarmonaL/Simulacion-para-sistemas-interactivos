using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverWithForce : MonoBehaviour
{
    [SerializeField] private MyVector wind;
    [SerializeField] private MyVector gravity;
    [SerializeField] private float mass = 1f;
    [Range(0, 1)] [SerializeField] private float dampingFactor = 1;
    

    private MyVector acceleration;
    private MyVector position;
    private MyVector velocity;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        position.Draw( Color.blue);

        velocity.Draw( Color.red);

    }
    private void FixedUpdate()
    {
        //update the position
         acceleration *= 0f;
         ApplyForce(wind);
         ApplyForce(gravity);
        

        Move();
    }
    public void Move()
    {
        // Displacement =velocity*Time.deltaTime;
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;

        //Check bounds
        if (position.x < -5 || position.x > 5)
        {
            velocity.x = -velocity.x;
            position.x = Mathf.Sign(position.x) * 5;
            velocity *= dampingFactor;
        }
        if (position.y < -5 || position.y > 5)
        {
            velocity.y = -velocity.y;
            position.y = Mathf.Sign(position.y) * 5;
            velocity *= dampingFactor;
        }

        transform.position = position;
    }
    void ApplyForce(MyVector force)
    {
        acceleration += force / mass;
    }
}
