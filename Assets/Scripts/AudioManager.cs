using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip reloadClip;
    [SerializeField] private AudioClip getItem;
    [SerializeField] private AudioClip explosiveSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip laserSound;
    [SerializeField] private AudioClip miniBossSound;
    [SerializeField] private AudioSource defaultBackground;
    [SerializeField] private AudioSource bossBackground;

    public void playWinSound()
    {
        effectAudioSource.PlayOneShot(winSound);
    }

    public void playLaserSound()
    {
        effectAudioSource.PlayOneShot(laserSound);
    }


    public void playMiniBossSound()
    {
        effectAudioSource.PlayOneShot(miniBossSound);
    }
    public void playShootSound()
    {
        effectAudioSource.PlayOneShot(shootClip);
    }

    public void playReloadSound()
    {
        effectAudioSource.PlayOneShot(reloadClip);
    }

    public void playGetItemSound()
    {
        effectAudioSource.PlayOneShot(getItem);
    }

    public void playExplosiveSound()
    {
        effectAudioSource.PlayOneShot(explosiveSound);
    }

    public void playDefaultBackground()
    {
        bossBackground.Stop();
        defaultBackground.Play();
    }

    public void playBossBackground()
    {
        bossBackground.Play();
        defaultBackground.Stop();
    }

    public void stopAudio()
    {
        effectAudioSource.Stop();
        bossBackground.Stop();
        defaultBackground.Stop();
    }

}