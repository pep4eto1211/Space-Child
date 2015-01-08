using UnityEngine;
using System.Collections;

public class CameraOrbitNew : MonoBehaviour {

    public float rotateSpeed;
    public Transform Player;

	// Use this for initialization
	void Start () 
    {
        rotateSpeed *= 100;
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        string YAxis;
        string XAxis;
        if (Input.GetJoystickNames().Length > 0)
        {
            YAxis = "Joystick Y";
            XAxis = "Joystick X";
        }
        else
        {
            YAxis = "Mouse Y";
            XAxis = "Mouse X";
        }
        float x = Input.GetAxis(XAxis);
        float y = Input.GetAxis(YAxis);
        y *= Time.deltaTime * rotateSpeed;
        if ((y > 0.0f) && (transform.eulerAngles.x> 23.0f) && (transform.eulerAngles.x < 90.0f))
        {
            y = 0;
        }
        if ((y < 0.0f) && (transform.eulerAngles.x < 330.0f) && (transform.eulerAngles.x > 270.0f))
        {
            y = 0;
        }
        x *= Time.deltaTime * rotateSpeed * -1;
        transform.Rotate(new Vector3(y, 0.0f, 0.0f), Space.Self);
        if (Input.GetAxis("Vertical") != 0)
        {
            float angle = 0f;
            if (transform.rotation.eulerAngles.y < 180f)
            {
                angle = transform.rotation.eulerAngles.y + 180f;
            }
            else
            {
                angle = transform.rotation.eulerAngles.y - 180f;
            }
            if (Player.rotation.eulerAngles.y != transform.rotation.eulerAngles.y)
            {
                Player.rotation = Quaternion.Euler(new Vector3(Player.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Player.rotation.eulerAngles.z));
                transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.eulerAngles.x, 0.0f, transform.localRotation.eulerAngles.z));
            }
            transform.Rotate(Vector3.up, -1 * transform.localRotation.y * 10, Space.World);
            Player.Rotate(Vector3.up, x, Space.World);   
        }
        else
        {
            transform.Rotate(Vector3.up, x, Space.World);
        }

        if (Input.GetButton("Center"))
        {
            transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.eulerAngles.x, 0.0f, transform.localRotation.eulerAngles.z));
        }
    }
}
