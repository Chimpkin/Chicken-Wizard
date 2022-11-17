using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutomCursor : MonoBehaviour
{
    // How fast the mouse moves, should use a slider for the player to adjust
    public float mouseSensitivity = 150;

    void Start()
    {
        // This hides and locks the mouse to the center of the screen
        Cursor.lockState = CursorLockMode.Confined;
    }

}