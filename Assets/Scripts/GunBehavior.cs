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

    #region Properties
    /// <summary> The prefab of the bullet </summary>
    [SerializeField] private GameObject _bulletPrefab;

    /// <summary> The point where the bullet will be instantiated </summary>
    [SerializeField] private GameObject _shootingPoint;


    /// <summary>
    /// Rebember the last state of the trigger button so the gun only shoots once every press and not every frame the trigger is pressed
    /// </summary>
    private bool wasLeftTriggerPressed = false;
    private bool wasRightTriggerPressed = false;

    /// <summary> Reference to the audioManager script and game object that contains it </summary>
    [SerializeField] private GameObject _audioManagerObject;
    private AudioManager _audioManager;

    /// <summary> The shooting sound </summary>
    [SerializeField] private AudioClip _shootingSound;

    private XRGrabInteractable grabInteractable;
    private XRNode currentHandNode;

    #endregion

    #region Awake / Start / OnDestroy
    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        //Add listeners to know when the gun is grabbed and released
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void Start()
    {
        _audioManager = _audioManagerObject.GetComponent<AudioManager>();
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    #endregion

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

    #region Methods

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
    /// Instantiates the bullet prefab on the shooting point and calls AudioManager to play the shooting sound
    /// </summary>
    void Shoot()
    {
        Instantiate(_bulletPrefab, _shootingPoint.transform.position, _shootingPoint.transform.rotation);
        _audioManager.PlayAudio(_shootingSound);
    }

    #endregion
}

