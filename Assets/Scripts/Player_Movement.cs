using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Horizontal Speed")]
    [SerializeField] private float _moveSpeed;
    [Tooltip("Rate of change for moveSpeed")]
    [SerializeField] private float _acceleration;
    [Tooltip("Deceleration rate when no input is provided")]
    [SerializeField] private float _deceleration;

    private float _velocity;
    private CharacterController _characterController;
    private float _initialYPos;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _initialYPos = transform.position.y;
    }

    public void Move(Vector3 inputVector)
    {
        if (inputVector == Vector3.zero)
        {
            if (_velocity > 0)
            {
                _velocity -= _deceleration * Time.deltaTime;
                _velocity = Mathf.Max(_velocity, 0);
            }
        }
        else
        {
            _velocity = Mathf.Lerp(_velocity, _moveSpeed, Time.deltaTime * _acceleration);
        }

        Vector3 movement = inputVector.normalized * _velocity * Time.deltaTime;
        _characterController.Move(movement);
        transform.position = new Vector3(transform.position.x, _initialYPos, transform.position.z);
    }
}
