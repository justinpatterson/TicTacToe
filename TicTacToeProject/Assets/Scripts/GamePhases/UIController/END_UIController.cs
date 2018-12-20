using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class END_UIController : UIController {
    public Text popUpBody;
    public void ReportResults(Results inputResults)
    {
        popUpBody.text =
            "Player " + inputResults.winningPlayerNumber + " Wins!";
    }

}
