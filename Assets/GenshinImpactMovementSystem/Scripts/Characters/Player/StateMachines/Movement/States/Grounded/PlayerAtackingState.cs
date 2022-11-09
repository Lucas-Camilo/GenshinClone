using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerAtackingState : PlayerGroundedState
    {
       public PlayerAtackingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {

        }
        public override void Enter()
        {
            base.Enter();
            if (stateMachine.ReusableData.MovementInput != Vector2.zero)
            {
                Debug.Log("FORÇAR PARADA");
                stateMachine.Player.Input.DisableActionFor(stateMachine.Player.Input.PlayerActions.Movement, 2f);
                stateMachine.Player.Rigidbody.velocity = new Vector3(0, 0, 0);
            }
            StartAnimation(stateMachine.Player.AnimationData.AtackingParameterHash);

            SetBaseRotationData();
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(stateMachine.Player.AnimationData.AtackingParameterHash);
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            //if (!shouldKeepRotating)
            //{
            //    return;
            //}

            RotateTowardsTargetRotation();
        }
        public override void OnAnimationTransitionEvent()
        {
            if (stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.IdlingState);

                return;
            }
            stateMachine.Player.Input.DisableActionFor(stateMachine.Player.Input.PlayerActions.Movement, 0f);
            stateMachine.Player.Input.EnableAction(stateMachine.Player.Input.PlayerActions.Movement);
        }
        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();

            stateMachine.Player.Input.PlayerActions.Movement.performed += OnMovementPerformed;

        }
        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();

            stateMachine.Player.Input.PlayerActions.Movement.performed -= OnMovementPerformed;
        }
        protected override void OnMovementPerformed(InputAction.CallbackContext context)
        {
            base.OnMovementPerformed(context);

            //shouldKeepRotating = true;
        }

        protected override void OnAtackStarted(InputAction.CallbackContext context)
        {
        }

    }
}
