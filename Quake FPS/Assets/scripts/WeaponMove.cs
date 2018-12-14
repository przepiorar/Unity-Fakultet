using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{    
    public float speedturn;
    float min = 60f;
    float max = 120f;

    void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxis("Mouse Y")) < 10)
        {
            transform.Rotate(new Vector3(-1 * Input.GetAxis("Mouse Y"), 0, 0) * speedturn);
        }

        //Debug.Log(transform.localRotation.eulerAngles.x);
        if (transform.localRotation.eulerAngles.x < min && transform.eulerAngles.x > 0f)  // 360 pelny obrot
            transform.localRotation = Quaternion.Euler(min, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
        else if (transform.localRotation.eulerAngles.x < max && transform.eulerAngles.x > 270f)
            transform.localRotation = Quaternion.Euler(max, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
    }
}
