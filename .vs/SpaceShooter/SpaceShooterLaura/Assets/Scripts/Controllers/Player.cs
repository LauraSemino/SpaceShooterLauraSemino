using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    private Vector3 Xvelocity = Vector3.right * 0.01f;
    private Vector3 Yvelocity = Vector3.up * 0.01f;

    public Vector3 velocity = Vector3.zero;
    public float acceleration = 2f;
    public float timeToReachSpeed = 0.5f;
    public float targetSpeed = 5f;
    public float friction = 0.02f;
   
    private void Start()
    {
        acceleration = targetSpeed / timeToReachSpeed;
    }
    void Update()
    {

        // transform.position += velocity;
         if (velocity.x >= targetSpeed)
         {
             velocity.x = targetSpeed;
         }
         if (velocity.x <= -targetSpeed)
         {
             velocity.x = -targetSpeed;
         }
         if (velocity.y >= targetSpeed)
         {
             velocity.y = targetSpeed;
         }
         if (velocity.y <= -targetSpeed)
         {
             velocity.y = -targetSpeed;
         }

        ApplyFriction();
        playerMovement();
    }
    public void playerMovement()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity -= acceleration * transform.right * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += acceleration * transform.right * Time.deltaTime;
           
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += acceleration * transform.up * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity -= acceleration * transform.up * Time.deltaTime;
            
        }
        transform.position += velocity * Time.deltaTime;


       
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
            velocity.x = -(1.1f* velocity.x);
        }
        if (transform.position.x >= 18)
        {
            velocity.x = -(1.1f* + velocity.x);
        }
    }
}
