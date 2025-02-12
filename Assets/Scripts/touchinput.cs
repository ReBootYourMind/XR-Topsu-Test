using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class touchinput : MonoBehaviour
{
    [SerializeField] private TMP_Text debubtext;
    [SerializeField] private GameObject ballprefab;
    private ARRaycastManager arrcm;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    TrackableType trackableTypes = TrackableType.PlaneWithinPolygon;

    private void Start()
    {
        arrcm = GetComponent<ARRaycastManager>();
    }

    public void SingleTap(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            var touchPos = ctx.ReadValue<Vector2>();
            debubtext.text = touchPos.ToString();

            if (arrcm.Raycast(touchPos, hits, trackableTypes))
            {
                var ball = Instantiate(ballprefab, hits[0].pose.position, new Quaternion());
            }
        }
    }

}
