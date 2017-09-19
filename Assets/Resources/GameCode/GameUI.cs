using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    Text availableBlocks, targetBlocks, levelName;
    GameObject minimap;

    public void Start()
    {
        GameObject availableBlocksHolder = GameObject.Find("AvailableBlocks");
        availableBlocks = availableBlocksHolder.transform.GetChild(0).GetComponent<Text>();

        GameObject targetBlocksHolder = GameObject.Find("TargetBlocks");
        targetBlocks = targetBlocksHolder.transform.GetChild(0).GetComponent<Text>();

        levelName = GameObject.Find("LevelName").GetComponent<Text>();
        levelName.text = "Level " + Gamedata.Stage.ToString() + "-" + Gamedata.Level.ToString();

        minimap = GameObject.Find("Minimap");
        minimap.GetComponent<RawImage>().texture = new CreatePreview(Gamedata.Stage, Gamedata.Level).TexturePreview;
    }

    public void Update()
    {
        availableBlocks.text = Gamedata.AvailableBlocks.ToString();
        targetBlocks.text = Gamedata.TargetBlocks.ToString();
    }
}

