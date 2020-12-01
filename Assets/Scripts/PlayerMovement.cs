using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    Rigidbody2D rigidbody;
    public Transform Limite;
    Limit playerLimit;
    public float MaxMovementSpeed;



    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        playerLimit = new Limit(Limite.GetChild(0).position.y, Limite.GetChild(1).position.y, Limite.GetChild(2).position.x, Limite.GetChild(3).position.x);


    }
	
	// Update is called once per frame
	void Update () {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = mousePos;
        Vector2 clamedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerLimit.Left, playerLimit.Right), Mathf.Clamp(mousePos.y, playerLimit.Down, playerLimit.Up));
        
        rigidbody.MovePosition(Vector2.MoveTowards(rigidbody.position,clamedMousePos,MaxMovementSpeed*Time.fixedDeltaTime));
    }
}
