using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    [SerializeField] public PlantSettings Settings;
    [SerializeField] private PlantUI ui;
    public DateTime plantingDate { get; private set; }

    protected IPlantState currentState;

    [HideInInspector] public bool isCollectable = false;
    [HideInInspector] public Bed ParentBed;
    public abstract void Collect();
    public abstract void OnGrown();
    private void Start()
    {
        plantingDate = DateTime.Now;
        SetState(new PlantStateGrowing(this));
        ui.SetTime(Settings.GrowingTime);
    }
    public void SetState(IPlantState state)
    {
        if (currentState != null)
            currentState.End();
        currentState = state;
        currentState.Start();
        UpdateState();
    }
    public void UpdateState()
    {
        currentState.Update();
    }
    public void UpdateUI(int time)
    {
        ui.SetCurrentTime(time);
    }
}