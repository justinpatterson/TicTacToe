using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class END_UIController : UIController {
    
	//public Image popUpBody_playerIMG;
	public Image[] popUp_playerIMGs;
	public GameObject popUp_Winner_container;
	public GameObject popUp_Draw_container;

	public override void CloseUI ()
	{
		popUp_Draw_container.SetActive(false);
		popUp_Winner_container.SetActive(false);
		base.CloseUI ();
	}


	public void ReportResults(Results inputResults)
    {
		if(inputResults.winningPlayerNumber != -1) 
		{
			Sprite winningPlayerSprite = GameManager.instance.ticTacToeBoardReference.boardViewer.playerSprites[ inputResults.winningPlayerNumber ];
			foreach(Image playerIMG in popUp_playerIMGs) playerIMG.sprite = winningPlayerSprite;
			popUp_Winner_container.SetActive(true);
		}
		else 
		{
			popUp_Draw_container.SetActive(true);
			Debug.Log("container HAS BEEN ENABLED");
		}
    }

}
