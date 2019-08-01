using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    IMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       var horizontal = Input.GetAxisRaw("Horizontal"); 
       var vertical = Input.GetAxisRaw("Vertical");
       movement.Move(vertical, horizontal);
    }
}
