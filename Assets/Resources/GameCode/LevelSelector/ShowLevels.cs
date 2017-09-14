using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowLevels : MonoBehaviour {

    private const int PREVIEW_X_OFFSET = -40;
    private const int PREVIEW_Y_OFFSET = 300;
    private const int PREVIEW_X_SPLITTER = 130;
    // Use this for initialization
    void Start () {
        GameObject canvas = GameObject.Find("Canvas");

        // Stub for a good way to load levels
        for (int i = 1; i <= 3; i++)
        {
            GameObject levelPreview = (GameObject) Instantiate(Resources.Load(@"Prefabs/LevelPreviewHolder"));
            levelPreview.transform.SetParent(canvas.transform);
            levelPreview.transform.position = levelPreview.transform.position + new Vector3(i * PREVIEW_X_SPLITTER + PREVIEW_X_OFFSET, PREVIEW_Y_OFFSET, 0);

            levelPreview.GetComponent<RawImage>().texture = new CreatePreview(1, i).TexturePreview;
            levelPreview.transform.GetChild(0).GetComponent<Text>().text = "Level 1-" + i.ToString();
        }
    }
	
	void Update () {
	
	}

    void OnGUI ()
    {

    }
}
