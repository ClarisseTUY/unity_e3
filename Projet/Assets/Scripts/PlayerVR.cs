using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerVR : MonoBehaviour
{
    public ActionBasedContinuousMoveProvider moveProvider;
    public InputActionProperty primaryButton;

    public float runningSpeed = 3f;
    private float normalSpeed;

    void Start()
    {
        if (moveProvider != null)
        {
            normalSpeed = moveProvider.moveSpeed;
        }
        else
        {
            Debug.LogWarning("MoveProvider not assigned!");
        }
    }

    void Update()
    {
        if (primaryButton.action != null && primaryButton.action.ReadValue<float>() > 0.5f)
        {
            moveProvider.moveSpeed = runningSpeed;
        }
        else
        {
            moveProvider.moveSpeed = normalSpeed;
        }
    }
}
