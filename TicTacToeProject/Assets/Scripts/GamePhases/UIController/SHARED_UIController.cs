using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SHARED_UIController : UIController {
    public GameObject topBannerContainer;
    public Button backButton;

    public void SetSharedUIDisplay (SharedUISettings inputSharedSettings)
    {
        topBannerContainer.SetActive(inputSharedSettings.showTopBannerBG);
        backButton.gameObject.SetActive(inputSharedSettings.backButton);
    }
    
}

[System.Serializable]
public class SharedUISettings
{
    public bool showTopBannerBG = true;
    public bool backButton;
}

