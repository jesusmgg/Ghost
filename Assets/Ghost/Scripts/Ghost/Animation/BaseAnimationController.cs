﻿using UnityEngine;

namespace Ghost.Animation
{
    public class BaseAnimationController : BaseComponent
    {
        protected Animator animator;
        protected SpriteRenderer spriteRenderer;

        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }
    }
}