namespace Enemy
{
    public interface IBotBehavior
    {
        void Enter();
        void Exit();
        void CustomUpdate();
        
        void CustomFixedUpdate();
    }
}