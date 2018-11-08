using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//FIXME UIWriteText is a terrible name
public class UIWriteText : MonoBehaviour {

    TextMeshProUGUI text;

    private void Awake() {
        IsWriting = false;
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Display (string s) {
        StopAllCoroutines();
        StartCoroutine(DisplayDescription(s));
    }

    public bool IsWriting { get; private set; }

    float lettterDelay = .025f;

    IEnumerator DisplayDescription(string finalStr) {
        IsWriting = true;

        char[] chars = finalStr.ToCharArray();
        string s = "";
        
        for (int i = 0; i < chars.Length; i++) {
            s += chars[i];
            text.text = s;
            yield return new WaitForSeconds(lettterDelay);
        }
        IsWriting = false;
    }
}
