using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMAR.ScrollSystem.Demo
{
    public class DifferentWidthController : Controller
    {
        public int reduceCount = 10;
        public float perReduceAmount = 10;
        public float startWidth;
        private void Start()
        {
            scrollRect.content.sizeDelta = new Vector2(startWidth, scrollRect.content.sizeDelta.y);
            for (int i = 0; i < 100; i++)
            {
                AddData(new SimpleData("Index " + i));
            }
        }
        public override float GetWidth(int index)
        {
            int reduceRound = (int)index / reduceCount;
            if (reduceRound % 2 != 0)
            {
                var plusIndex = index - reduceRound * reduceCount;
                return startWidth / 2 + plusIndex * perReduceAmount;
            }
            else
            {
                var minusIndex = index - reduceRound * reduceCount;
                return startWidth - minusIndex * perReduceAmount;
            }
        }
    }
}