using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class DragObject : MonoBehaviour
{
    float YPosition;
    float rotSpeed = 1.5f;

    private Vector3 screenPoint;
	private Vector3 offset;
     private Vector3 scaleChange;

    public bool DragFurniture;

    public GameObject furniture;

   //public Slider sliderScaleFuniture;

    public bool edit;

    public GameObject canvas;

    private GameObject ArController;
    private ArController ArControllerScript;

    public GameObject Furniture;


    void Start()
    {
        edit = true;
        ArController = GameObject.Find("ArController");
        ArControllerScript = ArController.GetComponent<ArController>();

        ArControllerScript.calculateMarketBool = false;

        YPosition = ArControllerScript.YPointFix; 

    }

    public void DragUI() {
        DragFurniture = true;
    }
        public void RotateUI() {
        DragFurniture = false;
    }

        void OnMouseDrag(){
        if (DragFurniture == true  &&  edit == true){       
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position =  new Vector3 (cursorPosition.x,YPosition, cursorPosition.z);
        }
        
        if (DragFurniture == false &&  edit == true ) {
             float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            transform.RotateAround(Vector3.up, rotX);
        }
    }
		
    void OnMouseDown(){
        if (DragFurniture == true &&  edit == true){
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    public void Update() {
       // if (edit == true){ 
       // sliderScaleFuniture.gameObject.SetActive(true);
      //  scaleChange = new Vector3(sliderScaleFuniture.value, sliderScaleFuniture.value, sliderScaleFuniture.value);
      //  furniture.transform.localScale = scaleChange;


      //  }
        GameObject iconOk = GameObject.Find("iconOk");
        Button iconOkScript = iconOk.GetComponent<Button>();

        iconOkScript.onClick.AddListener(EditObject);

        
        GameObject iconDrash = GameObject.Find("iconDrash");
        Button iconDrashButton = iconDrash.GetComponent<Button>();

        iconDrashButton.onClick.AddListener(DestroyFurniture);
    }

    public void EditObject() {
        edit = false;
        canvas.SetActive(false);
        ArControllerScript.calculateMarketBool = true;
    }
    public void DestroyFurniture() {
        Destroy(Furniture);
        ArControllerScript.calculateMarketBool = true;
    }
}
