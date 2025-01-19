using UnityEngine;

public class Player : MonoBehaviour
{
    Player_Input _input;
    Player_Movement _movement;
    Player_Collision _collision;

    private void Awake()
    {
        _input = GetComponent<Player_Input>();
        _movement = GetComponent<Player_Movement>();
        _collision = GetComponent<Player_Collision>();
    }

    private void Update()
    {
        _movement.Move(_input.HandleInput());
    }
}
