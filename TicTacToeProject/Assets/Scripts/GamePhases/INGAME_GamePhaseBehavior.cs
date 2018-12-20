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
			GameManager.instance.ticTacToeBoardReference.Init();
			GameManager.OnTileClicked += TriggerTileClick;
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
    }

	public void TriggerTileClick(Vector2 position)
	{
		Debug.Log("Position: " + position);
		if ( GameManager.instance.ticTacToeBoardReference.PlayerClaimsPosition( (int) currentSubPhase , position) )
		{
			GameManager.instance.ticTacToeBoardReference.boardViewer.PlayerClaimedGridAtPosition( position, (int) currentSubPhase );
		}

	}
}
