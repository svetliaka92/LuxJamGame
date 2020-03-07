using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffUI : MonoBehaviour
{
    [SerializeField] private Image buffImage;

    public void OnBuffStart(AbilityType type)
    {
        buffImage.gameObject.SetActive(true);
    }

    public void OnBuffExpire()
    {
        buffImage.gameObject.SetActive(false);
    }
}
