using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rayLength = 100f;
    
    private Camera _camera;

    private PlayerInput _input;
    private Vector2 _direction;

    private Vector3 _mousePosition;

    private void Awake()
    {
        _camera = Camera.main;

        _input = new PlayerInput();
        _input.Enable();
    }

    private void Update()
    {
        _direction = _input.Player.Move.ReadValue<Vector2>();
        _mousePosition = _input.Player.Look.ReadValue<Vector2>();

        Move(_direction);
        Look(_mousePosition);
    }

    private void Move(Vector2 direction)
    {
        if(direction.sqrMagnitude < 0.1)
            return;

        float scaleMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 move = new Vector3(direction.x, 0, direction.y);
        transform.position += move * scaleMoveSpeed;
    }

    private void Look(Vector3 mousePosition)
    {
        if (mousePosition.sqrMagnitude < 0.1)
            return;

        Ray cameraRay = _camera.ScreenPointToRay(mousePosition);
        Vector3 pointToLook = cameraRay.GetPoint(_rayLength);

        transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
    }
}
