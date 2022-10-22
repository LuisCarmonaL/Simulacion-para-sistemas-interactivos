using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Transform targetTransform;   
    [SerializeField, Range(0,1)] private float tParameter = 0;
    [SerializeField] private Color initialColor;
    [SerializeField] private Color finalColor;
    [SerializeField]private AnimationCurve curve;
    
    private SpriteRenderer spriteRenderer;
    private float currentTime;
    private Vector3 initialPosition;
    private Vector3 targetPosition;


    // Start is called before the first frame update
    private void Start()
    {
      spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {


        tParameter = currentTime / time;
        transform.position = Vector3.LerpUnclamped(initialPosition, targetPosition, curve.Evaluate(tParameter));
        spriteRenderer.color = Color.LerpUnclamped(initialColor, finalColor, curve.Evaluate(tParameter));
        currentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();
        }
    }   

    private void StartTween()
    {
        tParameter = 0;
        currentTime = 0;
        initialPosition = transform.position;
        targetPosition = targetTransform.position;
    }

    private float EaseInElastic(float x)
    {
        float c5 = (2f * Mathf.PI) / 4.5f;
        return x == 0f
          ? 0f
          : x == 1f
          ? 1f
          : x < 0.5
          ? -(Mathf.Pow(2f, 20f * x - 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f
          : (Mathf.Pow(2f, -20f * x + 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f + 1f;
    }
}
