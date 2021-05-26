public class PlayerTurnState : State
{
    PlayerController characterController;
    GameManager gameManager;

    public PlayerTurnState(PlayerController controller, GameManager manager)
    {
        characterController = controller;
        gameManager = manager;
    }
    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}
