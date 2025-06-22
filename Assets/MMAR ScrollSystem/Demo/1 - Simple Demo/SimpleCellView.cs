using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMAR.ScrollSystem.Demo
{
    public class SimpleCellView : CellView
    {
        public Text text;
        public override void SetData(Data data)
        {
            base.SetData(data);
            var curData=(SimpleData)data;
            text.text = curData.text;
        }
    }
}