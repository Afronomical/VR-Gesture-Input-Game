using UnityEngine;

[System.Serializable]
public class SettingsData
{
    public int level;

    public bool snapRotation;

    public bool isSnapRotating;
    

    public SettingsData(Settings setting)
    {
        // level = setting.level
        //vice versa

        isSnapRotating= setting.isSnapRotating;
    }
}
