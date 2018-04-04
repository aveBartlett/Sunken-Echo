using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform ObjOfInterest;

    readonly Vector3 offSetFromObj = new Vector3(0, 0, -10);

    public float followDelay = 0.1f;
    Vector3 cameraReactPosition;

    // LateUpdate to make sure everything is captured in the camera
    void FixedUpdate()
    {
        cameraReactPosition = ObjOfInterest.position + offSetFromObj;
        //float YPos = yGuideHeight + ((yGuideHeight - cameraReactPosition.y) * 0.8f);
        //cameraFocus.localPosition = cameraFocus.position;//new Vector3(cameraFocus.localPosition.x, YPos, cameraFocus.localPosition.z);
        //float XPos = Mathf.Lerp(transform.position.x, cameraReactPosition.x, followDelay);
        this.transform.position = Vector3.Lerp(transform.position, cameraReactPosition, followDelay);
    }
}
