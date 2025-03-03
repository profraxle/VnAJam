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

    private BearState _bearState = BearState.Swimming;

    private SwimmingBehaviour _swimmingBehaviour = new SwimmingBehaviour();
    private MovingBehaviour _movingBehaviour = new MovingBehaviour();
    private FishingBehaviour _fishingBehaviour = new FishingBehaviour();
    
    
    // Start is called before the first frame update
    void Start()
    {
      
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
