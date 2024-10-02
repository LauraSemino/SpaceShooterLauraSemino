using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public Vector3 direction;
    public float AngularSpeed;
    public float TargetAngle;
    public Transform targettransform;
    public Vector3 distancebetween;
    // Start is called before the first frame update
    void Start()
    {
        AngularSpeed = 2f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.position + transform.up*5;
        Debug.DrawLine(transform.position, direction);

       // Debug.DrawLine(transform.position, targettransform.position, Color.blue);

        TargetAngle = Mathf.Rad2Deg * Mathf.Atan2(targettransform.position.y - transform.position.y, targettransform.position.x - transform.position.x) - 90;
        //StandardizeAngle(TargetAngle);

        if (transform.eulerAngles.z < TargetAngle)
        {
            transform.Rotate(0f, 0f, AngularSpeed);
        }
        if (transform.eulerAngles.z > TargetAngle)
        {
            //We snap back to the correct target angle because it's too high
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                                                transform.eulerAngles.y,
                                                TargetAngle);
        }

    }
    public float StandardizeAngle(float inAngle)
    {
        inAngle = inAngle % 360;

        inAngle = (inAngle + 360) % 360;

        if (inAngle > 180)
        {
            inAngle -= 360;
        }

        return inAngle;
    }
}
