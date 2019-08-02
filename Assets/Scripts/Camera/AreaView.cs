using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaView : MonoBehaviour
{
    [SerializeField]
    List<Transform> objectsInArea;

    [SerializeField]
    CameraFollow cameraFollow;
    [SerializeField]
    CameraZoom cameraZoom;
    [SerializeField]
    float viewTime;
    [SerializeField]
    float zoomFollowPercentage;
    [SerializeField]
    float focusCenterPercentage;
    bool isViewing = false;
    float curTime = 0;

    float cachedZoomFollowPercentage;
    float cachedFocusCenterPercentage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isViewing) {
            curTime += Time.deltaTime;
            if (curTime > viewTime) {
                UnView();
            }
        }
    }
    public void View() {
        if (isViewing) return;
        curTime = 0;
        cameraFollow.Clear(true);
        cameraZoom.Clear(true);
        cachedFocusCenterPercentage = cameraFollow.GetFollowPercentage();
        cachedZoomFollowPercentage= cameraZoom.GetFollowPercentage();
        cameraFollow.SetFollowPercentage(focusCenterPercentage);
        cameraZoom.SetFollowPercentage(zoomFollowPercentage);

        foreach (var obj in objectsInArea)
        {
            cameraFollow.AddEncapsolateObject(obj);
            cameraZoom.AddEncapsolateObject(obj);
        }
        isViewing = true;
    }
    public void UnView() {
        if (isViewing == false) return;
        cameraFollow.Clear(false);
        cameraZoom.Clear(false);
        cameraFollow.SetFollowPercentage(cachedFocusCenterPercentage);
        cameraZoom.SetFollowPercentage(cachedZoomFollowPercentage);
        isViewing = false;
    }
}
