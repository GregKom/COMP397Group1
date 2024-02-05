using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
    }

    private void Update()
    {
        Move(controls.Player.Move.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction)
    {
        // Use the input direction to move your character
        float speed = 5f;
        transform.Translate(new Vector3(direction.x, 0f, direction.y) * speed * Time.deltaTime);
    }
}
