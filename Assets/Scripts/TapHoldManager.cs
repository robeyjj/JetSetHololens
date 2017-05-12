using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class TapHoldManager : MonoBehaviour
{
    public static TapHoldManager Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;
    GameObject currentCanPaintShooter;



    bool isSpraying;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        currentCanPaintShooter = GameObject.Find("PaintShooter");

        currentCanPaintShooter.SetActive(false);
        isSpraying = false;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Hold | GestureSettings.Tap);

       
        //recognizer.HoldCompletedEvent += (source, tapCount, ray) =>

        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnSelect");
            }
        };
        recognizer.StartCapturingGestures();
    }


    void EnableSprayPaint()
    {
        
        if ( currentCanPaintShooter != null)
        {
            currentCanPaintShooter.SetActive(true);
        }
    }

    void DisableSprayPaint()
    {
        //GUILayout.Button("Stop Emitting");
    }

    // Update is called once per frame
    void Update()
    {
        
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;
        
        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
            if (isSpraying)
            {
                DisableSprayPaint();
            }
            if (!isSpraying)
            {
                EnableSprayPaint();
            }
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
        
        recognizer.StartCapturingGestures();
    }
}