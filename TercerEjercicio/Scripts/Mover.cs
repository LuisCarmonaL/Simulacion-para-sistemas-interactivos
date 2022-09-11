using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private MyVector aceleration;
    [SerializeField] private Transform target;
    private MyVector position;
    [SerializeField] private MyVector velocity;
    private MyVector displacement;

    private int currentAcceIndex = 0;
    private MyVector[] accelerations = new MyVector[4]
    {
        new MyVector(0f,-9.8f),
        new MyVector(9.8f, 0f),
        new MyVector(0f, 9.8f),
        new MyVector(-9.8f, 0f),
    };

    void Start()
    {
        position = transform.position;
        //Time.maximumDeltaTime=(1f/60f);
    }

    // Update is called once per frame
    void Update()
    {

        position.Draw(Color.blue);
        displacement.Draw(Color.green);
        velocity.Draw(Color.yellow);
        //position.Draw(Color.red);
        Move();
        Debug.Log(Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity *= 0;
            aceleration = accelerations[(++currentAcceIndex) % accelerations.Length];
        }

        aceleration = target.position - transform.position;
    }

    public void Move()
    {
        //transform.position = position;
        velocity += aceleration * Time.deltaTime;
        displacement = velocity * (Time.deltaTime); //deltaTIME (1f/60f)
        position += displacement;

        /*if (position.x < -5 || position.x > 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x = -velocity.x;
        }
        if (position.y < -5 || position.y > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y = -velocity.y;
        }*/

        transform.position = position;
    }
}
