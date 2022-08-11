using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyVectors : MonoBehaviour
{
    [SerializeField]
    private MyVector myFirstVector;

    [SerializeField]
    private MyVector mySecondVector;

    [SerializeField, Range(0, 1)]
    private float factor = 0;

    

    void Start()
    {
        //MyVector obj = new MyVector(5,5);
        //MyVector sumResult = myFirstVector + mySecondVector;
        //myFirstVector.Sum(mySecondVector);
        //myThirdVector.Lerp(myFirstVector, mySecondVector, 0);

        //Debug.Log(sumResult.x);
        //Debug.Log(sumResult.y);

        //Vector2 a = Vector2.left;
        //Vector2 b = Vector2.down;
        //Vector2 c = a + b;
    }


    void Update()
    {
        myFirstVector.Draw(Color.red);
        mySecondVector.Draw(Color.yellow);
        MyVector lerp = myFirstVector.Lerp(mySecondVector, factor);
        lerp.Draw(Color.green);
        //MyVector diff = myFirstVector - mySecondVector;
        MyVector diff = myFirstVector - lerp;
        diff.Draw(Color.blue, lerp);

       

    }
}

