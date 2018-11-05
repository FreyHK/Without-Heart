using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public Renderer backgroundRenderer;

    float scrollAcceleration = .3f;
    float scrollSpeed = 3f;
    float yScroll = 0f;

    void Update() {
        scrollSpeed += scrollAcceleration * Time.deltaTime;
        yScroll += Time.deltaTime * scrollSpeed / 4;
        yScroll = yScroll % 1f;
        backgroundRenderer.material.mainTextureOffset = new Vector2(0, yScroll);
    }
}
