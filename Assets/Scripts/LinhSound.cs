using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip Danh;
    public AudioClip Die;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {

    }
    public void DanhSound()
    {
        audioSource.clip = Danh; // Set the new audio clip
        audioSource.Play(); // Play the new sound when the character performs the attack animation
    }
    public void TuongDie()
    {
        audioSource.PlayOneShot(Die);
    }
}
