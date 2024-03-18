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
    private float runSpeed = 1f;
    [SerializeField] private GameInput gameInput;   

    private bool isWalking;
    private bool isRunning;
    private bool isJumping;
    private bool isSitting = false;
    private bool isMovingRight;
    private bool isMovingLeft;


    private void Update()
    {
        Sit();
        OnRun();
        OnWalk();
        OnJump();   
        UpdateMovementDirection();
    }
    private void OnWalk()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDir * moveSpeed * runSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

        if(isWalking && isSitting)
        {
            isSitting = false;
        }
    }
    private void UpdateMovementDirection()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        isMovingRight = inputVector.x > 0;
        isMovingLeft = inputVector.x < 0;
    }
    public bool IsMovingRight()
    {
        return isMovingRight;
    }

    public bool IsMovingLeft()
    {
        return isMovingLeft;
    }

    private void OnRun()
    {
        float runState = gameInput.GetRunningState();
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
    private void OnJump()
    {
        float jumpState = gameInput.GetJumpingState();
        isJumping = jumpState > 0;
    }

    private void Sit() { 
        bool sit = gameInput.GetSittingState();
        if(sit)
        {
            isSitting = !isSitting;
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
    public bool IsJumping()
    {
        return isJumping;
    }
    public bool IsSitting()
    {
        return isSitting;
    }
}
