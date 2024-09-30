using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    private float orbitRadius = 2;
    public float direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Debug.DrawLine(transform.position, planetTransform.position, Color.yellow);
         orbitRadius = new Vector3(planetTransform.position.x - transform.position.x, planetTransform.position.y - transform.position.y);
         orbitRadius = orbitRadius.normalized;
         planetTransform.position = new Vector3(orbitRadius.y, orbitRadius.x); */

        
            //Vector3 startPoint;
            Vector3 endPoint;
            //startPoint = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad) * orbitRadius, Mathf.Sin(i * Mathf.Deg2Rad) * orbitRadius) + transform.position;
            endPoint = new Vector3(Mathf.Cos(direction + 1 * Mathf.Deg2Rad) * orbitRadius, Mathf.Sin(direction + 1 * Mathf.Deg2Rad) * orbitRadius) + transform.position;
            direction += 1 * Time.deltaTime;
            // Debug.DrawLine(startPoint, endPoint, lineColor);
            planetTransform.position = endPoint;
           if (direction == 360)
            {
                direction = 0;
            }
        }
        
    }

