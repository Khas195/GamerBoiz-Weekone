using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : IMovement 
{
    [SerializeField]
    Rigidbody2D body2D = null;
    [SerializeField]
    float timeUntilMaxSpeed = 0.2f;
    float currentSpeed;
    bool inMotion = false;
    float acceleration = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (this.data == null) {
            Definition.InitalizeErrors("Move Data is null in " + this);
        }
        
    }
    void Update()
    {
        if (inMotion == true && currentSpeed < data.runSpeed) {
            currentSpeed += acceleration * Time.deltaTime;
        } else if (inMotion == false && currentSpeed > 0)
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }
    }
    public override void Move(float forward, float side)
    {
        acceleration = data.runSpeed / timeUntilMaxSpeed;
        if (forward != 0 || side != 0) {
            inMotion = true;
        } else {
            inMotion = false;
        }
        var vel = new Vector3();
        vel.y = forward * currentSpeed * Time.deltaTime;
        vel.x = side * currentSpeed * Time.deltaTime;
        body2D.MovePosition(body2D.transform.position + vel );
    }
    public override void SignalJump()
    {
        return;
    }
}
