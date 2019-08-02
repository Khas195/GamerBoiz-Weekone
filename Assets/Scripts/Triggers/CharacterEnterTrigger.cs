using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEnterTrigger : MonoBehaviour
{
    [SerializeField]
    UnityEvent characterEntered;
    [SerializeField]
    UnityEvent characterLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            characterEntered.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            characterLeft.Invoke();
        }
    }
}
