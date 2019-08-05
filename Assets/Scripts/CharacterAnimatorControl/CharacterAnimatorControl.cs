using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorControl : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    [SerializeField]
    Movement2D movement2d;
    [SerializeField]
    GameObject character;
    [SerializeField]
    bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("bWalking", movement2d.IsInMotion());
        if (movement2d.GetSideInput() > 0 && isFacingRight == false)
        {
            Flip();
        }
        else if (movement2d.GetSideInput() < 0 && isFacingRight == true)
        {
            Flip();
        }
    }
    void Flip()
    {
        var scale = character.transform.localScale;
        scale.x = scale.x * -1;
        character.transform.localScale = scale;
        isFacingRight = !isFacingRight;
    }
}
