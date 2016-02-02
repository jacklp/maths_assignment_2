using UnityEngine;
using System.Collections;

public class gyroscopeController : MonoBehaviour {
    public bool enableTilt;
    private float initialX;
  //  private float initialY;
    private float initialZ;
    private float accelX =1.0f;
    private float accelY;
    private float accelZ=1.0f;
    private float maxX=10;
    private float maxZ=10;
    private Quaternion fixRot;
    private Quaternion speed;
    // Use this for initialization
    void Start () {
        Input.gyro.enabled = true;

        initialX = Mathf.Clamp(Input.gyro.rotationRate.x, maxX, -maxX);

        initialZ = Mathf.Clamp(Input.gyro.rotationRate.z, maxZ, -maxZ);

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

        GetComponent<Rigidbody>().AddForce(accelX*10, 0, accelZ*10);

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
