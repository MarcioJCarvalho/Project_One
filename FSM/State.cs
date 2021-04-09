using UnityEngine;
using System.Collections.Generic;

namespace Assets._Scripts.FSM
{
    public class State 
    {
        bool forceExit;
        List<StateAction> fixedUpdateActions;
        List<StateAction> updateActions;
        List<StateAction> lateUpdateActions;

        public delegate void OnEnter();
        public OnEnter onEnter;

        public State(List<StateAction> fixedUpdateActions, List<StateAction> updateActions, List<StateAction> lateUpdateActions)
        {
            this.fixedUpdateActions = fixedUpdateActions;
            this.updateActions = updateActions;
            this.lateUpdateActions = lateUpdateActions;
        }

        /// <summary>
        ///  Correção de percistência
        /// </summary>
        public void FixedTick()
        {
            ExecuteListOfActions(fixedUpdateActions);
        }

        /// <summary>
        /// Percistência
        /// </summary>
        public void Tick()
        {
            ExecuteListOfActions(updateActions);
        }

        /// <summary>
        /// Percistêntia tardia
        /// </summary>
        public void LateTick()
        {
            ExecuteListOfActions(lateUpdateActions);
            forceExit = false;
        }

        void ExecuteListOfActions(List<StateAction> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (forceExit)
                    return;
                forceExit = l[i].Execute();
            }
        }
    }
}
