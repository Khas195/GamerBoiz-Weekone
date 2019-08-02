using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField]
    ChangeColor colorChanger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivatePillar(){
        colorChanger.Highlight();
    }
    public void DeactivatePillar() {
        colorChanger.UnHighlight();
    }
    
}
