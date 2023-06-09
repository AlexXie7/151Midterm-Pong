using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed = 200.0f;
    private Rigidbody2D _rigidbody;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        ResetBall();
    }

    private void AddStartingForce() {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) :
                                        Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x,y);
        _rigidbody.AddForce(direction * this.ballSpeed);
    }

    public void AddForce(Vector2 force){
        _rigidbody.AddForce(force);
    }

    public void ResetBall(){
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;

        AddStartingForce();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/ballcolwall", 1);
        }
    }
}
