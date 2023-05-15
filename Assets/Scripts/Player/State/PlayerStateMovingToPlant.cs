using UnityEngine;

public class PlayerStateMovingToPlant : IPlayerState
{
    private Player player;
    private Bed bed;
    private Plant plant;

    private Vector2 velocity;
    private Vector2 smoothDeltaPosition;
    private Vector3 target;
    public PlayerStateMovingToPlant(Player player, Bed bed, Plant plant)
    {
        this.player = player;
        this.bed = bed;
        this.plant = plant;
        target = bed.transform.position;
        player.agent.SetDestination(target);
    }
    public void Start() { }

    public void End() { }
    public void Update()
    {
        SynchronizeAnimatorAndAgent();
    }
    public void OnAnimatorMove()
    {
        Vector3 rootPosition = player.animator.rootPosition;
        rootPosition.y = player.agent.nextPosition.y;
        player.transform.position = rootPosition;
        player.agent.nextPosition = rootPosition;
    }
    private void SynchronizeAnimatorAndAgent()
    {
        Vector3 worldDeltaPosition = player.agent.nextPosition - player.transform.position;
        worldDeltaPosition.y = 0;

        float dx = Vector3.Dot(player.transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(player.transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);
        float smooth = Mathf.Min(1, Time.deltaTime / 0.1f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        velocity = smoothDeltaPosition / Time.deltaTime;
        if (player.agent.remainingDistance <= player.agent.stoppingDistance)
        {
            velocity = Vector2.Lerp(
                Vector2.zero,
                velocity,
                player.agent.remainingDistance / player.agent.stoppingDistance
            );
        }

        bool shouldMove = velocity.magnitude > 0.5f
            && player.agent.remainingDistance > player.agent.stoppingDistance;

        player.animator.SetBool("isMoving", shouldMove);
        player.animator.SetFloat("Velocity", velocity.magnitude);
        if (Vector3.Distance(player.transform.position, target) < player.agent.stoppingDistance)
        {
            player.SetState(new PlayerStatePlanting(player, bed, plant));
        }
    }
}