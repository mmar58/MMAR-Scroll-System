using MMAR.ScrollSystem.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMAR.ScrollSystem.Demo
{
    public class DifferentHeightController : Controller
    {
        public int reduceCount = 10;
        public float perReduceAmount = 10;
        public float startHeight;
        private void Start()
        {
            scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, startHeight);
            for (int i = 0; i < 100; i++)
            {
                AddData(new SimpleData("Index " + i));
            }
        }
        public override float GetHeight(int index)
        {
            int reduceRound = (int)index / reduceCount;
            if (reduceRound % 2 != 0)
            {
                var plusIndex = index - reduceRound * reduceCount;
                return startHeight / 2 + plusIndex * perReduceAmount;
            }
            else
            {
                var minusIndex = index - reduceRound * reduceCount;
                return startHeight - minusIndex * perReduceAmount;
            }
        }
        public override float GetVerticalItemPositionY(int index, RectTransform cellRect)
        {
            //return -((scrollRect.content.sizeDelta.y-cellRect.sizeDelta.y)+cellRect.sizeDelta.y+2);
            return base.GetVerticalItemPositionY (index, cellRect)-(scrollRect.content.sizeDelta.y-cellRect.sizeDelta.y);
        }
    }
}