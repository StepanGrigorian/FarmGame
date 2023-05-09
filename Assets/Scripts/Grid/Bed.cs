using UnityEngine;

public class Bed : MonoBehaviour
{
    public Plant currentPlant;
    public void Plant(Plant plant)
    {
        currentPlant = Instantiate(plant, transform);
        currentPlant.ParentBed = this;
    }
}