using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffUI : MonoBehaviour
{
    [SerializeField] private Image buffImage;

    private float durationPercent = 0f;

    private float durationStart = 0.5f;
    private float durationEnd = 1f;
    private float startFlashFrequency = 0.2f;
    private float endFlashFrequency = 5f;

    private bool isEnabled = false;

    public void OnBuffStart(AbilityType type)
    {
        isEnabled = true;
        buffImage.gameObject.SetActive(true);
    }

    public void OnBuffExpire()
    {
        isEnabled = false;
        buffImage.gameObject.SetActive(false);
    }

    public void UpdateState(float value)
    {
        durationPercent = value;
    }

    private void Update()
    {
        if (!isEnabled)
            return;

        if (durationPercent >= 0.5f)
        {
            float frequency = startFlashFrequency + (endFlashFrequency - startFlashFrequency)
                              * ((durationPercent - durationStart) / (durationEnd - durationStart));

            float imageAlpha = (Mathf.Sin(Time.time * frequency) * 0.5f) + 0.5f;

            Color color = buffImage.color;
            color.a = imageAlpha;
            buffImage.color = color;
        }
        else
        {
            Color color = buffImage.color;
            color.a = 1;
            buffImage.color = color;
        }
    }
}
