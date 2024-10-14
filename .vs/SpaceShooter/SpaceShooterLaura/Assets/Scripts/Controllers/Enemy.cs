using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 velocity = Vector3.zero;
    public float acceleration = 2f;
    public float friction = 0.02f;
    public Vector3 direction;
    private void Update()
    {
        direction = new Vector3(playerTransform.position.x - transform.position.x, playerTransform.position.y - transform.position.y);
        velocity += acceleration * direction * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        ApplyFriction();
        if (transform.position.y <= -9)
        {
            velocity.y = -(1f * velocity.y);
        }
        if (transform.position.y >= 9)
        {
            velocity.y = -(1f * velocity.y);
        }
        if (transform.position.x <= -18)
        {
            velocity.x = -(1f * velocity.x);
        }
        if (transform.position.x >= 18)
        {
            velocity.x = -(1f * +velocity.x);
        }
        
    }

    public void ApplyFriction()
    {
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
