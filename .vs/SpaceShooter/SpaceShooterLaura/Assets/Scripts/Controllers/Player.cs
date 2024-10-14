using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public GameObject powerupPrefab;
    private Vector3 Xvelocity = Vector3.right * 0.01f;
    private Vector3 Yvelocity = Vector3.up * 0.01f;


    public Vector3 velocity = Vector3.zero;
    public float acceleration = 2f;
    public float timeToReachSpeed = 0.5f;
    public float targetSpeed = 5f;
    public float friction = 0.02f;

    public float dashtimer;


    private float shieldRadius;
    private Vector3 enemyDistance;
    public List<float> circPointAngles;

    private void Start()
    {
        acceleration = targetSpeed / timeToReachSpeed;
        shieldRadius = 1.5f;
        dashtimer = 0.5f;

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
        enemyDetector();
        if (Input.GetKeyDown(KeyCode.P))
        {
            spawnPowerups();
        }
        
    }
    public void enemyDetector()
    {
        Color lineColor;
        if (enemyDistance.magnitude < shieldRadius)
        {
             lineColor = Color.red;     
        }
        else
        {
            lineColor = Color.green;
        }
        Vector3 playerPos = transform.position;
        for (int i = 0; i < circPointAngles.Count - 1; i++)
        {
            Vector3 startPoint;
            Vector3 endPoint;
            startPoint = new Vector3(Mathf.Cos(circPointAngles[i] * Mathf.Deg2Rad) * shieldRadius, Mathf.Sin(circPointAngles[i] * Mathf.Deg2Rad) * shieldRadius) + playerPos;
            endPoint = new Vector3(Mathf.Cos(circPointAngles[i+1] * Mathf.Deg2Rad) * shieldRadius, Mathf.Sin(circPointAngles[i+1] * Mathf.Deg2Rad) * shieldRadius) + playerPos;
           // Debug.DrawLine(startPoint, endPoint, lineColor);
        }
        enemyDistance = new Vector3(enemyTransform.position.x - playerPos.x,enemyTransform.position.y - playerPos.y);
        //Debug.DrawLine(playerPos, enemyTransform.position, Color.yellow);
       


    }
    public void spawnPowerups()
    {
        Vector3 playerPos = transform.position;
        for (int i = 0; i < circPointAngles.Count - 1; i++)
        {
            Vector3 spawnPoint;
            //Vector3 endPoint;
            spawnPoint = new Vector3(Mathf.Cos(circPointAngles[i] * Mathf.Deg2Rad) * shieldRadius, Mathf.Sin(circPointAngles[i] * Mathf.Deg2Rad) * shieldRadius) + playerPos;
            //endPoint = new Vector3(Mathf.Cos(circPointAngles[i+1] * Mathf.Deg2Rad) * shieldRadius, Mathf.Sin(circPointAngles[i+1] * Mathf.Deg2Rad) * shieldRadius) + playerPos;
            Instantiate(powerupPrefab, spawnPoint, Quaternion.identity);
        }
    }
    public void playerMovement()
    {
        
        if (dashtimer < 0.5f)
        {
            targetSpeed = 25;
            timeToReachSpeed = 0f;
            dashtimer += 1 * Time.deltaTime;
        }
        else if( dashtimer > 0.5f)
        {
            targetSpeed = 5;
            timeToReachSpeed = 0.5f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity -= acceleration * transform.right * Time.deltaTime;
            //dash function 
            if (Input.GetKeyDown(KeyCode.Space) && dashtimer >= 0.5f)
            {
                velocity = new Vector3(-25,0);
                dashtimer = 0;
            }

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += acceleration * transform.right * Time.deltaTime;
            //dash function 
            if (Input.GetKeyDown(KeyCode.Space) && dashtimer >= 0.5f)
            {
                velocity = new Vector3(25, 0);
                dashtimer = 0;
            }

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += acceleration * transform.up * Time.deltaTime;
            //dash function 
            if (Input.GetKeyDown(KeyCode.Space) && dashtimer >= 0.5f)
            {
                velocity = new Vector3(0, 25);
                dashtimer = 0;
            }

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity -= acceleration * transform.up * Time.deltaTime;
            //dash function 
            if (Input.GetKeyDown(KeyCode.Space) && dashtimer >= 0.5f)
            {
                velocity = new Vector3(0, -25);
                dashtimer = 0;
            }

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

    public void HomingMissles()
    {
        //create a new prefab of a missle. in the missle class have its destination be the enemy.
    }
    public void Dash()
    {
        //Save the player's prev velocity, then increase it a lot for a little bit, then set it back to what it was before
    }
    public void TractorBeam()
    {
        //Use code from VisionCone to find the area to check, and have it affect the transforms/velcoties of the asteroids
    }
}
