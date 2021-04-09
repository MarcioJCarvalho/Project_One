using System.Collections;
using UnityEngine;
using Assets._Scripts.State_Manager;

namespace Assets._Scripts.Utilits
{
    /// <summary>
    /// AnimatorHook é uma classe ultilitaria responsavel por executar as animações conforme 
    /// as requisições do controlador(Player) ou seja você.
    /// </summary>
    public class AnimatorHook : MonoBehaviour
    {
        /// <summary>
        /// states uma instância da classe CharacterStateManager
        /// </summary>
        CharacterStateManager states;

        /// <summary>
        /// Ao iniciar o metodo passa para states os parametros recebidos de _instance
        /// </summary>
        /// <param name="stateManager"></param>
        public virtual void Init(CharacterStateManager stateManager)
        {
            states = (CharacterStateManager)stateManager;
        }

        /// <summary>
        /// Metodo chamado automaticamente na execução de uma animação
        /// </summary>
        public void OnAnimatorMove()
        {
            OnAnimatorMoveOverride();
        }

        protected virtual void OnAnimatorMoveOverride()
        {
            // caso esteja marcado Use Root Motion ele desativa.
            if (states.useRootMotion == false)
                return;

            // Aqui ele verifica se o Character está no chão e se minha variavel delta instanciada da classe CharacterStateManager for maior que zero
            // ou seja se eu estiver executando qualquer ação de movimento ele irá animar o character para que ele se movimente.
            if (states.isGrounded && states.delta > 0)
            {
                Vector3 v = (states.anim.deltaPosition) / states.delta;
                v.y = states.rigidbody.velocity.y;
                states.rigidbody.velocity = v;
            }
        }
    }
}