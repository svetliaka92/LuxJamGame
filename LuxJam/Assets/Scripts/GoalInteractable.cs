using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Material _shadowMat;
    [SerializeField] private Material _lightMat;

    [SerializeField] private GameObject _crystal;

    private Renderer _rend;

    private bool isEnabled = true;

    private void Start()
    {
        _rend = _crystal.GetComponent<Renderer>();
    }

    public void Hover()
    {
        
    }

    public void Interact()
    {
        if (!isEnabled)
            return;

        isEnabled = false;

        ChangeMat();
    }

    public void StopInteract()
    {
        
    }

    private void ChangeMat()
    {
        LeanTween.value(0, 1, 5f)
                 .setEaseInOutExpo()
                 .setOnUpdate(UpdateMat)
                 .setOnComplete(OnFinish);
    }

    private void OnFinish()
    {
        LeanTween.delayedCall(3f, GameManager.Instance.WinGame);
    }

    private void UpdateMat(float val)
    {
        _rend.material.Lerp(_shadowMat, _lightMat, val);
    }
}
