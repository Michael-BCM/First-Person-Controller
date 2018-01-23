using UnityEngine;

public class ClimateSystem : MonoBehaviour
{
    private Tower thisTower;

    [SerializeField]
    private Meter _temperature;

    /// <summary>
    /// The current temperature. 
    /// </summary>
    public Meter temperature { get { return _temperature; } private set { _temperature = value; } }
    
    protected void Awake()
    {
        thisTower = GetComponent<Tower>();
    }

    protected void Update()
    {
        SetupUpdate();
        DefenseUpdate();
    }

    private void SetupUpdate()
    {
        if (GameManager.singleton.phase != GameManager.Phase.Setup)
        {
            return;
        }
    }

    private void DefenseUpdate()
    {
        if (GameManager.singleton.phase != GameManager.Phase.Defense)
        {
            return;
        }

        Cool(1);

        if (thisTower.towerState == Tower.TowerState.Active)
        {
            //Everything that runs when the tower is active during the Defense Phase.
            Heat(2);

            if (temperature.currentValue >= temperature.maxValue)
            {
                OverheatShutdown();
            }
        }
        else if(thisTower.towerState == Tower.TowerState.Inactive)
        {
            //Everything that runs when the tower is inactive during the Defense Phase.
        }
    }

    /// <summary>
    /// Steadily increases the temperature by 'interval' per second.
    /// </summary>
    protected void Heat(int interval)
    {
        temperature.Count(Time.deltaTime * interval);
    }

    /// <summary>
    /// Steadily reduces the temperature by 'interval' per second.
    /// </summary>
    protected void Cool(int interval)
    {
        temperature.Count(-Time.deltaTime * interval);
    }

    /// <summary>
    /// Shuts down the tower if the current temperature is equal to the maximum temperature. 
    /// </summary>
    protected void OverheatShutdown()
    {
        thisTower.SetTowerState(Tower.TowerState.Inactive);
    }

    /// <summary>
    /// Returns a colour based on the current temperature of the tower.
    /// </summary>
    protected Color IndicatorColor()
    {
        //Returns blue when disabled, then goes through the following stages: green, citrus, yellow, orange, red.

        //Returns a paler colour when deactivated. 

        return Color.white;
    }
}