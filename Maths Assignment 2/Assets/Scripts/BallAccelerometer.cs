using UnityEngine;
using System.Collections;

public class BallAccelerometer : MonoBehaviour {
    public float movementScale;
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Vector3.Dot(Input.gyro.gravity, Vector3.left) * movementScale;
        pos.y = Vector3.Dot(Input.gyro.gravity, Vector3.up) * movementScale;
        transform.position = pos;
    }
}

    //private float gyroZ;
    //private float gyroX;
    //private float speed=5.0f;
    //// Use this for initialization
    //void Start () {
    //    //Screen.orientation = ScreenOrientation.LandscapeLeft;
    //    Input.gyro.enabled = true;
    //    //Debug.Log(Screen.width);
    //    //Debug.Log(Screen.height);

    //}
    //void OnGUI()
    //{
    //    GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 - 100, 500, 100), "X-Accel: " + gyroX);
    //    GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 500, 100), "Z-Accel: " + gyroZ);
    //}

    //// Update is called once per frame
    //void Update() {
    //    gyroX = Input.gyro.attitude.x;
    //    gyroZ = Input.gyro.attitude.z;
    //    GetComponent<Rigidbody>().AddForce(gyroX * speed, 0, gyroZ * speed);
    //}
    

    
//}
