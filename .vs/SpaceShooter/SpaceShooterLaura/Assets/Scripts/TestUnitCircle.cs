using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnitCircle : MonoBehaviour
{
    public List<float> angles;
    public float radius;
    public Vector3 circleLocation = Vector3.zero;
    //public Vector3 linedestination;
    private int currentAngleIndex = 0;
    private float timeSinceLastUpdate = 0f;
    public float updateFrequency = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate > updateFrequency)
        {
            currentAngleIndex += 1;
            timeSinceLastUpdate = 0f;
            if (currentAngleIndex > angles.Count - 1)
            {
                currentAngleIndex = 0;
            }
        }

        float currentAngle = angles[currentAngleIndex];
        Vector3 startingPoint = circleLocation ;
        float endPointX = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;
        float endPointY = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;
        Vector3 endingPoint = new Vector3(endPointX, endPointY) + circleLocation;
        Debug.DrawLine(startingPoint, endingPoint, Color.red);
        
        /**
        {
            print("test");
            for (int i = 0; i < angles.Capacity - 1; i++)
            {
                linedestination = new Vector3(Mathf.Cos(angles[i])/radius, Mathf.Sin(angles[i])/radius);
                Debug.DrawLine(Vector3.zero, linedestination, Color.yellow);
            }
        }**/
    }
}
