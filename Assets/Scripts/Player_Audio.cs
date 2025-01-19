using UnityEngine;

public class Player_Audio : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip _audioClip;

    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudioClip()
    {
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}
