using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {

    public Vector2 Direction = new Vector2(0, -1);
    public float Speed = 3f;

    private void FixedUpdate() {
        Vector3 move = Direction.normalized * Speed;
        transform.position = transform.position + move * Time.fixedDeltaTime;
    }
}
