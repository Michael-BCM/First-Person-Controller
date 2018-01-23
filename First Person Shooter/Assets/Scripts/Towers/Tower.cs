using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum TowerState { Active, Standby, Inactive }

    /// <summary>
    /// The 'Renderer' component of this object. 
    /// </summary>
    private Renderer _renderer;

    [SerializeField]
    private Meter _rebootMeter;

    /// <summary>
    /// The meter for reactivating the tower. 
    /// </summary>
    public Meter rebootMeter { get { return _rebootMeter; } private set { _rebootMeter = value; } }

    /// <summary>
    /// The meter for upgrading the tower. 
    /// </summary>
    public Meter upgradeMeter { get { return _upgradeMeter; } private set { _upgradeMeter = value; } }

    [SerializeField]
    private Meter _upgradeMeter;

    /// <summary>
    /// Is this tower currently active?
    /// </summary>
    public TowerState towerState { get { return _towerState; } private set { _towerState = value; } }

    [SerializeField]
    private TowerState _towerState;

    /// <summary>
    /// Is the player in range of this tower?
    /// </summary>
    public bool isPlayerInRange { get { return _isPlayerInRange; } private set { _isPlayerInRange = value; } }

    [SerializeField]
    private bool _isPlayerInRange;

    /// <summary>
    /// Is this tower rebooting?
    /// </summary>
    public bool isRestarting { get; private set; }

    protected void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    protected void Start()
    {
        SetTowerState(TowerState.Active);
    }

    protected void OnTriggerEnter(Collider other)
    {
        isPlayerInRange = (other.tag == "Player");
    }

    protected void OnTriggerExit(Collider other)
    {
        isPlayerInRange = !(other.tag == "Player");
    }

    protected void Update()
    {
        Reboot();
    }

    /// <summary>
    /// Displays text on the tower. 
    /// </summary>
    protected void Display3DText() 
    {
        
    }
    
    /// <summary>
    /// Deactivates the tower. 
    /// </summary>
    public void SetTowerState (TowerState state)
    {
        towerState = state;
    }
    
    /// <summary>
    /// Returns true if the tower can be reset. 
    /// </summary>
    protected bool CanReboot()
    {
        return GameManager.singleton.phase == GameManager.Phase.Defense && towerState == TowerState.Inactive && isPlayerInRange;
    }
    
    protected bool IsRebooting ()
    {
        return CanReboot() && Input.GetKey(KeyCode.E);
    }

    /// <summary>
    /// Counts along the reset meter for x seconds.
    /// </summary>
    protected void Reboot()
    {
        if (!IsRebooting())
        {
            return;
        }

        rebootMeter.Count(1 * Time.deltaTime);

        if (rebootMeter.currentValue == rebootMeter.maxValue)
        {
            rebootMeter.ResetToMin();
            SetTowerState(TowerState.Active);
        }
    }
}