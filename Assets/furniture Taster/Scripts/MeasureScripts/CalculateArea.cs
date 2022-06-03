using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using  UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class CalculateArea : MonoBehaviour {

  public List<float> MeasurePoints = new List<float>();

  public bool selectPointsFinish;

  public float areaTotal;

  public Text myText;
  void Start() {

    selectPointsFinish = false;
}

  void Update() {
    if (selectPointsFinish == true)
      CalculeArea();
  }

  void CalculeArea(){
    areaTotal = MeasurePoints[0] * MeasurePoints[1];
    selectPointsFinish = false; 

    string localName = PlayerPrefs.GetString("local");

    PlayerPrefs.SetFloat(localName, areaTotal);
    SceneManager.LoadScene("MainScene");

    //myText.text = areaTotal.ToString();
  }

}
