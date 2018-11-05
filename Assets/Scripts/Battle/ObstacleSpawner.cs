using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public Transform[] lanes = new Transform[3];

    public Transform[] prefabs;

    List<Transform> obstacles = new List<Transform>();

    float destroyPointY = -6f;

    void Start () {
        InvokeRepeating("Spawn", 1f, 1f);
	}
	
	void Update () {


        for (int i = obstacles.Count-1; i >= 0; i--) {
            //Is this out of bounds?
            if (obstacles[i].position.y < destroyPointY) {
                //Destroy.
                Destroy(obstacles[i].gameObject);
                obstacles.RemoveAt(i);
            }
        }
	}

    void Spawn () {
        Transform lane = lanes[Random.Range(0, lanes.Length)];
        Transform prefab = prefabs[Random.Range(0, prefabs.Length)];
        Transform t = Instantiate(prefab, lane.position, Quaternion.identity);
        obstacles.Add(t);
    }
}
