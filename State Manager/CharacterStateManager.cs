using UnityEngine;
using Assets._Scripts.FSM;
using Assets._Scripts.Utilits;

namespace Assets._Scripts.State_Manager
{
    /// <summary>
    /// Responsavel pelo gerenciamento do personagem (Character) ou seja pelo seu modelo 3D, não por você que é o controlador
    /// </summary>
    public abstract class CharacterStateManager : StateManager
    {
        #region Variaveis publicas
        /// <summary>
        /// são exibidas no PlayerStatManager porque CharacterStateManager é a classe pai de PlayerStateManager
        /// </summary>
        [HideInInspector]
        public Animator anim;
        [HideInInspector]
        public new Rigidbody rigidbody;
        [HideInInspector]
        public AnimatorHook animHook;

        [Header("States")]
        public bool isGrounded;
        public bool useRootMotion;
        public bool lockOn;
        [HideInInspector]
        public Transform target; // é preciso implementar um metodo para que o Player pegue o targuet mais proximo que não seja o dele mesmo

        [Header("Controller Values")]
        public float vertical;
        public float horizontal;
        public float delta;
        public Vector3 rootMovement;

        #endregion

        #region Metodos Publicos de Reescrita
        /// <summary>
        /// Metodo inicial chamado pela classe PlayerStatManager
        /// </summary>
        public override void Init()
        {
            // requisição de componentes necessários que estão dentro do objeto Player Controller
            anim = GetComponentInChildren<Animator>();
            animHook = GetComponentInChildren<AnimatorHook>();
            rigidbody = GetComponentInChildren<Rigidbody>();

            // aqui o RootMotion é desativado no inicio
            anim.applyRootMotion = false;

            // Starta a classe AnimatorHook passando a CharacterStateManager por parametro
            animHook.Init(this);
        }

        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Recebe por parametro da classe InputManager o nome da animação e o valor verdadeiro para poder executar a mesma.
        /// </summary>
        /// <param name="targetAnim"></param>
        /// <param name="isInteracting"></param>
        public void PlayTargetAnimation(string targetAnim, bool isInteracting)
        {
            // Seta no componente animator a boleana verdadeiro para que rode a animação configurada de acordo com o nome recebido por parametro
            anim.SetBool("isInteracting", isInteracting);
            anim.CrossFade(targetAnim, 0.2f);
        }

        #endregion

        #region Metodos Publicos Virtuais
        /// <summary>
        /// Aqui é passado o transforme do inimigo para que o player possa travar sua mira
        /// </summary>
        /// <param name="traget"></param>
        public virtual void OnAssignLookOverride(Transform traget)
        {
            // aqui meu tranforme faceTarget recebe de faceTarget enviado por parametro
            this.target = target;
            // se o faceTarget não estiver vazio então trave a mira
            if (target != null)
                lockOn = true;
        }

        /// <summary>
        /// Metodo para destravar a mira
        /// </summary>
        public virtual void OnClearLookOverride()
        {
            lockOn = false;
        }

        #endregion
    }
}