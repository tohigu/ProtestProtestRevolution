using UnityEngine;
using System.Collections;

public class PlayerDisplayPlane : MonoBehaviour {

    public KinectManager kinect;
    private Renderer renderer;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        renderer.material.mainTexture = kinect.GetUsersLblTex();
	}
}
