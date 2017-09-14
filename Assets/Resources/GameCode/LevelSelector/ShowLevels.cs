using UnityEngine;

public class ShowLevels : MonoBehaviour {


    // Use this for initialization
    void Start () {

        // Stub for a good way to load levels
        for (int i = 1; i <= 3; i++)
        {
            GameObject levelPreview = (GameObject) Instantiate(Resources.Load(@"Prefabs/LevelPreviewHolder"));

            levelPreview.GetComponent<LevelPreview>().Stage = 1;
            levelPreview.GetComponent<LevelPreview>().Level = i;

            levelPreview.GetComponent<LevelPreview>().setLevelPreviewPosition();
            levelPreview.GetComponent<LevelPreview>().setLevelPreviewTexture();

        }
    }
	

}
