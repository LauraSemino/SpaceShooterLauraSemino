using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Missle : MonoBehaviour
{
    GameObject enemy;
    public Vector3 enemypos;
    public Vector3 direction;
    public Vector3 velocity = Vector3.zero;
    public float acceleration = 5f;
    public float TargetAngle;
    public float AngularSpeed;
    public float targetSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        targetSpeed = 15f;
        AngularSpeed = 5f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        direction = enemypos - transform.position;
        enemypos = enemy.transform.position;
        velocity += acceleration * direction * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        transform.Rotate(0,0,TargetAngle);
        TargetAngle = Mathf.Rad2Deg * Mathf.Atan2(enemypos.y - transform.position.y, enemypos.x - transform.position.x) - 90;
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
    }
}
