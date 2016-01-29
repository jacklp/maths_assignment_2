using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public GameObject player;
    private Vector3 OffSet;

	// Use this for initialization
	void Start () {
        OffSet = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        transform.LookAt(player.transform);
        transform.position = player.transform.position + OffSet;
	    
	}
}
