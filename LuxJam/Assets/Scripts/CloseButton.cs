using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : GameButton
{
    public override void ClickButton()
    {
        base.ClickButton();

        GameManager.Instance.UnpauseGame();
    }
}
