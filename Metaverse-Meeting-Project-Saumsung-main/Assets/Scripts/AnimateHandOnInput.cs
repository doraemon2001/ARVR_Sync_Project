using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    // pinch animation
    public InputActionProperty pinchAnimationAction; //takes input the vr front trigger

    // grip animation
    public InputActionProperty gripAnimationAction; //takes input from vr hold trigger
    
    public Animator handAnimator; //hand animator to object when interacting with trigger
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
        //UnityEngine.Debug.Log(triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
