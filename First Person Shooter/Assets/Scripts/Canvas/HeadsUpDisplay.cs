using UnityEngine;
using UnityEngine.UI;

public class HeadsUpDisplay : MonoBehaviour
{
    [SerializeField]
    private Text currentPhaseText;

    [SerializeField]
    private FirstPersonMovement characterMovement;

    private void Update()
    {
        currentPhaseText.text = GameManager.singleton.phaseString();
    }
}
