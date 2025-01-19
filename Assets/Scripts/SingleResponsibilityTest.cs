using System.Threading;
using UnityEngine;

public class SingleResponsibilityTest : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Horizontal Speed")]
    [SerializeField] private float _moveSpeed;
    [Tooltip("Rate of change for moveSpeed")]
    [SerializeField] private float _acceleration;
    [Tooltip("Deceleration rate when no input is provided")]
    [SerializeField] private float _deceleration;

    [Header("Controls")]
    [Tooltip("use Keys to move")]
    [SerializeField] private KeyCode _forwardKey;
    [SerializeField] private KeyCode _backwardKey;
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _rightKey;

    [Header("Audio")]
    [SerializeField] private AudioClip _audioClip;

    [Header("Effects")]
    [SerializeField] private ParticleSystem _particleSystem;

    [Header("Collision")]
    [SerializeField] LayerMask _wallLayer;

    private Vector3 _inputVector;
    private float _velocity;
    private CharacterController _characterController;
    private float _initialYPos;

    private AudioSource _audioSource;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _initialYPos = transform.position.y;

        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleInput();
        Move(_inputVector);
    }

    void HandleInput()
    {
        float xInput = 0, zInput = 0;

        if (Input.GetKey(_forwardKey)) zInput++;
        if (Input.GetKey(_backwardKey)) zInput--;
        if (Input.GetKey(_leftKey)) xInput--;
        if (Input.GetKey(_rightKey)) xInput++;

        _inputVector = new Vector3(xInput, 0, zInput);
    }
    void Move(Vector3 inputVector)
    {
        if(inputVector == Vector3.zero)
        {
            if(_velocity > 0)
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

    private void PlayAudioClip()
    {
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
    private void PlayParticleEffect()
    {
        _particleSystem.Play();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((_wallLayer.value & (1<<hit.gameObject.layer)) > 0){
            PlayAudioClip();
            PlayParticleEffect();
        }
    }
}
