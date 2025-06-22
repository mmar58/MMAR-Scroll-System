using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MMAR.ScrollSystem.Pagination
{
    public class PaginationCellView : CellView
    {
        public TextMeshProUGUI text;
        public Image image;

        public override void SetData(Data data)
        {
            base.SetData(data);
            var curData= data as PaginationData;
            text.text= curData.pageNo.ToString();
            
        }

        public void OnClicked()
        {
            #region Grabbing the controller and data
            var thisController = controller as PaginationController;
            var thisData= data as PaginationData;
            #endregion
            // Sending command to the controller
            thisController.SelectPage(thisData.pageNo);
        }
        public void Resetolor(Color color)
        {
            image.color = color;
        }
    }
}