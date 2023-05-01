using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;

    private void FixedUpdate() {

        if (this.ball.velocity.x > 0.0f) {
            if (this.ball.position.y > this.transform.position.y) {
                _rigidbody.AddForce(Vector2.up * this.paddleSpeed);
            } else if(this.ball.position.y < this.transform.position.y) {
                _rigidbody.AddForce(Vector2.down * this.paddleSpeed);
            }
        } else {
            if (this.transform.position.y > 0.0f){
                _rigidbody.AddForce(Vector2.down * this.paddleSpeed);
            } else if (this.transform.position.y < 0.0f){
                _rigidbody.AddForce(Vector2.up * this.paddleSpeed);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/colwall", 1);
        }
        else if (collision.gameObject.CompareTag("Ball"))
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/colball", 1);
        }
    }
}
