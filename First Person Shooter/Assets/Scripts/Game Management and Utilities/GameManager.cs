using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    public enum Phase { Setup, Defense }

    [SerializeField]
    private Phase _phase;

    public Phase phase { get { return _phase; } private set { _phase = value; } }

    public string phaseString ()
    {
        switch(phase)
        {
            case Phase.Setup: return "Setup Phase";
            case Phase.Defense: return "Defense Phase";
            default: return "";
        }
    }

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Debug.LogError("More than one Game Manager in scene!");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(phase == Phase.Setup)
            {
                BeginDefensePhase();
            }
            else if (phase == Phase.Defense)
            {
                BeginSetupPhase();
            }
        }
    }

    private void BeginSetupPhase ()
    {
        phase = Phase.Setup;
    }

    private void BeginDefensePhase ()
    {
        phase = Phase.Defense;
    }
}