using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Mover _mover;

    private InputSystem _inputSystem;
    private Animal _selectedAnimal;

    private void Awake()
    {
        _inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        _inputSystem.Player.Click.performed += OnClick;
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Player.Click.performed -= OnClick;
        _inputSystem.Disable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        if (Pointer.current == null)
            return;
        
        Vector2 pointerPosition = Pointer.current.position.ReadValue();

        Ray ray = _camera.ScreenPointToRay(pointerPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Animal animal = hit.collider.GetComponentInParent<Animal>();

            if (animal != null)
            {
                if (animal.CurrentBiome.CanSelectAnimal(animal) == false)
                    return;
                
                _selectedAnimal = animal;
                return;
            }

            Biome biome = hit.collider.GetComponentInParent<Biome>();

            if (biome != null && _selectedAnimal != null)
            {
                _mover.Move(_selectedAnimal, biome);

                _selectedAnimal = null;
            }
        }
    }
}