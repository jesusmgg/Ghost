using System;
using System.Collections.Generic;
using SpriterDotNetUnity;
using UnityEngine;

namespace Ghost.Animation
{
    public class SpriterAnimationController : MonoBehaviour
    {
        public SpriterState spriterState = SpriterState.Idle;
        public float transitionTime = 250.0f;

        SpriterState currentSpriterState;
        
        UnityAnimator spriterAnimator;
        
        void Start()
        {
            spriterAnimator = GetComponentInChildren<SpriterDotNetBehaviour>().Animator;

            currentSpriterState = spriterState;
            
            try
            {
                spriterAnimator.Transition(Enum.GetName(spriterState.GetType(), spriterState), transitionTime);
            }
            catch (KeyNotFoundException)
            {
            }
        }

        void Update()
        {
            if (spriterState != currentSpriterState)
            {
                try
                {
                    spriterAnimator.Transition(Enum.GetName(spriterState.GetType(), spriterState), transitionTime);
                }
                catch (KeyNotFoundException)
                {
                }
                currentSpriterState = spriterState;
            }
        }
    }

    public enum SpriterState
    {
        Idle,
        Walking,
        JumpStart,
        JumpMid,
        JumpFall,
        JumpLand,
        Using,
        Running,
        Throwing,
        Dying
    }
}