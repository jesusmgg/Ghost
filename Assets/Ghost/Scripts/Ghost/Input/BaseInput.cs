﻿using UnityEngine;

namespace Ghost.Input
{
    public abstract class BaseInput : BaseComponent
    {
        public bool useInput = true;
        public Vector2 Direction { get; set; }

        public virtual bool GetButton(string button)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool GetButtonUp(string button)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool GetButtonDown(string button)
        {
            throw new System.NotImplementedException();
        }
    }
}