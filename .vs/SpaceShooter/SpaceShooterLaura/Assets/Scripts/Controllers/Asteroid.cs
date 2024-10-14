using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float arrivalDistance = 0.5f;
    public float maxFloatDistance = 1f;
    public Vector3 direction;
    public Vector3 velocity = Vector3.zero;
    public float friction = 0.02f;


    // Start is called before the first frame update
    void Start()
    {
        //direction = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       // if(transform.position.x <= direction.x + arrivalDistance && transform.position.x >= direction.x - arrivalDistance && transform.position.y <= direction.y + arrivalDistance && transform.position.y >= direction.y - arrivalDistance)
       // {
       //     direction = new Vector3(transform.position.x + Random.Range(-1, maxFloatDistance), transform.position.x + Random.Range(-1, maxFloatDistance));
       // }
        velocity += moveSpeed * direction * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (velocity.y > 0)
        {
            velocity.y -= friction * Time.deltaTime;
        }
        if (velocity.x > 0)
        {
            velocity.x -= friction * Time.deltaTime;
        }
        if (velocity.y < 0)
        {
            velocity.y += friction * Time.deltaTime;
        }
        if (velocity.x < 0)
        {
            velocity.x += friction * Time.deltaTime;
        }

    }


}
