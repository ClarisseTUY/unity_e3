using UnityEngine;

public class XRButtonPressRelease : MonoBehaviour
{
    void Update()
    {
        // Check if button A (primary action button) is pressed
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("Button A pressed");
        }

        // Check if button B (secondary action button) is pressed
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Debug.Log("Button B pressed");
        }

        // Check if button X (secondary action button) is pressed
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Button X pressed");
        }

        // Check if button Y (secondary action button) is pressed
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Debug.Log("Button Y pressed");
        }

        // Check if left trigger is pressed
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            Debug.Log("Left trigger pressed");
        }

        // Check if right trigger is pressed
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            Debug.Log("Right trigger pressed");
        }

        // Check if menu button is pressed
        if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            Debug.Log("Menu button pressed");
        }
    }
}
