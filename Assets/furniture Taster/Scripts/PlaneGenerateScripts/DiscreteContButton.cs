using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class DiscreteContButton : ButtonBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            base.Start();
        }

        protected override void OnClickButton()
        {
            base.OnClickButton();
            LineRendererDrawing.Instance.IsDisCrete = !doShow;
        }
    }
