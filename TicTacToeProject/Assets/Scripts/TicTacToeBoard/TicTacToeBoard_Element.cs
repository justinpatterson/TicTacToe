using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeBoard_Element : MonoBehaviour {
	public Sprite[] playerSpriteOptions;
	public SpriteRenderer playerSpriteSlot;
	public Vector2 boardPositionAssignment;


	public void AssignPlayerSlot(int playerNumber)
	{
		if( playerNumber == -1 || playerNumber >= playerSpriteOptions.Length)
		{
			playerSpriteSlot.enabled = false;
		}
		else 
		{
			playerSpriteSlot.sprite = playerSpriteOptions[playerNumber];
			playerSpriteSlot.enabled = true;
		}
	}
	public void AssignPosition(Vector2 inputPosition){ boardPositionAssignment = inputPosition; }

	void OnMouseDown()
	{
		if(GameManager.instance) GameManager.instance.ReportTicTacToeTilePressed(boardPositionAssignment);
	}
	void OnMouseOver()
	{
	
	}
	void OnMouseExit()
	{
		
	}

}
