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

    [SerializeField]
    private SwimmingBehaviour _swimmingBehaviour;

    [SerializeField] 
    private MovingBehaviour _movingBehaviour;
    
    [SerializeField]
    private FishingBehaviour _fishingBehaviour;
    public Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _swimmingBehaviour._rigidbody = _rigidbody;
        _movingBehaviour._rigidbody = _rigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_bearState)
        {
            case BearState.Moving:
                _movingBehaviour.BehaviourUpdate();
                EnergyManager.instance.isSwimming = false;
                EnergyManager.instance.isMoving = true;
                break;
            case BearState.Swimming:
                _swimmingBehaviour.BehaviourUpdate();
                EnergyManager.instance.isSwimming = true;
                EnergyManager.instance.isMoving = false;
                break;
            case BearState.Fishing:
                _fishingBehaviour.BehaviourUpdate();
                EnergyManager.instance.isSwimming = false;
                EnergyManager.instance.isMoving = false;
                break;
            
        }
        
    }
}
