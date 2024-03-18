using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector;
    }    
    public float GetRunningState()
    {
        float run = playerInputActions.Player.Run.ReadValue<float>();

        return run;
    }

    public bool GetSittingState()
    {
        bool sit = playerInputActions.Player.Sit.triggered;

        return sit;
    }

}
