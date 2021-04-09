using System.Collections;
using UnityEngine;
using Assets._Scripts.FSM;
using Assets._Scripts.State_Manager;


namespace Assets._Scripts.State_Action
{
    public class MonitorInteratingAnimation : StateAction
    {
        CharacterStateManager states;
        string targetBool;
        string targetState;

        public MonitorInteratingAnimation(CharacterStateManager characterStateManager, string targetBool, string targetState)
        {
            states = characterStateManager;
            this.targetBool = targetBool;
            this.targetState = targetState;
        }
        public override bool Execute()
        {
            bool isInteracting = states.anim.GetBool(targetBool);

            if (isInteracting)
            {
                return false;
            }
            else
            {
                states.ChangeState(targetState);

                return true;
            }
        }


    }
}