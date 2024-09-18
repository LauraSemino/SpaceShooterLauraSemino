using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    private float velocity = 0.01f;
    private Vector3 Xdirection = Vector3.right
    private Vector3 Ydirection = Vector3.up

    void Update()
    {

       // transform.position += velocity;
        playerMovement();
    }
    public void playerMovement()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -18)
        { 
            transform.position -= Xvelocity;
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 18)
        {
            transform.position += Xvelocity;
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= 9)
        {
            transform.position += Yvelocity;
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= -9)
        {
            transform.position -= Yvelocity;
        }
    }
}
