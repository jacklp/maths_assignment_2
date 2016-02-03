using UnityEngine;
using System.Collections;

public class moveKB : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        Mathf.Clamp(speed, -10.0f, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
        speed += Time.deltaTime;
	    if(Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(speed, 0, 0);
        }
    }
}
