using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 20f)] float speed = 3f;
    
    [SerializeField]
    float posValue;

    Vector2 startPos;
    float newPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        newPos = Mathf.Repeat(Time.time * speed, posValue);
        transform.position = startPos + Vector2.left * newPos;
    }



}
