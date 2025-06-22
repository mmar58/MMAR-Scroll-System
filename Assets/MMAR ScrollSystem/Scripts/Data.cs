using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMAR.ScrollSystem
{
    [SerializeField]
    public class Data
    {
        public CellView cellView;
        public Data() { }
        public virtual void UpdateCellView()
        {
            if (cellView != null)
            {
                cellView.SetData(this);
            }
        }
    }
}