using UnityEngine;

// Class for initializing Property 
public class Property : MonoBehaviour {
    private static int pptID;   	// property ID, increment+1 from 1

    private string pptName;     	// property name   
    private int mongageValue;   	// mongage value of property
    private int houseCost;      	// cost of building a house of property
    private int pptRent;        	// rent value of property with no house
    private int[] houseNoRent;  	// rent value of property with 1/2/3/4 house(s)

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
