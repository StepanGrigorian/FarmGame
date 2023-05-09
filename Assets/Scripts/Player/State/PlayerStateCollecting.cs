using System.Collections;
using UnityEngine;

public class PlayerStateCollecting : IPlayerState
{
    private Player player;
    private Plant plant;
    public PlayerStateCollecting(Player player,Plant plant)
    {
        this.player = player;
        this.plant = plant;
    }
    public void Start()
    {
        player.animator.SetBool("isMoving", false);
        player.animator.SetBool("isPlanting", true);
        player.StartCoroutine(Plant());
    }
    private IEnumerator Plant()
    {
        yield return new WaitForSeconds(plant.Settings.PlantingTime);
        plant.Collect();
        player.SetState(Player.GetState<PlayerStateIdle>());
    }
}