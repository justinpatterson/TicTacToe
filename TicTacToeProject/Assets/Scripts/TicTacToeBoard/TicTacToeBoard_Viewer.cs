using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeBoard_Viewer : MonoBehaviour {
	GameObject _boardContainer;
	public GameObject gridElementPrefab;
	Dictionary <Vector2, TicTacToeBoard_Element> _boardElements = new Dictionary<Vector2, TicTacToeBoard_Element>();

	public void GenerateBoardGridElements(Dictionary<Vector2, int> inputBoard)
	{
		if(!_boardContainer) 
		{
			_boardContainer = new GameObject();
			_boardContainer.name = "boardContainer";
		}

		_boardElements.Clear();

		//YUCK fix this
		foreach( Transform t in _boardContainer.transform ) {Destroy(t.gameObject);}

		foreach(Vector2 position in inputBoard.Keys)
		{
			GameObject newGridElement = Instantiate( gridElementPrefab, position, Quaternion.identity );
			newGridElement.transform.SetParent(_boardContainer.transform);
			if(newGridElement.GetComponent<TicTacToeBoard_Element>())
			{
				_boardElements.Add( position, newGridElement.GetComponent<TicTacToeBoard_Element>());
				_boardElements[position].AssignPlayerSlot(-1);
				_boardElements[position].AssignPosition(position);
			}
		}
	}
	public void PlayerClaimedGridAtPosition( Vector2 inputPosition, int inputPlayerNubmer)
	{
		if(_boardElements.ContainsKey(inputPosition)) 
			_boardElements[inputPosition].AssignPlayerSlot(inputPlayerNubmer);
	}
}
