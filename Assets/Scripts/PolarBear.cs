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
    public Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _swimmingBehaviour._rigidbody = _rigidbody;
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
                _swimmingBehaviour.BehaviourUpdate();
                break;
            case BearState.Fishing:
                _swimmingBehaviour.BehaviourUpdate();
                break;
            
        }
        
    }
}
