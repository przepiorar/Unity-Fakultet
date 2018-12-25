using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{    
    public float speedturn;
    float min = 330f;
    float max = 30f;

    void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxis("Mouse Y")) < 10)
        {
            transform.Rotate(new Vector3(-1 * Input.GetAxis("Mouse Y"), 0, 0) * speedturn);
        }

        //Debug.Log(-1 * Input.GetAxis("Mouse Y"));
       // Debug.Log(transform.eulerAngles.x);
        if (transform.localRotation.eulerAngles.x < min && transform.eulerAngles.x >180f) 
            transform.localRotation = Quaternion.Euler(min, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
        else if (transform.localRotation.eulerAngles.x > max && transform.eulerAngles.x< 180f)
            transform.localRotation = Quaternion.Euler(max, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
    }
}
