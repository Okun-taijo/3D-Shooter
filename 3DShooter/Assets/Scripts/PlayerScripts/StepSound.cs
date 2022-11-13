using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    public AudioClip[] stepSoundClips;
    private AudioSource _stepSource;

    private void Start()
    {
        _stepSource = GetComponent<AudioSource>();       
    }

    public void StepSoundPlay()
    {
        _stepSource.PlayOneShot(stepSoundClips[Random.Range(0, stepSoundClips.Length)]);
    }

}
