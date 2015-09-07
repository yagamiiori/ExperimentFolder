using UnityEngine;
using System.Collections;

public class VelSetCamera : MonoBehaviour {

    public Vector3 vel = Vector3.zero;
    public float speed = 0f;
    public float velsettime = 0f;

	void Start ()
    {
	
	}
	
	void fixedUpdate ()
    {
        if(0 < velsettime)
        {
            this.transform.Translate(vel * speed);
            velsettime -= 1.0f;
        }
	}

    // Vector3.up / Vector3.back / Vector3.left / Vector3.right等
    public void StartVelSet(Vector3 vel, float speed, float velsettime)
    {
        this.vel = vel;
        this.speed = speed;
        this.velsettime = velsettime;
    }
}
