using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMarker : MonoBehaviour {
    
    public LineRenderer lineRenderer;
    public SpriteRenderer CircleSprite;
    public SpriteRenderer IconSprite;
    
    public bool Unlocked { get; private set; }

    [HideInInspector]
    public MapMarker Previous;

    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetUnlocked (bool state, bool instant = false) {
        Unlocked = state;

        CircleSprite.enabled = state;
        if (IconSprite != null)
            IconSprite.enabled = state;

        if (!instant && state && IconSprite != null) {
            StartCoroutine(UnlockedAnimation());
        }
    }

    float lineAnimDuration = 1f;
    float fadeInDuration = .5f;

    IEnumerator UnlockedAnimation () {
        //Hide icon
        IconSprite.color = Color.clear;
        CircleSprite.enabled = false;

        //Draw a line towards this marker
        Vector3 origin = Previous.transform.position;
        Vector3 target = transform.position;

        lineRenderer.positionCount = 2;
        //Set start point
        lineRenderer.SetPosition(0, origin);

        //Move line
        float t = 0f;
        while (t < lineAnimDuration) {
            float p = t / lineAnimDuration;

            Vector3 pos = Vector3.Lerp(origin, target, p);
            lineRenderer.SetPosition(1, pos);

            t += Time.deltaTime;
            yield return null;
        }
        lineRenderer.SetPosition(1, target);

        //Show circle
        CircleSprite.enabled = true;

        //Fade in icon
        t = 0f;
        while (t < fadeInDuration) {
            float a = t / fadeInDuration;
            IconSprite.color = Color.white * a;

            t += Time.deltaTime;
            yield return null;
        }
        IconSprite.color = Color.white;
    }
}
