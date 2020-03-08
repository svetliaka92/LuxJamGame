using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameButton : GameButton
{
    public override void ClickButton()
    {
        base.ClickButton();

        // have the game manager exit the game
        GameManager.Instance.QuitGame();
    }
}
