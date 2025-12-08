using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class AudioControl : MonoBehaviour
{
    public Slider master, music, sfx;
    public AudioMixer mixer;

    void Start()
    {
        float outValue;
        master.onValueChanged.AddListener((float value) => { VolumeChange("MasterVolume", value); });
        mixer.GetFloat("MasterVolume", out outValue);
        master.value = outValue;

        music.onValueChanged.AddListener((float value) => { VolumeChange("MusicVolume", value); });
        mixer.GetFloat("MusicVolume", out outValue);
        music.value = outValue;

        sfx.onValueChanged.AddListener((float value) => { VolumeChange("SfxVolume", value); });
        mixer.GetFloat("SfxVolume", out outValue);
        sfx.value = outValue;
    }

    void VolumeChange(string param, float value)
    {
        mixer.SetFloat(param, value);
    }

    private void OnDestroy()
    {
        master.onValueChanged.RemoveAllListeners();
        music.onValueChanged.RemoveAllListeners();
        sfx.onValueChanged.RemoveAllListeners();
    }

    private void Update()
    {
        if (!GameManager.Statustutorial() && !GetComponentInChildren<AudioSource>().isPlaying)
        {
            GetComponentInChildren<AudioSource>().Play();
        }
    }
}
