using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INGAME_GamePhaseBehavior : GamePhaseBehavior
{
    public enum InGameSubPhases { player1_turn, player2_turn }
    public InGameSubPhases currentSubPhase = InGameSubPhases.player1_turn;

    public override void StartPhase()
    {
        base.StartPhase();

		if (GameManager.instance)
		{
            Camera.main.transform.position = new Vector3
                (
                ((float)GameManager.instance.ticTacToeBoardReference.width) / 2f,
                 ((float)GameManager.instance.ticTacToeBoardReference.width) / 2f,
                Camera.main.transform.position.z
                );
			GameManager.instance.ticTacToeBoardReference.Init();
			GameManager.OnTileClicked += TriggerTileClick;

            GameManager.OnBackClicked += TriggerBackClick;
		}
    }
    public override void UpdatePhase()
    {
        base.UpdatePhase();

    }
    public override void EndPhase()
    {
        base.EndPhase();
		GameManager.OnTileClicked -= TriggerTileClick;
        GameManager.OnBackClicked -= TriggerBackClick;
    }

	public void TriggerTileClick(Vector2 position)
	{
		switch(currentSubPhase)
		{
		case InGameSubPhases.player1_turn:
            Debug.Log("Position: " + position);
			if ( GameManager.instance.ticTacToeBoardReference.PlayerClaimsPosition( 0, position) )
			{
				GameManager.instance.ticTacToeBoardReference.boardViewer.PlayerClaimedGridAtPosition( 0, position );
                if (GameManager.instance.ticTacToeBoardReference.CheckWinState())
                {
                    GameManager.instance.TriggerResultsGeneration(0);
                    GameManager.instance.TriggerPhaseTransition(GameManager.GamePhases.end);
                }
                currentSubPhase = InGameSubPhases.player2_turn;
            }
                
			break;
		case InGameSubPhases.player2_turn:
            Debug.Log("Position: " + position);
            if (GameManager.instance.ticTacToeBoardReference.PlayerClaimsPosition(1, position))
            {
                GameManager.instance.ticTacToeBoardReference.boardViewer.PlayerClaimedGridAtPosition(1, position);
                if (GameManager.instance.ticTacToeBoardReference.CheckWinState())
                {
                    GameManager.instance.TriggerResultsGeneration(1);
                    GameManager.instance.TriggerPhaseTransition(GameManager.GamePhases.end);
                }
                currentSubPhase = InGameSubPhases.player1_turn;
            }
            break;
		}
	}
    public void TriggerBackClick()
    {
        GameManager.instance.ticTacToeBoardReference.ClearBoard();
        GameManager.instance.TriggerPhaseTransition(GameManager.GamePhases.start);
    }
}
