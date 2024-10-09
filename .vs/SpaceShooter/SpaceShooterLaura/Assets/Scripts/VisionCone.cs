using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public float detectionRadius;
    public float detectionAngle;
    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 lookingDirection = transform.up;
        //Switching from vector to angle in terms of the looking directoin
        float lookingAngle = Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg;

        float leftAngle = lookingAngle + detectionAngle / 2;
        float rightAngle = lookingAngle - detectionAngle / 2;

        //Switching from angle to vector in terms of the limits of the field of view for the vision cone
        Vector3 leftVector = new Vector3(Mathf.Cos(leftAngle * Mathf.Deg2Rad), Mathf.Sin(leftAngle * Mathf.Deg2Rad));
        Vector3 rightVector = new Vector3(Mathf.Cos(rightAngle * Mathf.Deg2Rad), Mathf.Sin(rightAngle * Mathf.Deg2Rad));


    }
}
