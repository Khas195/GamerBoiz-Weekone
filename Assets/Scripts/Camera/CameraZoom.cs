﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    Camera host;
    [SerializeField]
    List<Transform> encapsulatedTargets;
    [SerializeField]
    private Transform character;

    [SerializeField]
    float minZoom;
    [SerializeField]
    float maxZoom;
    [SerializeField]
    [Tooltip("Each frame the camera move x percentage closer to the target")]
    float followPercentage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var greatestDistance = GetGreatestDistance(encapsulatedTargets);
        var clampedZoomValue = Mathf.Clamp(greatestDistance, minZoom, maxZoom);
        Definition.CameraDebug("Clamped Zoom size : " + clampedZoomValue);
        host.orthographicSize = Ultilities.CalculateAsymptoticAverage(host.orthographicSize, clampedZoomValue, followPercentage);

    }

    public void Clear(bool clearPlayer)
    {
        encapsulatedTargets.Clear();
        if (clearPlayer == false) {
            encapsulatedTargets.Add(character);
        }
    }

    public void AddEncapsolateObject(Transform obj)
    {
        encapsulatedTargets.Add(obj);
    }

    float GetGreatestDistance(List<Transform> encapsulatedTargets)
    {
        if (encapsulatedTargets.Count <= 1) {
            return 0;
        }
        var bounds = new Bounds();
        foreach (var target in encapsulatedTargets)
        {
            bounds.Encapsulate(target.position);
        }
        var result  = bounds.size.x < bounds.size.y ? bounds.size.y : bounds.size.x;
        Definition.CameraDebug("Greatest distance between focus objects: " + result);
        return result;
    }
}
