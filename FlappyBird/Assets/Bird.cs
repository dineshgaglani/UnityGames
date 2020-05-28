using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Vector3 _initPosition;
    private bool _isDragStart;
    private void awake() {
        _initPosition = transform.position;
        _isDragStart = false;
    }

    private void update() {

    }

    private void OnMouseDown() {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp() {
        GetComponent<SpriteRenderer>().color = Color.white;

        if (_isDragStart) {
            Rigidbody2D bird = GetComponent<Rigidbody2D>();
            Vector2 forceOnBird = new Vector2(_initPosition.x - transform.position.x, _initPosition.y - transform.position.y);
            bird.AddForce(forceOnBird * 200);
            bird.gravityScale = 1;
        }
        
    }

    private void OnMouseDrag() {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
        _isDragStart = true;
    }
}
