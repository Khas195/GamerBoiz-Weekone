using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBackSorting : MonoBehaviour
{
    [SerializeField]
    Transform character;
    [SerializeField]
    Transform host;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = host.transform.position;
       if (character.position.y > pos.y) {
           pos.z = character.position.z - 1;
       }  else if ( character.position.y < pos.y){
           pos.z = character.position.z + 1;
       } else {
           pos.z = character.position.z;
       }
       host.transform.position = pos;
    }
}
