using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WolfAnimator : MonoBehaviour
{
    private const string IS_STATIC = "IsStatic";
    private const string IS_CHASING = "IsChasing";
    private const string IS_RETURNING_TO_POSITION = "IsReturningToPosition";
    private const string IS_ATTACKING = "IsAttacking";

    [SerializeField] private WolfInteraction wolf;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_STATIC, wolf.IsStatic());
        animator.SetBool(IS_CHASING, wolf.IsChasing());
        animator.SetBool(IS_RETURNING_TO_POSITION, wolf.IsReturningToPosition());
        animator.SetBool(IS_ATTACKING, wolf.IsAttacking());
    }
}
