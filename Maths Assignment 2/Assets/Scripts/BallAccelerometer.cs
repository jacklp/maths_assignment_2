using UnityEngine;
using System.Collections;

public class BallAccelerometer : MonoBehaviour {

    float speed = 5.0f;
    // Use this for initialization
    void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Input.gyro.enabled = true;
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);

    }
    void OnGUI()
    {
        GUI.color = Color.red;
       // GUI.Label(new Rect(Screen.width/2, Screen.height/2, 100, 150), "Hello World");
        GUI.Label(new Rect(Screen.width/2, Screen.height/2-100, 500, 100), "X-Accel: " + Input.acceleration.x.ToString());
        GUI.Label(new Rect(Screen.width/2, Screen.height/2, 500, 100), "Y-Accel: " + Input.acceleration.y.ToString());
        GUI.Label(new Rect(Screen.width/2, Screen.height/2+100, 500, 100), "Z-Accel: " + Input.acceleration.z.ToString());
    }

    // Update is called once per frame
    void FixedUpdate() {


        float curSpeed = Time.deltaTime * speed;
        float x = Input.gyro.rotationRateUnbiased.x/**curSpeed;*/;
        float y = Input.gyro.rotationRateUnbiased.y/** curSpeed*/;
        float z = Input.gyro.rotationRateUnbiased.z/**curSpeed*/;

        this.transform.Translate(x, 0, -y);
    }
    

    
}
