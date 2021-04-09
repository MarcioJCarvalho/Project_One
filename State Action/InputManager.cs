using System.Collections;
using UnityEngine;
using Assets._Scripts.FSM;
using Assets._Scripts.State_Manager;

namespace Assets._Scripts.State_Action
{
    /// <summary>
    /// Responsavel pelos controntoles entradas de comandos
    /// </summary>
    public class InputManager : StateAction
    {
        /// <summary>
        /// Instancia da classe PlayerStateManager
        /// </summary>
        PlayerStateManager s;

        // Triggers & bumpers
        bool Rb, Rt, Lb, Lt, isAttacking, b_Input, y_Input, x_Input, inventoryInput,
        leftArrow, rightArrow, upArrow, downArrow;

        public InputManager(PlayerStateManager states)
        {
            s = states;
        }

        public override bool Execute()
        {

            bool returnValue = false;
            isAttacking = false;

            #region Inputs do Joistick

            s.horizontal = Input.GetAxis("Horizontal");
            s.vertical = Input.GetAxis("Vertical");
            Rb = Input.GetButton("RB");
            Rt = Input.GetButton("RT");
            Lb = Input.GetButton("LB");
            Lt = Input.GetButton("LT");
            //inventoryInput = Input.GetButton("Inventory");
            b_Input = Input.GetButton("B");
            y_Input = Input.GetButtonDown("Y");
            x_Input = Input.GetButton("X");
            leftArrow = Input.GetButton("Left");
            rightArrow = Input.GetButton("Right");
            upArrow = Input.GetButton("Up");
            downArrow = Input.GetButton("Down");
            s.mouseX = Input.GetAxis("Mouse X");
            s.mouseY = Input.GetAxis("Mouse Y");

            #endregion

            #region Ações de Entrada do Input EX: Andar, Atacar e travar mira

            s.moveAmount = Mathf.Clamp01(Mathf.Abs(s.horizontal) + Mathf.Abs(s.vertical));

            returnValue = HandleAttacking();

            // input de travar a mira no inimigo
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (s.lockOn)
                {
                    s.OnClearLookOverride();
                }
                else
                {
                    s.OnAssignLookOverride(s.target);
                }
            }
            return returnValue;

            #endregion
        }

        #region Lógica de Ataque

        /// <summary>
        /// Manipulação de ataque, para qualquer gatilho ou botão referenciado a baixo quando pressionado retornara o estado de atacando.
        /// </summary>
        /// <returns>isAttacking</returns>
        bool HandleAttacking()
        {
            if (Rb || Rt || Lb || Lt)
            {
                isAttacking = true;
            }

            if (y_Input)
            {
                isAttacking = false;
            }

            // Se isAttacking for verdadeiro ou seja se eu estiver atacando, execute a animação referenciada em PlayTargetAnimation
            if (isAttacking)
            {
                // aqui vão as ações dos inputs apenas do local player
                if (s.photonView.IsMine)
                {
                    // Encontra a animação de ataque real dos itens etc.
                    // Roda a animação
                    s.PlayTargetAnimation("Attack 1", true);
                    s.ChangeState(s.attckStateId);
                }                
            }
            return isAttacking;
        }

        #endregion
    }
}