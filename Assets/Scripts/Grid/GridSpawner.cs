using System.Collections;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize;
    [SerializeField] private Bed gridItemPrefab;
    [SerializeField] private UI UI;
    private Bed[,] beds;

    private void Start()
    {
        beds = new Bed[gridSize.x, gridSize.y];
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                var bed = Instantiate(gridItemPrefab, transform);
                bed.transform.localPosition = new Vector3(i, 0, j);
                beds[i, j] = bed;
            }
        }
        StartCoroutine(UpdateUI());
    }
    IEnumerator UpdateUI()
    {
        while (true)
        {
            for (int i = 0; i < gridSize.x; i++)
            {
                for (int j = 0; j < gridSize.y; j++)
                {
                    if (beds[i, j].currentPlant != null)
                    {
                        beds[i, j].currentPlant.UpdateState();
                    }
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}