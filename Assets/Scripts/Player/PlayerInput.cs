using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public delegate void CallbackBed(Bed bed);
    public delegate void CallbackPlant(Plant plant);
    public delegate void CallbackPosition(Vector3 position);

    public CallbackBed BedClickCallback;
    public CallbackPlant PlantClickCallback;
    public CallbackPosition PositionCallback;

    [SerializeField] private LayerMask Mask;
    private void Update()
    {
        HandleInput();
    }
    private void HandleInput()
    {
        if (Application.isFocused && Mouse.current.leftButton.wasReleasedThisFrame && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, Mask))
            {
                if (hit.rigidbody != null)
                {
                    GameObject obj = hit.rigidbody.gameObject;
                    Bed item;
                    obj.TryGetComponent(out item);
                    if (item != null)
                    {
                        if (item.currentPlant == null)
                        {
                            BedClickCallback?.Invoke(item);
                        }
                        else
                        {
                            PlantClickCallback?.Invoke(item.currentPlant);
                        }
                    }
                }
                else
                {
                    PositionCallback?.Invoke(hit.point);
                }
            }
        }
    }
}