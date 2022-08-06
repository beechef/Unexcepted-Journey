using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Input
{
    public class InputSystem : MonoBehaviour
    {
        [SerializeField] private LayerMask groundPlayer;

        private Camera _camera;

        private PlayerInput _input;

        private InputAction _click;

        private void Awake()
        {
            _camera = Camera.main;

            _input = new PlayerInput();
            _input.Enable();
            _click = _input.Default.Click;
        }

        public bool IsClick => _click.IsPressed();
        public Vector3 MovePosition
        {
            get
            {
                Vector3 movePos = transform.position;

                Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

                if (Physics.Raycast(ray, out var hit, float.MaxValue, groundPlayer))
                {
                    movePos = hit.point;
                }

                return movePos;
            }
        }
    }
}