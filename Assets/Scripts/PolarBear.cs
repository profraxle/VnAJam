using UnityEngine;
using UnityEngine.InputSystem;


public class PolarBear : MonoBehaviour
{
    enum BearState
    {
        Moving,
        Swimming,
        Fishing
    };

    private BearState _bearState = BearState.Moving;

    private SwimmingBehaviour _swimmingBehaviour;
    private MovingBehaviour _movingBehaviour;
    private FishingBehaviour _fishingBehaviour;
    
    
    // Start is called before the first frame update
    void Start()
    {
        moveAction
    }

    // Update is called once per frame
    void Update()
    {
        switch (_bearState)
        {
            case BearState.Moving:
                _movingBehaviour.BehaviourUpdate();
                break;
            case BearState.Swimming:
                break;
            case BearState.Fishing:
                break;
            
        }
        
    }
}
