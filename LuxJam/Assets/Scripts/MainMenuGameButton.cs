using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGameButton : GameButton
{
    public override void ClickButton()
    {
        base.ClickButton();

        // have the game manager load the main menu
        GameManager.Instance.LoadScene("MainMenu");
    }
}
