using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonController : MonoBehaviour {

    CanvasGroup group;

	void Start () {
        group = GetComponent<CanvasGroup>();
        Hide();
    }

    public void Show() {
        gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    float fadeInDur = .2f;

    IEnumerator FadeIn() {
        group.alpha = 0f;
        group.interactable = false;

        float t = 0f;
        while (t < fadeInDur) {
            float a = t / fadeInDur;
            group.alpha = a;

            t += Time.deltaTime;
            yield return null;
        }
        group.alpha = 1f;
        group.interactable = true;
    }

    public void Hide () {
        group.alpha = 0;
        group.interactable = false;
        gameObject.SetActive(false);
    }
}
