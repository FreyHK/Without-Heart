using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_Introduction : UIScreen {

    protected override void OnFirstOpen() {
        StartCoroutine(RunDialogue());
    }

    public Image playerImage;
    public UIButtonController[] nameButtons;
    public UIButtonController confirmButton;
    public UIButtonController noHeartButton;
    public UIButtonController readyButton;

    IEnumerator RunDialogue () {
        playerImage.color = Color.clear;

        yield return StartCoroutine(DisplayLine("Hi."));

        yield return StartCoroutine(DisplayLine("What's your name?"));

        //Show buttons
        for (int i = 0; i < nameButtons.Length; i++)
            nameButtons[i].Show();

        //Wait for player input
        while (dialogueIndex <= 0) {
            yield return null;
        }

        //Hide buttons
        for (int i = 0; i < nameButtons.Length; i++)
            nameButtons[i].Hide();

        playerImage.color = Color.white;
        yield return StartCoroutine(DisplayLine("Is this you?"));

        confirmButton.Show();

        //Wait for player input
        while (dialogueIndex <= 1) {
            yield return null;
        }

        confirmButton.Hide();

        yield return StartCoroutine(DisplayLine("Why are you here?"));
        noHeartButton.Show();

        //Wait for player input
        while (dialogueIndex <= 2) {
            yield return null;
        }

        noHeartButton.Hide();

        yield return StartCoroutine(DisplayLine("Don't worry. You'll find one soon."));
        /*
        yield return StartCoroutine(DisplayLine("Are you ready to start?"));

        readyButton.Show();

        //Wait for player input
        while (dialogueIndex <= 3) {
            yield return null;
        }
        */

        //Close this screen
        Close();
    }

    IEnumerator DisplayLine (string s) {
        displayText.Display(s);

        //Wait for player 
        while (!Input.anyKeyDown && displayText.IsWriting) {
            yield return null;
        }
        yield return new WaitForSecondsRealtime(1f);
    }

    int dialogueIndex = 0;
    
    public void OnAnswered () {
        dialogueIndex++;
    }

    protected override void OnOpen() {
        //Doesn't happen for this screen
    }

    protected override void OnFinishedDialogue() {
        //Doesn't happen for this screen
    }
}
