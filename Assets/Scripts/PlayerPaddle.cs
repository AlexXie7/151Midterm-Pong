using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//************** use UnityOSC namespace...
using UnityOSC;
//*************

public class PlayerPaddle : Paddle
{
    private Vector2 _direction;
    
    // //************* Need to setup this server dictionary...
    // Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog> ();
    // //*************
    
    // Use this for initialization
    void Start () 
    {
        Application.runInBackground = true; //allows unity to update when not in focus

        //************* Instantiate the OSC Handler...
        OSCHandler.Instance.Init ();
        OSCHandler.Instance.SendMessageToClient ("pd", "/unity/trigger", "ready");
        //*************
    }

    private void Update() {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            _direction = Vector2.up;
        } else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            _direction = Vector2.down;
        } else {
            _direction = Vector2.zero;
        }
    }

    private void FixedUpdate() {
        if(_direction.sqrMagnitude != 0) {
            _rigidbody.AddForce(_direction * this.paddleSpeed);
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
        else if (collision.gameObject.CompareTag("Goal"))
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/colgoal", 1);
        }
    }
}
