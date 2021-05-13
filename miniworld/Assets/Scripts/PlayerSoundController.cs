using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip walkFX1;
    public AudioClip walkFX2;
    public AudioClip wetWalkFX1;
    public AudioClip wetWalkFX2;
    public AudioClip eatFX;
    public AudioClip healFX;
    public AudioClip hitFX;
    public AudioClip rainHitFX;
    public AudioClip powerFX;
    public AudioClip shieldFX;
    public AudioClip jumpFX;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayWalk_R()
    {
        if (playerController)
        {
            if (playerController.itsRainning)
                audio.PlayOneShot(wetWalkFX1);
            else
                audio.PlayOneShot(walkFX1);
        }
        else
            audio.PlayOneShot(walkFX1);
    }

    private void PlayWalk_L()
    {
        if (playerController)
        {
            if (playerController.itsRainning)
                audio.PlayOneShot(wetWalkFX2);
            else
                audio.PlayOneShot(walkFX2);
        }
        else
            audio.PlayOneShot(walkFX2);
    }

    private void EatSoundPlay()
    {
        audio.PlayOneShot(eatFX);
    }

    private void HealSoundPlay()
    {
        audio.PlayOneShot(healFX);
    }

    private void HitSoundPlay()
    {
        audio.PlayOneShot(hitFX);
    }

    private void RainHitSound()
    {
        audio.PlayOneShot(rainHitFX);
    }

    private void PowerSound()
    {
        audio.PlayOneShot(powerFX);
    }
    private void ShieldSound()
    {
        audio.PlayOneShot(shieldFX);
    }

    private void JumpSound()
    {
        audio.PlayOneShot(jumpFX);
    }
}
