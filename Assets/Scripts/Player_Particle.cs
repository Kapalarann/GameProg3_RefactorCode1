using UnityEngine;

public class Player_Particle : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private ParticleSystem _particleSystem;
    public void PlayParticleEffect()
    {
        _particleSystem.Play();
    }
}
