using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// This script manages the three animations of the buttons
/// </summary>
public class ButtonsAnimationBehavior : MonoBehaviour
{
    #region Properties
    /// <summary> The cylinder animator</summary>
    private Animator animator;

    /// <summary> The idle Animation Clip of the button </summary>
    [SerializeField] private AnimationClip idleAnimation;

    /// <summary> The pressed Animation Clip of the button </summary>
    [SerializeField] private AnimationClip pressedAnimation;

    /// <summary> The unpressed Animation Clip of the button </summary>
    [SerializeField] private AnimationClip unpressedAnimation;


    #endregion

    #region Start
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    #endregion


    #region Methods
    /// <summary>
    /// Plays the idle button animation
    /// </summary>
    public void PlayIdleAnimation()
    {
        animator.Play(idleAnimation.name);
    }


    /// <summary>
    /// Plays the pressed button animation
    /// </summary>
    public void PlayPressedAnimation()
    {
        animator.Play(pressedAnimation.name);
    }


    /// <summary>
    /// Plays the unpressed button animation
    /// </summary>
    public void PlayUnpressedAnimation()
    {
        animator.Play(unpressedAnimation.name);
    }

    #endregion
}
