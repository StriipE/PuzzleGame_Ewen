using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPreview : MonoBehaviour, IPointerClickHandler
{
    private const int PREVIEW_X_OFFSET = -40;
    private const int PREVIEW_Y_OFFSET = 300;
    private const int PREVIEW_X_SPLITTER = 130;

    private GameObject canvas, gameData;

    public int Stage { get; set; }
    public int Level { get; set; }

    private void Awake()
    {
        canvas = GameObject.Find("Canvas");
        gameData = GameObject.Find("GameData");
    }

    void Start()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("mainScene");
        setGameDataLevel();
    }

    // Stage and Level are used for graphical offsets
    public void setLevelPreviewPosition()
    {
        this.transform.SetParent(this.canvas.transform);
        this.transform.position = this.transform.position + new Vector3(Level * PREVIEW_X_SPLITTER + PREVIEW_X_OFFSET, PREVIEW_Y_OFFSET, 0);
    }

    public void setLevelPreviewTexture()
    {
        this.GetComponent<RawImage>().texture = new CreatePreview(Stage, Level).TexturePreview;
        this.transform.GetChild(0).GetComponent<Text>().text = "Level " + Stage.ToString() + "-" + Level.ToString();
    }

    private void setGameDataLevel()
    {
        Gamedata.Stage = this.Stage;
        Gamedata.Level = this.Level;
    }
}