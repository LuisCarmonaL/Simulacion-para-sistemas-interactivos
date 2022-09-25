using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLineal : MonoBehaviour
{

    private enum MovementMode
    {
        Velocity = 0,
        Aceleration
    }
    public MyVector Velocity => velocity;
    
    
    
    [SerializeField] private MovementMode movementMode;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    
    
    
    private MyVector aceleration;
    private MyVector velocity;
    private MyVector position;



    private void Start()
    {
        position = transform.position;
        
    }

    
    private void FixedUpdate()
    {
       
        position.Draw(Color.red);
        aceleration.Draw(Color.yellow);
        velocity.Draw(Color.green);

        switch (movementMode)
        {
            case MovementMode.Velocity:
                velocity = target.position - transform.position;
                velocity.Normalize();
                velocity *= speed;
                break;
            case MovementMode.Aceleration:
                aceleration = target.position - transform.position;
                break;
        }
        Move();
    }

    public void Move()
    {
        velocity = velocity + aceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;
       
        
        
        transform.position = position;
    }
}
