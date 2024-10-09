using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProductTest : MonoBehaviour
{
    public float redAngle;
    public float blueAngle;
    Vector3 redVector;
    Vector3 blueVector;
    public float dotproduct;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        redVector.x = Mathf.Cos(redAngle * Mathf.Deg2Rad);
        redVector.y = Mathf.Sin(redAngle * Mathf.Deg2Rad);
        blueVector.x = Mathf.Cos(blueAngle * Mathf.Deg2Rad);
        blueVector.y = Mathf.Sin(blueAngle * Mathf.Deg2Rad);
        // redVector = Vector3.zero + transform.up * 1;
        // blueVector = Vector3.zero + transform.up * 1;
        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);

        dotproduct = redVector.x * blueVector.x + redVector.y * blueVector.y;
        if (Input.GetKeyDown(KeyCode.Space))
        {
          
           print(dotproduct);
        }
        
    }
}
