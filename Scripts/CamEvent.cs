using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamEvent : MonoBehaviour {

    public Camera[] cams;

    public void camMain()
    {
        cams[0].enabled = true;
        cams[1].enabled = false;
    }

    public void camDice()
    {
        cams[0].enabled = false;
        cams[1].enabled = true;
    }
    /*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
}
