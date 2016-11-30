using UnityEngine;
using System.Collections;

public class CarLikeMovement : MonoBehaviour {

    // Use this for initialization
    private readonly float MAX_SPEED = 50f;
    public float speed = 0.5f;
    private float rot = 0.0f;
    public float throttle = 0;
    private bool isForward = false;
    private Camera cam;
    private Rigidbody rigidBody;
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Gas"))
        {
            throttle += 0.1f;
            isForward = true;
        }
        if (Input.GetButton("Break"))
        {
            throttle -= 1.5f;
            isForward = false;
        }
        checkThrottle();
        rot -= Input.GetAxis("Horizontal") * (throttle/50);
        transform.eulerAngles = new Vector3(270f, rot, 180f);
        transform.position += cam.transform.forward * Time.deltaTime * throttle;
    }

    private void checkThrottle()
    {
        if (throttle >= MAX_SPEED)
        {
            throttle = MAX_SPEED;
        }
        else if (throttle <= 0)
        {
            throttle = 0;
        }
    }
}
