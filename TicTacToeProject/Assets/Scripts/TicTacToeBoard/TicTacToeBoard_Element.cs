using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeBoard_Element : MonoBehaviour {
	//public Sprite[] playerSpriteOptions;
	public SpriteRenderer playerSpriteSlot;
	public SpriteRenderer bgSprite;
	public Vector2 boardPositionAssignment;
	int _currentPlayerNumberOwner = -1;

	public void AssignPlayerSlot(int playerNumber)
	{
		if(GameManager.instance)
		{
			if( playerNumber == -1 || playerNumber >= GameManager.instance.ticTacToeBoardReference.boardViewer.playerSprites.Length)
			{
				playerSpriteSlot.enabled = false;
			}
			else 
			{
				playerSpriteSlot.sprite = GameManager.instance.ticTacToeBoardReference.boardViewer.playerSprites[playerNumber];
				playerSpriteSlot.enabled = true;
				_currentPlayerNumberOwner = playerNumber;
				bgSprite.color = Color.white * 1f;
			}
		}
	}
	public void AssignPosition(Vector2 inputPosition){ boardPositionAssignment = inputPosition; }

	void OnMouseDown()
	{
		if(GameManager.instance) GameManager.instance.ReportTicTacToeTilePressed(boardPositionAssignment);
	}
	void OnMouseEnter()
	{
		if( _currentPlayerNumberOwner == -1 ) 
		{
			bgSprite.color = Color.white * 0.8f;
		}
	}
	void OnMouseExit()
	{
		if( _currentPlayerNumberOwner == -1 ) 
		{
			bgSprite.color = Color.white * 1f;
		}
	}

}
