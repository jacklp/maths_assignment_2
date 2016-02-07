using UnityEngine;
using System.Collections;

public class gyroscopeController : MonoBehaviour {
    public bool enableTilt;
    private float initialX;
    private float initialY;
    private float initialZ;
    private float accelX =1.0f;
    private float accelY = 1.0f;
    private float accelZ=1.0f;
    private float Max = 10;
    private Quaternion fixRot;
    private Quaternion speed;
    // Use this for initialization
    void Start () {
        Input.gyro.enabled = true;

        initialX = Mathf.Clamp(Input.gyro.rotationRate.x, Max, -Max);
        initialY = Mathf.Clamp(Input.gyro.rotationRate.y, Max, -Max);
        initialZ = Mathf.Clamp(Input.gyro.rotationRate.z, Max, -Max);

        if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            transform.eulerAngles = new Vector3(90, 90, 0);
        }
        else if (Screen.orientation == ScreenOrientation.Portrait)
        {
            transform.eulerAngles = new Vector3(90, 180, 0);
        }

        if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            fixRot = new Quaternion(0, 0, 0.7071f, 0.7071f);
        }
        else if (Screen.orientation == ScreenOrientation.Portrait)
        {
            fixRot = new Quaternion(0, 0, 1, 0);
        }
        else
        {
            Debug.Log("NO GYRO");
        }

    }
   
	void Update () {
       

         accelX = Input.gyro.rotationRateUnbiased.x;
         accelZ = Input.gyro.rotationRateUnbiased.z;

        speed = Input.gyro.attitude * fixRot;

        GetComponent<Rigidbody>().AddForce(-accelZ*10, 0, -accelX * 10);

        if (SystemInfo.supportsGyroscope)
        {
            Debug.Log("YES");
        }
        else
        {
            Debug.Log("NO");
        }
    }

}
