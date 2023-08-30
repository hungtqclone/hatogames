using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuongDichAudio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip Danh;
    public float amLuong;
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
    public void PlayAttackSound()
    {
        audioSource.Play(); // Phát âm thanh khi nhân vật thực hiện animation đánh
    }

    public void StopAttackSound()
    {
        audioSource.Stop(); // Tắt âm thanh khi animation kết thúc
    }
    public void TuongDie()
    {
        audioSource.volume = audioSource.volume * amLuong;
        audioSource.PlayOneShot(Die);
    }

    
}
