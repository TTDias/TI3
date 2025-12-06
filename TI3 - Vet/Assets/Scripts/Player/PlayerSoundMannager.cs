using UnityEngine;

public class PlayerSoundMannager : MonoBehaviour
{
    public static PlayerSoundMannager Instance;
    public AudioSource audioSource;
    public AudioClip pop;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayPop()
    {
        if (audioSource != null && pop != null)
            audioSource.PlayOneShot(pop);
    }
}
