using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRootMotion : IMovement
{
    [SerializeField]
    Rigidbody body;
    [SerializeField]
    Animator anim;
    [SerializeField]
    float transitionDuration;
    float startForwardSpeed = 0;
    float curForwardSpeed = 0;
    float targetForwardSpeed = 0;
    float curForwardTransitTime = 0;
    bool isTransitionForward = false;

    float startSideSpeed = 0;
    float curSideSpeed = 0;
    float targetSideSpeed = 0;
    float curSideTransitTime = 0;
    bool isTransitionSide = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetForwardSpeed != curForwardSpeed && isTransitionForward == false)
        {
            StartMovingForward();
        }
        if (targetSideSpeed != curSideSpeed && isTransitionSide == false) {
            StartMovingSide();
        }
        if (isTransitionForward)
        {
            TweenForwardSpeedValue();
        }
        if (isTransitionSide)
        {
            TweenSideSpeedValue();
        }
    }
    private void TweenSideSpeedValue()
    {
        if (curSideTransitTime >= transitionDuration)
        {
            SetSideSpeed(targetSideSpeed);
            isTransitionSide = false;
            return;
        }
        var newSpeed = Tweener.EaseInOutQuad(curSideTransitTime, startSideSpeed, targetSideSpeed - startSideSpeed, transitionDuration);
        SetSideSpeed(newSpeed);
        curSideTransitTime += Time.deltaTime;

    }
    private void TweenForwardSpeedValue()
    {
        if (curForwardTransitTime >= transitionDuration)
        {
            SetForwardSpeed(targetForwardSpeed);
            isTransitionForward = false;
            return;
        }
        var newSpeed = Tweener.EaseInOutQuad(curForwardTransitTime, startForwardSpeed, targetForwardSpeed - startForwardSpeed, transitionDuration);
        SetForwardSpeed(newSpeed);
        curForwardTransitTime += Time.deltaTime;
    }
    public void SetForwardSpeed(float value)
    {
        this.curForwardSpeed = value;
        anim.SetFloat("X", this.curForwardSpeed);
    }
    public void SetSideSpeed(float value)
    {
        this.curSideSpeed = value;
        anim.SetFloat("Z", this.curSideSpeed);
    }
    public override void Move(float forward, float side)
    {
        targetForwardSpeed = forward == 0 ? 0 : GetSpeedBasedOnMode();
        targetSideSpeed = side == 0 ? 0 : GetSpeedBasedOnMode();
        targetSideSpeed = side > 0 ? targetSideSpeed : targetSideSpeed * -1;
    }

    private void StartMovingForward()
    {
        startForwardSpeed = anim.GetFloat("X");
        isTransitionForward = true;
        curForwardTransitTime = 0;
    }
    private void StartMovingSide()
    {
        startSideSpeed = anim.GetFloat("Z");
        isTransitionSide = true;
        curSideTransitTime = 0;
    }

    private int GetSpeedBasedOnMode()
    {
        var result = 0;
        switch (moveMode)
        {
            case MovementMode.Walk:
                result = 1;
                break;
            case MovementMode.Run:
                result = 2;
                break;
            default:
                moveMode = MovementMode.Walk;
                break;
        }
        return result;
    }

    public override void SignalJump()
    {
        throw new System.NotImplementedException();
    }
}
