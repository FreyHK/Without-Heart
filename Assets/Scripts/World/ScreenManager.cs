using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {

    public Transform canvasTransform;
    public UIScreen startScreen;

    UIScreen[] screens;

    void Start () {
        screens = FindObjectsOfType<UIScreen>();

        //Hide all screens
        for (int i = 0; i < screens.Length; i++) {
            screens[i].gameObject.SetActive(false);
        }
        //Open default screen
        OpenScreen(startScreen);
    }

    public void OpenScreen (UIScreen screen) {
        //Hide all screens
        for (int i = 0; i < screens.Length; i++) {
            screens[i].gameObject.SetActive(false);
        }

        screen.gameObject.SetActive(true);
        //Show in front of other screens
        screen.transform.SetAsLastSibling();
        screen.Open();
    }
}
