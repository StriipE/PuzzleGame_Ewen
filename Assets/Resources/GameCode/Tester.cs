using UnityEngine;

public class Tester : MonoBehaviour
{
    public int level;
    public int stage;

    public void Awake()
    {
        Gamedata.Level = level;
        Gamedata.Stage = stage;
    }
}

