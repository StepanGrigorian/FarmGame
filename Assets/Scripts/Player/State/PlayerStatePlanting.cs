using System.Collections;
using UnityEngine;

public class PlayerStatePlanting : IPlayerState
{
    private Player player;
    private Bed bed;
    private Plant plant;
    public PlayerStatePlanting(Player player, Bed bed, Plant plant)
    {
        this.player = player;
        this.bed = bed;
        this.plant = plant;
    }
    public void Start()
    {
        player.animator.SetBool("isMoving", false);
        player.animator.SetBool("isPlanting", true);
        player.StartCoroutine(Plant());
    }
    public void Update() { }
    public void OnAnimatorMove() { }
    public void End() { }
    private IEnumerator Plant()
    {
        yield return new WaitForSeconds(plant.Settings.PlantingTime);
        bed.Plant(plant);
        player.SetState(Player.GetState<PlayerStateIdle>());
    }
}