using Runtime.Input;
using UnityEngine;
using UnityEngine.AI;

namespace Runtime
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private InputSystem input;
        [SerializeField] private NavMeshAgent agent;

        private void FixedUpdate()
        {
            if (input.IsClick)
            {
                agent.SetDestination(input.MovePosition);
            }
        }
    }
}