using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using UnityEngine;
using GoogleARCore;
using UnityEngine.EventSystems;
using  UnityEngine.UI;

public class ArController : MonoBehaviour
{
    public GameObject dotPoint;
    public GameObject markerPoint;

    private TrackableHit hit;

    private Camera fpsCamera;
    
    private Touch touch;
    
    private Pose placementPose; 

    public float YPointFix;

    public bool calculateMarketBool;

    public GameObject[] furniture;

    
    void Start()
    {
        calculateMarketBool = true;
        fpsCamera = Camera.main;
    }

    void Update()
    {
        if(calculateMarketBool == true) {
            CalculateMarker();
            markerPoint.SetActive(true);
        }
        if (calculateMarketBool == false) {
            markerPoint.SetActive(false);
        }

       
    }

    public void CreatePointArCore(int furnitureIndex) {
        YPointFix = placementPose.position.y;

        Instantiate(furniture[furnitureIndex], placementPose.position, placementPose.rotation);
    }

    void CalculateMarker()
    {
        TrackableHitFlags flags = TrackableHitFlags.PlaneWithinBounds | TrackableHitFlags.PlaneWithinPolygon;

        Vector3 origin = fpsCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));

        if(Frame.Raycast(origin.x,origin.y,flags,out hit))
        {
            IntPtr plane = hit.Trackable.m_TrackableNativeHandle;
            if (hit.Trackable.m_NativeSession.PlaneApi.GetPlaneType(plane) == DetectedPlaneType.Vertical)
            {
                markerPoint.transform.eulerAngles = new Vector3(0,0,0);
            }
            else
            {
                markerPoint.transform.eulerAngles = new Vector3(90,0,0);
            }
            
            markerPoint.transform.position = hit.Pose.position;
            placementPose = hit.Pose;

            GameObject markerPointObj = markerPoint.transform.GetChild(0).gameObject;               
            //LineRendererMeasure.Instance.DrawLine(markerPointObj,false);
        }
    }

    private bool IsPointerOverUIObject(Touch touch)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}