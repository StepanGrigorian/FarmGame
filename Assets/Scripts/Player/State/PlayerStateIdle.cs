using UnityEngine;

public class PlayerStateIdle : IPlayerState
{
    private Player player;
    public PlayerStateIdle(Player player)
    {
        this.player = player;
    }
    public void Start()
    {
        player.animator.SetBool("isMoving", false);
        player.animator.SetBool("isPlanting", false);
    }
}