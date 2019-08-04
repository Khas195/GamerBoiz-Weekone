using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RitualCircle : MonoBehaviour
{
    [SerializeField]
    bool doOnce = false;
    [SerializeField]
    List<GameObject> pillarEntities;

    [SerializeField]
    UnityEvent OnAllPillarsTriggered;
    int numOfTriggeredPillars;
    bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        numOfTriggeredPillars = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseNumOfTriggeredPillar() {
        numOfTriggeredPillars ++;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (doOnce && done) {
            return;
        }
        if (other.tag == "Player") {
            if (numOfTriggeredPillars >= pillarEntities.Count ) {
                OnAllPillarsTriggered.Invoke();
                done = true;
            }
        }
    }
}
