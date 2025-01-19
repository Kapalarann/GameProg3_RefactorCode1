using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [Header("Controls")]
    [Tooltip("use Keys to move")]
    [SerializeField] private KeyCode _forwardKey;
    [SerializeField] private KeyCode _backwardKey;
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _rightKey;

    public Vector3 HandleInput()
    {
        float xInput = 0, zInput = 0;

        if (Input.GetKey(_forwardKey)) zInput++;
        if (Input.GetKey(_backwardKey)) zInput--;
        if (Input.GetKey(_leftKey)) xInput--;
        if (Input.GetKey(_rightKey)) xInput++;

        return new Vector3(xInput, 0, zInput);
    }
}
