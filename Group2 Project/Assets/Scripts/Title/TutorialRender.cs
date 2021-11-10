using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialRender : MonoBehaviour
{
    [System.Serializable]
    public class DataProperty
    {
        public Sprite sprite;
        public Sprite spritetwo;
        public string descirotion;
    }
    public Button previousButton, nextButton;
    public Image InfoImage;
    public Image InfoImagetwo;
    public Text text;

    public List<DataProperty> Data;

    int currentPage;
    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        previousButton.interactable = currentPage > 0;
        nextButton.interactable = currentPage < Data.Count - 1;

        UpdateContent();
    }

    void UpdateContent()
    {
        InfoImage.sprite = Data[currentPage].sprite;
        InfoImagetwo.sprite = Data[currentPage].spritetwo;
        text.text = Data[currentPage].descirotion;
    }



    public void OnclickPreButton()
    {
        currentPage--;
        UpdateUI();
    }

    public void OnclickNextButton()
    {
        Debug.Log("11");
        currentPage++;
        UpdateUI();
    }
}
