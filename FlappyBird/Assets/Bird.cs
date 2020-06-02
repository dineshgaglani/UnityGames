using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initPosition;
    private bool _isLaunched;
    private float _idleTime;

    [SerializeField] private float _force = 100;
    private void Awake() {
        _initPosition = transform.position;
        _isLaunched = false;
    }

    private void Update() {

        if(_isLaunched && GetComponent<Rigidbody2D>().velocity.magnitude < 0.1f)
        {
            _idleTime += Time.deltaTime;
        }

       if (Mathf.Abs(transform.position.x) > 15 
            || Mathf.Abs(transform.position.y) > 5
            || _idleTime > 3) {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }

        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, _initPosition);
        
    }

    private void OnMouseDown() {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp() {
        GetComponent<SpriteRenderer>().color = Color.white;

       
        Rigidbody2D bird = GetComponent<Rigidbody2D>();
        Vector2 forceOnBird = new Vector2(_initPosition.x - transform.position.x, _initPosition.y - transform.position.y);
        Debug.Log("strength: " + _force);
        Debug.Log("force on bird: " + forceOnBird);
        bird.AddForce(forceOnBird * _force);
        bird.gravityScale = 1;
        _isLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag() {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
        GetComponent<LineRenderer>().enabled = true;
    }
}
