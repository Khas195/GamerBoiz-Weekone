using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pillar : MonoBehaviour
{
    [SerializeField]
    ChangeColor colorChanger;
    [SerializeField]
    UnityEvent OnPillarActivated;
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
        OnPillarActivated.Invoke();
    }
    public void DeactivatePillar() {
        colorChanger.UnHighlight();
    }
    
}
