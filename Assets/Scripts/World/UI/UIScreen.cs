using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class UIScreen : MonoBehaviour {

    bool hasBeenOpened = false;

    //Called by screenmanager
    public void Open () {
        if (!hasBeenOpened) {
            hasBeenOpened = true;
            OnFirstOpen();
        } else
            OnOpen();
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    //Called when screen is opened for the first time
    protected abstract void OnFirstOpen();

    //Called whenever screen is opened
    protected abstract void OnOpen();

    //Give the player options
    protected abstract void OnFinishedDialogue();


    public UIWriteText displayText;

    Queue<string> displayQueue = new Queue<string>();

    protected void EnqueueDialogue (string s) {
        displayQueue.Enqueue(s);
        if (displayQueue.Count == 1)
            showNext = true;
    }

    bool showNext = false;

    private void Update() {
        
        //Player wants to skip
        if (Input.anyKeyDown) {
            showNext = true;
        }
    
        if (displayQueue.Count == 0) {
            if (showNext) {
                //No more to show, open actual screen
                OnFinishedDialogue();
                showNext = false;
            }
            return;
        }
        
        if (displayQueue.Count > 0 && showNext) {
            showNext = false;

            //Display next
            string s = displayQueue.Dequeue();
            displayText.Display(s);
        }
    }


    public GameObject[] buttons;

    private void Awake() {
        HideButtons();
    }

    public void HideButtons () {
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].SetActive(false);
        }
    }

    protected IEnumerator ShowButtons() {
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].SetActive(true);
            yield return new WaitForSeconds(.2f);
        }
    }
}
