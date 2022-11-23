using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _stepSoundClips;
    [SerializeField] private AudioClip[] _attackSoundClips;
    private AudioSource _soundSource;

    private void Start()
    {
        _soundSource = GetComponent<AudioSource>();       
    }

    public void StepSoundPlay()
    {
        _soundSource.PlayOneShot(_stepSoundClips[Random.Range(0, _stepSoundClips.Length)]);
    }

    public void AttackSoundPlay()
    {
        _soundSource.PlayOneShot(_attackSoundClips[Random.Range(0, _attackSoundClips.Length)]);
    }
}
