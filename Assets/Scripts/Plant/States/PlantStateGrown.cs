using UnityEngine;

public class PlantStateGrown : IPlantState
{
    private Plant plant;
    private GameObject obj;
    public PlantStateGrown(Plant plant)
    {
        this.plant = plant;
    }
    public void Start()
    {
        plant.OnGrown();
        obj = Object.Instantiate(plant.Settings.GrownModel, plant.transform);
    }
    public void End()
    {
        Object.Destroy(obj);
        plant.UpdateUI(0);
    }
    public void Update()
    {

    }
}