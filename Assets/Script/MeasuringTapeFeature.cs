using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasuringTapeFeature : MonoBehaviour
{
    [Range(0.005f, 0.05f)]
    [SerializeField] private float tapeNidth = 0.01f;
    [SerializeField] private OVRInput.Button tapeActionButton;
    [SerializeField] private Material tapeMaterial;
    [SerializeField] private GameObject measurementInfoPrefab;
    [SerializeField] private Transform leftControllerTapeArea;
    [SerializeField] private Transform rightControllerTapeArea;

    private List<GameObject> savedTapeLines = new();
    //JE NE SAIS PAS SI LES CROCHETS SON BON

    private LineRenderer lastTapeLineRenderer;

void Update()
    {
        HandleControllerActions(OVRInput.Controller.LTouch, leftControllerTapeArea);
        HandleControllerActions(OVRInput.Controller.RTouch, rightControllerTapeArea);
    }
    private void HandleControllerActions(OVRInput.Controller controller, Transform tapeArea)
    {
        if(OVRInput.GetDown(tapeActionButton, controller))
        {
           HandleDownAction(tapeArea);
        }
           
        
        if (OVRInput.Get(tapeActionButton, controller))
        {
            HandleHoldAction(tapeArea);
        }
        
            
       
        if (OVRInput.GetUp(tapeActionButton, controller))
        {
            HandleUpAction(tapeArea);
        }
        
           
        
    }
    private void HandleDownAction(Transform tapeArea)
    {
        CreateNewTapeLine(tapeArea.position);
    }
    private void HandleHoldAction(Transform tapeArea)
    {
        lastTapeLineRenderer.SetPosition(1, tapeArea.position);
    }
    private void HandleUpAction(Transform tapeArea)
    {

    }

    private void CreateNewTapeLine(Vector3 intialPosition){
        var newTapeLine = new GameObject($"TapeLine_{savedTapeLines.Count}",
        typeof(LineRenderer));

        lastTapeLineRenderer = newTapeLine.GetComponent<LineRenderer>();
        lastTapeLineRenderer.positionCount = 2;
        lastTapeLineRenderer.startWidth = tapeNidth;
        lastTapeLineRenderer.endWidth = tapeNidth;
        lastTapeLineRenderer.material = tapeMaterial;
        lastTapeLineRenderer.SetPosition(index:0, intialPosition);

        savedTapeLines.Add(newTapeLine);
    }



}
