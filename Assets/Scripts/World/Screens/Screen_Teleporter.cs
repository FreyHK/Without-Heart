using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Teleporter : UIScreen {

    protected override void OnFirstOpen() {
        EnqueueDialogue("Welcome. I was created to test the game.");
        EnqueueDialogue("If you are not the developer then you shouldn't be able to see this screen.");
        EnqueueDialogue("Whoops.");
        EnqueueDialogue("Choose where you want to go.");
    }

    protected override void OnOpen() {
        EnqueueDialogue("It is I, the magical card of teleportation.");
    }

    protected override void OnFinishedDialogue() {
        StartCoroutine(ShowButtons());
    }
}
