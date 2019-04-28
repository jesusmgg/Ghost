using System.Collections.Generic;
using Ghost.Props.Interactable;
using UnityEngine;

namespace Ghost.Mechanics.Enemies
{
    public class AttachToTombs : MonoBehaviour
    {
        public List<Tomb> tombs;

        public bool hasAllTombsDead;

        void Start()
        {
            hasAllTombsDead = false;
        }

        void Update()
        {
            if (!tombs.Exists(x => !x.isDead))
            {
                hasAllTombsDead = true;
            }
        }
    }
}