using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelPreview : MonoBehaviour, IPointerClickHandler
{
    public int Stage { get; set; }
    public int Level { get; set; }

    public void Start()
    {
        Stage = 0;
        Level = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("mainScene");
    }
}