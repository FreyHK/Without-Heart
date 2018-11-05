using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour {

    public const float LaneWidth = 1.2f;

    // Use this for initialization
    void Start () {
		
	}
    
	void Update () {

	}

    public void StartBattle () {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}
