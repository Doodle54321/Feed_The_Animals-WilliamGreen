/*

GameObject: Player

Description: Handles movement mechanics based on Player Input and controls the movement animations.
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
[SerializeField] private float playerSpeed;
private const float centerToEdge = 22.0f;
private bool directionXPositive;

private Animator animator;
private Vector2 moveInput;

private void Start()
{
    animator = GetComponent<Animator>();
}

private void Update()
{
    Move();
}

// Called by: Player Input
public void OnMovementInput2(InputAction.CallbackContext ctx)
{
    Debug.Log($"move input{moveInput}");
    moveInput = ctx.ReadValue<Vector2>();
    DeterminePlayerDirection(moveInput);
}

private void DeterminePlayerDirection(Vector2 xValue)
{
    if (xValue.x > 0)
    {
        directionXPositive = true;
    }
    else if (xValue.x < 0)
    {
        directionXPositive = false;
    }
}

private void Move()
{
    if (moveInput.x != 0)
    {
        animator.SetBool("IsRunning", true);

        float nextX = transform.position.x + moveInput.x * playerSpeed * Time.deltaTime;
        nextX = Mathf.Clamp(nextX, -centerToEdge, centerToEdge);

        transform.position = new Vector3(nextX, transform.position.y, transform.position.z);
    }
    else
    {
        animator.SetBool("IsRunning", false);
    }
}
}
