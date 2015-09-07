using UnityEngine;
using System.Collections;

public class Vavava : MonoBehaviour {

	// Use this for initialization
	void Start () {

        var tes = new VelSetCamera();
        tes.StartVelSet(Vector3.right, 20.0f, 100000.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
