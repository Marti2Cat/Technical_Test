using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Manages the gun behavior
/// </summary>
public class GunBehavior : MonoBehaviour
{
    /// <summary> The prefab of the bullet </summary>
    [SerializeField] private GameObject _bulletPrefab;

    /// <summary> The point where the bullet will be instantiated </summary>
    [SerializeField] private GameObject _shootingPoint;


    /// <summary>
    /// Rebember the last state of the trigger button so the gun only shoots once every press and not every frame the trigger is pressed
    /// </summary>
    private bool wasLeftTriggerPressed = false;
    private bool wasRightTriggerPressed = false;


    private XRGrabInteractable grabInteractable;
    private XRNode currentHandNode;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        //Add listeners to know when the gun is grabbed and released
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    void Update()
    {
        //Gets which hand is pressing the trigger button and shoots if it is the same hand that is holding the gun 

        InputDevice leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (leftHand.TryGetFeatureValue(CommonUsages.triggerButton, out bool leftPressed))
        {
            if (leftPressed && !wasLeftTriggerPressed && currentHandNode == XRNode.LeftHand)
            {
                Debug.Log("Trigger IZQUIERDO PRESIONADO (una vez)");
                Shoot();
            }
            wasLeftTriggerPressed = leftPressed;
        }


        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightHand.TryGetFeatureValue(CommonUsages.triggerButton, out bool rightPressed))
        {
            if (rightPressed && !wasRightTriggerPressed && currentHandNode == XRNode.RightHand)
            {
                Debug.Log("Trigger DERECHO PRESIONADO (una vez)");
                Shoot();
            }
            wasRightTriggerPressed = rightPressed;
        }
    }


    /// <summary>
    /// Detects which hand has grabbed the gun
    /// </summary>
    /// <param name="args"> The event data containing the information about the trigger that grabbed the gun </param>
    void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log("¡Objeto agarrado!");
        var interactor = args.interactorObject.transform;

        if (interactor.CompareTag("LeftHand"))
        {
            currentHandNode = XRNode.LeftHand;
            Debug.Log("Agarrado con la mano IZQUIERDA");
        }
        else if (interactor.CompareTag("RightHand"))
        {
            currentHandNode = XRNode.RightHand;
            Debug.Log("Agarrado con la mano DERECHA");
        }
        else
        {
            Debug.LogWarning("No se pudo identificar la mano que agarró el objeto.");
        }
    }

    /// <summary>
    /// Resets the states and clears the hand tracking
    /// </summary>
    /// <param name="args"> The event data that contains information about the interactor that released the gun </param>
    void OnReleased(SelectExitEventArgs args)
    {
        Debug.Log("Objeto soltado");

        wasLeftTriggerPressed = false;
        wasRightTriggerPressed = false;
        currentHandNode = XRNode.HardwareTracker;
    }


    /// <summary>
    /// Instantiates the bullet prefab on the shooting point
    /// </summary>
    void Shoot()
    {
        Instantiate(_bulletPrefab, _shootingPoint.transform.position, _shootingPoint.transform.rotation);
    }
}

