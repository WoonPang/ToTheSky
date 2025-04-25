using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetAudio : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = 1f;

        SetLevel(volumeSlider.value);

        volumeSlider.onValueChanged.AddListener(SetLevel);
    }

    public void SetLevel(float sliderVal)
    {
        if (sliderVal <= 0.0001f)
            Mixer.SetFloat("Volume", -80f);
        else
            Mixer.SetFloat("Volume", Mathf.Log10(sliderVal) * 20f);
    }
}