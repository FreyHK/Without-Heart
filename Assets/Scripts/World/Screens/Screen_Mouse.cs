using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Mouse : UIScreen {

    protected override void OnFirstOpen() {
        EnqueueDialogue("Hello?");
        EnqueueDialogue("...");
        EnqueueDialogue("Who are you...?");
        EnqueueDialogue("My name is Pablo");
    }

    protected override void OnOpen() {
        EnqueueDialogue("Hello again");
    }

    protected override void OnFinishedDialogue() {
        StartCoroutine(ShowButtons());
    }
}
