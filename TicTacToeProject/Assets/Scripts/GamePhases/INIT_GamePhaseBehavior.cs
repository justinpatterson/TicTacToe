using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INIT_GamePhaseBehavior : GamePhaseBehavior {

    public override void StartPhase()
    {
        base.StartPhase();
        if (GameManager.instance)
        {
            GameManager.instance.ticTacToeBoardReference.Init();
        }
    }

    public override void UpdatePhase()
    {
        base.UpdatePhase();
    }

    public override void EndPhase()
    {
        base.EndPhase();
    }

}
