using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureController : MonoBehaviour
{

    public GameObject canvasStore;
    public GameObject buttonStore;
    public GameObject buttonStoreBack;


    void Start()
    {
        buttonStore.SetActive(true);
        canvasStore.SetActive(false);
        buttonStoreBack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveCanvasFurniture() {
        buttonStore.SetActive(false);
        canvasStore.SetActive(true);
        buttonStoreBack.SetActive(true);
    }

        public void DisableCanvasFurniture() {
        buttonStore.SetActive(true);
        canvasStore.SetActive(false);
        buttonStoreBack.SetActive(false);
    }

}
