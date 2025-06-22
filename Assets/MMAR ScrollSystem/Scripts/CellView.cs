
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMAR.ScrollSystem
{
    public class CellView : MonoBehaviour
    {
        internal Controller controller;
        internal Data data;
        public virtual void SetData(Data data)
        {
            this.data = data;
        }
    }
}