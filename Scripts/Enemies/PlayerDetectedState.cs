public class PlayerDetectedState : States
{
    protected bool isPlayerInAgro;
    protected bool facingRight;
    protected bool playerOnRight;
    public PlayerDetectedState(Entity entity, StateMachine stateMachine, string animParam) : base(entity, stateMachine, animParam)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate(); 
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks() {
        isPlayerInAgro = entity.isPlayerInAgro();
        facingRight = entity.facingDirection() > 0;
        playerOnRight = entity.PlayerOnRight();
    }
}
