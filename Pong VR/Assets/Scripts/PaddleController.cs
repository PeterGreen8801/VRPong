using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaddleController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private ConfigurableJoint joint;
    private Rigidbody paddleRigidbody;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        joint = GetComponent<ConfigurableJoint>();
        paddleRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        joint.connectedBody = paddleRigidbody;
    }

    private void Update()
    {
        if (grabInteractable.isSelected)
        {
            Vector3 newPosition = new Vector3(transform.position.x, grabInteractable.selectingInteractor.transform.position.y, transform.position.z);
            joint.targetPosition = newPosition;
        }
    }
}






