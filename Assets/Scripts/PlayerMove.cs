using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    public Vector2 LastMoveDirection { get; private set; } = Vector2.up;

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        Vector2 direction = Vector2.zero;

        if (keyboard.leftArrowKey.isPressed) direction.x -= 1f;
        if (keyboard.rightArrowKey.isPressed) direction.x += 1f;
        if (keyboard.upArrowKey.isPressed) direction.y += 1f;
        if (keyboard.downArrowKey.isPressed) direction.y -= 1f;

        direction = direction.normalized;

        if (direction != Vector2.zero)
        {
            LastMoveDirection = direction;
        }

        transform.position += new Vector3(direction.x, direction.y, 0f) * moveSpeed * Time.deltaTime;
    }
}
