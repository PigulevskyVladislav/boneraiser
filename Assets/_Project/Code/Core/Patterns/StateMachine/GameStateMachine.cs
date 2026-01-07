using _Project.Code.Core.Patterns.StateMachine.States;

namespace _Project.Code.Core.Patterns.StateMachine
{
    public class GameStateMachine
    {
        private IState _currentState;

        public void ChangeState(IState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}
