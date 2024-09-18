using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 velocity = Vector3.zero;
    public float acceleration = 2f;
    public Vector3 direction;
    private void Update()
    {
        direction = new Vector3(playerTransform.position.x - transform.position.x, playerTransform.position.y - transform.position.y);
        velocity += acceleration * direction * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;


        if (transform.position.y <= -9)
        {
            velocity.y = -(1.1f * velocity.y);
        }
        if (transform.position.y >= 9)
        {
            velocity.y = -(1.1f * velocity.y);
        }
        if (transform.position.x <= -18)
        {
            velocity.x = -(1.1f * velocity.x);
        }
        if (transform.position.x >= 18)
        {
            velocity.x = -(1.1f * +velocity.x);
        }
    }

}
