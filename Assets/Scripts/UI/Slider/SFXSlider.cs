using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSlider : BaseSlider
{
     protected override void Start()
    {
        base.Start();
      float currentVolume = AudioManager.Instance.GetVolume(SoundType.SFX);
        slider.value = currentVolume;
    }
    protected override void OnValueChanged(float value)
    {
        AudioManager.Instance.SetVolume(SoundType.SFX, value);
    }
}
