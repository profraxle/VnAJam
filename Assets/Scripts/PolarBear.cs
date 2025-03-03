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

    private GameObject waterLevel;
    
    [SerializeField]
    private GroundCheck _groundCheck;

    private Vector2 lerpPos;
    private Vector2 startPos;
    private bool lerping;
    private float lerpAmount;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _swimmingBehaviour._rigidbody = _rigidbody;
        _movingBehaviour._rigidbody = _rigidbody;

        waterLevel = GameObject.FindWithTag("Water");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < waterLevel.transform.position.y && !_groundCheck.onGround)
        {
            _rigidbody.gravityScale = 0f;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _bearState = BearState.Swimming;
        }
        else
        {
            _bearState = BearState.Fishing;
            _rigidbody.gravityScale = 1f;
        }

        if (lerping)
        {
            this.transform.position = Vector2.Lerp(startPos, lerpPos, lerpAmount);
            lerpAmount += Time.deltaTime;
            if (lerpAmount >= 1f)
            {
                lerping = false;
            }
        }
        else
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

        if (_bearState.Equals(BearState.Fishing))
        {
            if (!_fishingBehaviour.debugActionsText.gameObject.activeInHierarchy)
            {
                _fishingBehaviour.debugActionsText.gameObject.SetActive(true);
                _fishingBehaviour.arrowHUD.gameObject.SetActive(true);
            }
            
        }else
        {
            _fishingBehaviour.debugActionsText.gameObject.SetActive(false);
            _fishingBehaviour.arrowHUD.gameObject.SetActive(false);
        }

    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_bearState == BearState.Swimming && other.gameObject.CompareTag("Ground"))
        {
            lerping = true;
            lerpPos = other.gameObject.GetComponent<Iceberg>().loadBearPos;
            lerpAmount = 0;
            startPos = gameObject.transform.position;
            _rigidbody.velocity = Vector2.zero;
        }
    }
    
}
