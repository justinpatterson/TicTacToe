using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TicTacToeBoardController))]
public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public enum GamePhases { init, start, inGame, end, restart }
    public GamePhases currentPhase = GamePhases.init;
    public GamePhaseBehavior[] gamePhaseBehaviors;
    public TicTacToeBoardController ticTacToeBoardReference;

    GamePhaseBehavior _currentPhaseBehavior;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (!ticTacToeBoardReference) ticTacToeBoardReference = GetComponent<TicTacToeBoardController>();
        TriggerPhaseTransition(GamePhases.init);
        TriggerPhaseTransition(GamePhases.start);
    }

    void Update()
    {
        if (_currentPhaseBehavior) _currentPhaseBehavior.UpdatePhase();
    }

    public void TriggerPhaseTransition(GamePhases inputPhase)
    {

        if (_currentPhaseBehavior)
        {
            _currentPhaseBehavior.EndPhase();
        }

        foreach (GamePhaseBehavior gpb in gamePhaseBehaviors)
        {
            if (gpb.phase == inputPhase)
            {
                gpb.StartPhase();
                _currentPhaseBehavior = gpb;
            }
        }
    }

    public void ReportGameStartPressed()
    {
        TriggerPhaseTransition(GamePhases.inGame);
    }
    
}
