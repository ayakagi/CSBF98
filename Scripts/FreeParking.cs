using UnityEngine;

// Class for initializing Free Parking tile
public class FreeParking : MonoBehaviour {
    private int tax;        // balance that received from fine

	// Use this for initialization
	void Start () {
        tax = 0;
	}

    // Get the value of tax
    public int GetTax()
    {
        return tax;
    }

    // Set the value of tax to 0
    public void ResetTax()
    {
        tax = 0;
    }
}
