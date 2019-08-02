using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform host;
    [SerializeField]
    List<Transform> encapsolatedTarget;
    [SerializeField]
    Transform character;

    [SerializeField]
    [Tooltip("Each frame the camera move x percentage closer to the target")]
    float followPercentage = 0.02f;
    
    // Start is called before the first frame update
    void Start()
    {
        encapsolatedTarget.Add(character);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetPos = GetCenterPosition(encapsolatedTarget); 

        var hostPos = host.position;

        hostPos.x = Ultilities.CalculateAsymptoticAverage(hostPos.x, targetPos.x, followPercentage);
        hostPos.y = Ultilities.CalculateAsymptoticAverage(hostPos.y, targetPos.y, followPercentage);
        host.transform.position = hostPos;
    }

    public void SetFollowPercentage(float value)
    {
        followPercentage = value;
    }

    public void Clear(bool clearPlayer)
    {
        encapsolatedTarget.Clear();
        if (clearPlayer == false) {
            encapsolatedTarget.Add(character);
        }
    }

    public float GetFollowPercentage()
    {
        return followPercentage;
    }

    public void AddEncapsolateObject(Transform obj)
    {
        this.encapsolatedTarget.Add(obj);
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

}
