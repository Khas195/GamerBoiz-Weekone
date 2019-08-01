using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform host;
    [SerializeField]
    List<Transform> targetsFollow;

    [SerializeField]
    [Tooltip("Each frame the camera move x percentage closer to the target")]
    float followPercentage = 0.02f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetPos = GetCenterPosition(targetsFollow); 

        var hostPos = host.position;

        hostPos.x = this.CalculateAsymptoticAverage(hostPos.x, targetPos.x, followPercentage);
        hostPos.y = this.CalculateAsymptoticAverage(hostPos.y, targetPos.y, followPercentage);
        host.transform.position = hostPos;
    }

    private Vector3 GetCenterPosition(List<Transform> listOfTargets)
    {
        var bounds = new Bounds(listOfTargets[0].position, Vector3.zero);
        foreach (var target in listOfTargets)
        {
            bounds.Encapsulate(target.position);
        }
        return bounds.center;
    }

    public float CalculateAsymptoticAverage( float value, float target, float percentage) {
        var result = 0.0f;
        result = (1 - percentage) * value + percentage * target;
        return result;
    }
}
