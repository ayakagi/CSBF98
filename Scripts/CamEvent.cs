using UnityEngine;

// Class for Camera Setting
public class CamEvent : MonoBehaviour {
    public Camera[] cams;

    // Showing the game board
    public void CamMain()
    {
        cams[0].enabled = true;
        cams[1].enabled = false;
        cams[2].enabled = false;
    }

    // Zooming in to dice rolling animation
    public void CamDice()
    {
        cams[0].enabled = false;
        cams[1].enabled = true;
        cams[2].enabled = false;
    }

    // Zooming in to token moving animation
    public void CamToken()
    {
        cams[0].enabled = false;
        cams[1].enabled = false;
        cams[2].enabled = true;
    }
}
