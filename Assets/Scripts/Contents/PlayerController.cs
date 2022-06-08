using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Newtonsoft.Json.Linq;

public class PlayerController : UnitController
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    protected Vector3 moveDirection;

    private Vector3 moveInputDirection;
    private Vector3 oldMoveInputDirection;

    [SerializeField]
    protected UnityEvent<Vector3> moveUpdateEvent;

    public int jumpCount = 0;
    public int maxJumpCount = 2;
    [SerializeField]
    protected UnityEvent jumpUpdateEvent;

    public int currentCombo = 0;
    public int maxCombo = 3;
    [SerializeField]
    protected UnityEvent<int> comboUpdateEvent;

    [SerializeField]
    protected bool isInput = true;

    protected override void Start()
    {
        base.Start();
    }

    public void SetInput(bool isInput)
    {
        this.isInput = isInput;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInput)
            return;

        moveInputDirection.x = Input.GetAxisRaw("Horizontal");
        moveInputDirection.z = Input.GetAxisRaw("Vertical");

        if (moveInputDirection != oldMoveInputDirection)
        {
            oldMoveInputDirection = moveInputDirection;
            moveDirection = moveInputDirection;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        //animator.SetBool("Run", moveDirection.sqrMagnitude > 0.5f);
        moveUpdateEvent?.Invoke(moveDirection);
    }

    public void Jump()
    {
        //TODO :: ANIMATION => JUMP

        ++jumpCount;
        //animator.SetTrigger("Jump");
        jumpUpdateEvent?.Invoke();
    }

    public void Attack()
    {
        //TODO :: ANIMATION => ATTACK_{COMBO}
        ++currentCombo;
        currentCombo = currentCombo % maxCombo;
        //animator.SetTrigger($"Attack{combo + 1}");
        comboUpdateEvent?.Invoke(currentCombo);
    }

    public virtual void CheckGrounded(bool isGrounded)
    {
        if (isGrounded)
        {
            jumpCount = 0;
        }

        //animator.SetBool("Grounded", isGrounded);
    }
}
