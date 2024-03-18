using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float runSpeed = 1f;
    [SerializeField] private GameInput gameInput;   

    private bool isWalking;
    private bool isRunning;


    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        float runState = gameInput.GetRunningState();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        OnRun(runState);

        transform.position += moveDir * moveSpeed * runSpeed* Time.deltaTime;
        
        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime*rotateSpeed);

    }

    private void OnRun(float runState)
    {
        isRunning = runState > 0;

        if (isRunning)
        {
            runSpeed = 1.5f;
        }
        else
        {
            runSpeed = 1f;
        }

    }
    public bool IsWalking()
    {
        return isWalking;
    }

    public bool IsRunning()
    {
        return isRunning;
    }
}
