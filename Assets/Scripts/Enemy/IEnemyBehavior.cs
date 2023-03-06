namespace Enemy
{
    public interface IEnemyBehavior
    {
        void Enter();
        void Exit();
        void CustomUpdate();
        
        void CustomFixedUpdate();
    }
}