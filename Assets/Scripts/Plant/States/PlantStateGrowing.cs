using System;
using UnityEngine;

public class PlantStateGrowing : IPlantState
{
    private Plant plant;
    private Bed bed;
    private GameObject obj;
    public PlantStateGrowing(Plant plant)
    {
        this.plant = plant;
    }
    public void Start()
    {
        obj = GameObject.Instantiate(plant.Settings.PlantModel, plant.transform);
    }
    public void End()
    {
        GameObject.Destroy(obj);
        plant.UpdateUI(0);
    }

    public void Update()
    {
        double left = (DateTime.Now - plant.plantingDate).TotalSeconds;
        if (left < plant.Settings.GrowingTime)
        {
            plant.UpdateUI(plant.Settings.GrowingTime - (int)left);
        }
        else
        {
            plant.SetState(new PlantStateGrown(plant));
        }
    }
}