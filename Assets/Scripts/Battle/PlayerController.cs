using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D body;

	void Start () {
        currentLane = 0;
        transform.position = new Vector3(currentLane, transform.position.y);
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Move(1);
        }else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Move(-1);
        }
    }

    bool moving = false;

    void Move(int dir) {
        if (moving)
            return;

        currentLane += dir;
        currentLane = Mathf.Clamp(currentLane, -1, 1);
        moving = true;
    }

    int currentLane;

    float moveSpeed = 10f;

    Vector2 curVelocity = Vector2.zero;


    private void FixedUpdate() {
        if (!moving)
            return;

        Vector2 target = new Vector2(currentLane * BattleController.LaneWidth, transform.position.y);
        Vector2 newpos = Vector2.MoveTowards(body.position, target, moveSpeed * Time.fixedDeltaTime);
        body.MovePosition(newpos);

        if (transform.position.x == target.x)
            moving = false;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Obstacle") {
            print("Player died.");
        }
    }
}
