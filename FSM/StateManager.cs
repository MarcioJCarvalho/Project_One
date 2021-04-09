using System.Collections.Generic;
using UnityEngine;
using Assets._Scripts.State_Manager;

namespace Assets._Scripts.FSM
{
    public abstract class StateManager : MonoBehaviour
    {
        // instancia da classe State
        State currentState;
        Dictionary<string, State> allStates = new Dictionary<string, State>();

        [HideInInspector]
        public Transform mTransform;

        private void Start()
        {
            // aqui minha variavel transforme recebe o transforme dela mesmo
            mTransform = this.transform;// transforme do player
            Init();
        }

        #region Metodos abistratos
        /// <summary>
        /// Metodo abstrato inicial chamado no Start
        /// </summary>
        public abstract void Init();

        #endregion

        public void FixedTick()
        {
            if (currentState == null)
                return;

            currentState.FixedTick();
        }

        public void Tick()
        {
            if (currentState == null)
                return;

            currentState.Tick();
        }

        public void LateTick()
        {
            if (currentState == null)
                return;

            currentState.LateTick();
        }

        public void ChangeState(string targetId)
        {
            if (currentState != null)
            {
                //run on exit actions of currentState
            }
            State targetState = GetState(targetId);
            //run on enter actions

            currentState = targetState;
            currentState.onEnter?.Invoke();
        }

        State GetState(string targetId)
        {
            allStates.TryGetValue(targetId, out State returnValue);
            return returnValue;
        }

        protected void RegisterState(string stateId, State state)
        {
            allStates.Add(stateId, state);
        }

    }
}
