using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MapController : MonoBehaviour {
   
    public MapMarker[] markers;

	void Start () {
        //Connect neighbors
        for (int i = 1; i < markers.Length; i++) {
            markers[i].Previous = markers[i - 1];
            bool unlocked = i <= PlayerProgress.LevelIndex;
            markers[i].SetUnlocked(unlocked, true);
        }

        FillProgress();
        Invoke("UnlockMarker", 2f);
    }
	
    void UnlockMarker () {
        PlayerProgress.LevelIndex++;

        //Show marker
        markers[PlayerProgress.LevelIndex].SetUnlocked(true);
    }

    void FillProgress () {
        //Starts at second marker
        for (int i = 1; i < markers.Length; i++) {
            if (markers[i].Unlocked) {
                Vector3[] positions = new Vector3[2];
                positions[0] = markers[i-1].transform.position;
                positions[1] = markers[i].transform.position;

                markers[i].lineRenderer.SetPositions(positions);
            }
        }

    }
}
