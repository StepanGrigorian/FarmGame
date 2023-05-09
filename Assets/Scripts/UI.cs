using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public delegate void PlantSelection(Plant plant);
    public PlantSelection SelectionCallback;

    [SerializeField] private GameObject PlantSelectionMenu;
    [SerializeField] private TextMeshProUGUI XpText;
    [SerializeField] private TextMeshProUGUI CarrotsText;
    private bool selectionOpened = false;
    public void OpenPlantSelection()
    {
        if (!selectionOpened)
        {
            PlantSelectionMenu.SetActive(true);
            selectionOpened = true;
        }
    }
    public void Select(Plant plant)
    {
        ClosePlantSelection();
        SelectionCallback?.Invoke(plant);
    }
    public void ClosePlantSelection()
    {
        PlantSelectionMenu.SetActive(false);
        selectionOpened = false;
    }
    public void UpdateUI(int xp, int carrots)
    {
        XpText.text = $"{xp} Xp";
        CarrotsText.text = $"Carrots {carrots} ";
    }
}