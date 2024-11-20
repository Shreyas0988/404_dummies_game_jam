using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour {


    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (objectGrabbable == null) {
                float pickUpDistance = 4f;
                Debug.Log("works2");
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask)) {
                    Debug.Log("works1");
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable)) {
                        Debug.Log("works");
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            } else {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}