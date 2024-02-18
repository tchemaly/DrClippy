using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using TMPro;

public class PapersInputManager : MonoBehaviour
{
    [SerializeField]
    Transform m_InputAxisTransform;
    public GameObject displayText;

    void OnEnable()
    {
        // enable enhanced touch support to use active touches for properly pooling input phases
        EnhancedTouchSupport.Enable();
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        var activeTouches = Touch.activeTouches;

        if (activeTouches.Count > 0)
        {
            var primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
            if (activeTouches[0].phase == TouchPhase.Began)
            {
                // allow balloons to be popped with a poke or indirect pinch
                if (primaryTouchData.Kind == SpatialPointerKind.IndirectPinch || primaryTouchData.Kind == SpatialPointerKind.Touch)
                {
                    var nodeObject = primaryTouchData.targetObject;
                    if (nodeObject != null)
                    {
                        //Debug.Log("a node has been clicked");
                        displayText.GetComponentInChildren<TMP_Text>().text=nodeObject.gameObject.GetComponentInChildren<TMP_Text>().text;
                    }
                }

                // update input gizmo
                m_InputAxisTransform.SetPositionAndRotation(primaryTouchData.interactionPosition, primaryTouchData.inputDeviceRotation);
            }

            // visualize input gizmo while input is maintained
            if (activeTouches[0].phase == TouchPhase.Moved)
            {
                m_InputAxisTransform.SetPositionAndRotation(primaryTouchData.interactionPosition, primaryTouchData.inputDeviceRotation);
            }
        }
    }
}
