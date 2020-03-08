using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    protected Vector3 downScale = new Vector3(0.95f, 0.95f, 0.95f);
    protected Vector3 upScale = Vector3.one;
    protected float scaleTime = 0.3f;
    private bool isEnabled = true;

    private int scaleTweenId = -1;

    private void Awake()
    {
        isEnabled = true;
    }

    public virtual void ClickButton()
    {
        if (!isEnabled)
            return;

        isEnabled = false;
    }

    public void OnPointerDown()
    {
        if (!isEnabled)
            return;

        CancelScaleTween();

        scaleTweenId = LeanTween.scale(gameObject, downScale, scaleTime)
                                .setEaseOutCubic()
                                .setOnComplete(CompleteScaleTween)
                                .uniqueId;
    }

    public void OnPointerUp()
    {
        CancelScaleTween();

        scaleTweenId = LeanTween.scale(gameObject, upScale, scaleTime)
                                .setEaseOutCubic()
                                .setOnComplete(CompleteScaleTween)
                                .uniqueId;
    }

    private void CancelScaleTween()
    {
        if (scaleTweenId == -1)
            return;

        LeanTween.cancel(scaleTweenId);
        scaleTweenId = -1;
    }

    private void CompleteScaleTween()
    {
        scaleTweenId = -1;
    }
}
