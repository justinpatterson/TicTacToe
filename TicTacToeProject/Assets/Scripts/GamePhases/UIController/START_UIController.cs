using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class START_UIController : UIController {
    public Button startGameButton;

    public override void OpenUI()
    {
        base.OpenUI();
        if (GameManager.instance && startGameButton)
        {
            startGameButton.onClick.RemoveAllListeners();
            startGameButton.onClick.AddListener(() => GameManager.instance.ReportGameStartPressed());
        }
    }
    public override void CloseUI()
    {
        base.CloseUI();
    }
}
