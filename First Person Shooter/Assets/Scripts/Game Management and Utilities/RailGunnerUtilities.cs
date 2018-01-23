namespace RailGunner_Utilities
{
    /// <summary>
    /// A four speed switch with five settings, including 'off'. 
    /// </summary>
    public enum FiveSwitchToggle { Off, Low, Medium, High, Maximum };
    
    /// <summary>
    /// Values for the five setting switch. 
    /// </summary>
    public class FiveSwitch { public int Low, Medium, High, Maximum; public FiveSwitchToggle currentSetting; }

    public class Utilities
    {
        protected static bool AllAreTrue(bool[] booleanArray)
        {
            foreach (bool item in booleanArray)
            {
                return !!item;
            }
            return true;
        }
    }
}