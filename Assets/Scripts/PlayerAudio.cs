using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioClip FootstepReference;
    [SerializeField] private AudioClip JumpReference;
    [SerializeField] private AudioSource AudioSource;

    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void FootStepAudio()
    {
        AudioSource.PlayClipAtPoint(FootstepReference, transform.position);
    }
    public void JumpAudio()
    {
        AudioSource.PlayClipAtPoint(JumpReference, transform.position);
    }
}
