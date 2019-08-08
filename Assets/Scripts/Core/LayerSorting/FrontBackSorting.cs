using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBackSorting : MonoBehaviour
{
    [SerializeField]
    Transform host;
    [SerializeField]
    bool useSelfAsHost;
    // Start is called before the first frame update
    void Start()
    {
        if (useSelfAsHost) {
            host = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public Vector3 GetHostPosition()
    {
        return host.position;
    }

    public void SetHostPosition(Vector3 pos)
    {
        host.transform.position = pos;
    }
}
