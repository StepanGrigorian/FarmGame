using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 gridSize;
    [SerializeField] private Bed gridItemPrefab;
    [SerializeField] private UI UI;

    private void Start()
    {
        for(int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                var child = Instantiate(gridItemPrefab, transform);
                child.transform.localPosition = new Vector3(i, 0, j);
            }
        }
    }
}
