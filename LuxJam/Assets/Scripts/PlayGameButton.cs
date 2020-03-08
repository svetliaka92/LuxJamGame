using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameButton : GameButton
{
    public override void ClickButton()
    {
        base.ClickButton();

        // have the game manager load the game
        GameManager.Instance.LoadScene("Level01");
    }
}
