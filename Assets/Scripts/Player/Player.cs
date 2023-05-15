using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public PlayerInput input { get; private set; }
    public NavMeshAgent agent { get; private set; }
    public Animator animator { get; private set; }

    [SerializeField] private UI ui;

    private static Dictionary<Type, IPlayerState> statesDictionary;
    private IPlayerState currentState;
    private Bed selectedBed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();

        animator.applyRootMotion = true;
        agent.updatePosition = false;
        agent.updateRotation = true;

        input.BedClickCallback += BedClicked;
        input.PositionCallback += GoToPosition;
        input.PlantClickCallback += GoToCollect;
    }
    private void Start()
    {
        InitStates();
        SetState(GetState<PlayerStateIdle>());
    }
    private void GoToPosition(Vector3 position)
    {
        if (currentState is PlayerStateIdle)
        {
            SetState(new PlayerStateMoving(this, position));
        }
    }
    private void BedClicked(Bed bed)
    {
        if (currentState is PlayerStateIdle)
        {
            ui.OpenPlantSelection();
            selectedBed = bed;
            ui.SelectionCallback = null;
            ui.SelectionCallback += SetTarget;
        }
    }
    private void GoToCollect(Plant plant)
    {
        if (plant.isCollectable && currentState is PlayerStateIdle)
            SetState(new PlayerStateMovingToCollect(this, plant));
    }
    private void SetTarget(Plant plant)
    {
        if (currentState is PlayerStateIdle)
        {
            SetState(new PlayerStateMovingToPlant(this, selectedBed, plant));
            selectedBed = null;
        }
    }
    private void InitStates()
    {
        statesDictionary = new Dictionary<Type, IPlayerState>();
        statesDictionary[typeof(PlayerStateIdle)] = new PlayerStateIdle(this);
    }
    public void SetState(IPlayerState state)
    {
        if (currentState != null)
            currentState.End();
        currentState = state;
        currentState.Start();
    }
    public static IPlayerState GetState<T>() where T : IPlayerState
    {
        Type type = typeof(T);
        return statesDictionary[type];
    }
    private void Update()
    {
        currentState?.Update();
    }
    private void OnAnimatorMove()
    {
        currentState?.OnAnimatorMove();
    }
}