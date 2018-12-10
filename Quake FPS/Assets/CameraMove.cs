using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    
    public float speedturn;
    float min = 330f;
    float max = 30f;

    void FixedUpdate()
    {
        //transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0)  * speedturn);
             transform.Rotate(new Vector3(-1 * Input.GetAxis("Mouse Y"), 0, 0) * speedturn);  //dobre

        Debug.Log(transform.eulerAngles.x);
        if (transform.eulerAngles.x < min && transform.eulerAngles.x >200f)  // 360 pelny obrot czyli tutaj 315
            transform.rotation = Quaternion.Euler(min, transform.eulerAngles.y, transform.eulerAngles.z);
        // ten sam warunek xddd
        else if (transform.eulerAngles.x > max && transform.eulerAngles.x< 200f)
            transform.rotation = Quaternion.Euler(max, transform.eulerAngles.y, transform.eulerAngles.z);

        //  angle = Mathf.Clamp(Input.GetAxis("Mouse Y")*-10, -90, 90) *speedturn;
        // transform.localRotation = Quaternion.AngleAxis(angle, Vector3.right);



        //  if (transform.eulerAngles > new Vector3(90,0,0))
        // {
        //     transform.rotation = new Quaternion(90, 0, 0,0);
        // }
    }
}
