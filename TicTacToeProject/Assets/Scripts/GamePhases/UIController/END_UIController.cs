using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class END_UIController : UIController {
    
	//public Image popUpBody_playerIMG;
	public Image[] popUp_playerIMGs;
    
	public void ReportResults(Results inputResults)
    {
		Sprite winningPlayerSprite = GameManager.instance.ticTacToeBoardReference.boardViewer.playerSprites[ inputResults.winningPlayerNumber ];
		foreach(Image playerIMG in popUp_playerIMGs) playerIMG.sprite = winningPlayerSprite;
    }

}
