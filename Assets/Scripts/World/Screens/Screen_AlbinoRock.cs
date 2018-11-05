using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_AlbinoRock : UIScreen {

    public Image rockImage;

    protected override void OnFirstOpen() {
        FightButton.gameObject.SetActive(false);

        rockImage.enabled = true;
        EnqueueDialogue("ges");
        EnqueueDialogue("Lgahs faihsght.");
        EnqueueDialogue("Let's fight.");
    }

    protected override void OnOpen() {
        rockImage.enabled = false;
        EnqueueDialogue("This room is empty.");
    }

    public Button FightButton;

    protected override void OnFinishedDialogue() {
        FightButton.gameObject.SetActive(true);
    }
}
