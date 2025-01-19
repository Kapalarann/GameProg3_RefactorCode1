using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    Player_Particle _particle;
    Player_Audio _audio;

    [Header("Collision")]
    [SerializeField] LayerMask _wallLayer;

    private void Awake()
    {
        _particle = GetComponent<Player_Particle>();
        _audio = GetComponent<Player_Audio>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((_wallLayer.value & (1 << hit.gameObject.layer)) > 0)
        {
            _audio.PlayAudioClip();
            _particle.PlayParticleEffect();
        }
    }
}
