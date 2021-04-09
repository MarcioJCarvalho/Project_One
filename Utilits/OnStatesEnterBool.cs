﻿using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Utilits
{
    public class OnStatesEnterBool : StateMachineBehaviour
    {
        public string boolName;
        public bool status;
        public bool resetOnExit;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(boolName, status);
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (resetOnExit)
                animator.SetBool(boolName, !status);
        }
    }
}