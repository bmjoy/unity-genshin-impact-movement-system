using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerWalkingState : PlayerMovingState
    {
        public PlayerWalkingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            stateMachine.ReusableData.MovementSpeedModifier = groundedData.WalkData.SpeedModifier;
        }

        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);

            stateMachine.ChangeState(stateMachine.RunningState);
        }

        protected override void OnMovementCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.LightStoppingState);
        }
    }
}