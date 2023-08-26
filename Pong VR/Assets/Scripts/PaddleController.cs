using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaddleController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody paddleRigidbody;

    private Vector3 originalPosition;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        paddleRigidbody = GetComponent<Rigidbody>();

        originalPosition = transform.position;
    }

    private void Update()
    {
        if (grabInteractable.isSelected)
        {
            // Get the current position of the XR Ray Interactor
            Vector3 interactorPosition = grabInteractable.selectingInteractor.transform.position;

            // Restrict paddle movement to the Y-axis only
            Vector3 newPosition = new Vector3(originalPosition.x, interactorPosition.y, originalPosition.z);

            // Update the position of the paddle Rigidbody
            paddleRigidbody.MovePosition(newPosition);
        }
    }
}


