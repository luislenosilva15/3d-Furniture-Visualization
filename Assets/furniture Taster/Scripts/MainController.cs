using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{

    public Sprite eyeShow;
    public Sprite eyeHide;

    public Image eyeButton;

    public GameObject floorGrid;

    private bool gridStatus;

    public GameObject insertButton;
    public GameObject drashButton;
    public GameObject okButton;

    private GameObject ArController;
    private ArController ArControllerScript;

    public int furnitureIndex = 1;
 

    public void Start()
    {
      ArController = GameObject.Find("ArController");
      ArControllerScript = ArController.GetComponent<ArController>();
      ScreenDefault();
    }

    void Update()
    {
      
    }
    
    public void ScreenDefault() {
      insertButton.SetActive(true);
      drashButton.SetActive(false);
      okButton.SetActive(false);
    }

    public void CreateFurniture() {
      EditFurniture();
      ArControllerScript.CreatePointArCore(furnitureIndex);
    }

    public void EditFurniture() {
  
      insertButton.SetActive(false);
      drashButton.SetActive(true);
      okButton.SetActive(true);

    }

        public void ViewGrid() {
        gridStatus = !gridStatus;
        eyeButton.sprite = gridStatus? eyeShow:eyeHide;
        floorGrid.SetActive(gridStatus);
    }

        public void FurnitureSelect(int index) {

        furnitureIndex = index;


    }
    
}
