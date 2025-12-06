using UnityEngine;

public class CatSoundMannager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip meow;
    public AudioClip meow2;
    public AudioClip eating;
 //   public AudioClip sleeping;
    public AudioClip purring;
    public AudioClip angry;

    public void PlayMeow()
    {
        audioSource.PlayOneShot(meow);
    }

    public void PlayMeow2()
    {
        audioSource.PlayOneShot(meow2);
    }

    public void PlayEat()
    {
        audioSource.PlayOneShot(eating);
    }

    public void PlaySleep()
    {
        audioSource.PlayOneShot(purring);
    }

    public void PlayPurring()
    {
        audioSource.PlayOneShot(purring);
    }

    public void PlayAngry()
    {
        audioSource.PlayOneShot(angry);
    }
}
