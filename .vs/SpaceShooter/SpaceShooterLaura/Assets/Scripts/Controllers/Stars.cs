using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DrawStars());
    }

    IEnumerator DrawStars()
    {
        for (int i = 0; i < starTransforms.Capacity - 1; i++)
        {
            yield return new WaitForSeconds(drawingTime);
            
            Debug.DrawLine(starTransforms[i].position, starTransforms[i + 1].position, Color.yellow);
            
        }
    }

    
}
