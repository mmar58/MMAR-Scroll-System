using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMAR.Helpers
{
    public class RectTransformHelper
    {
        public static Vector3[] GetWorldCorners(RectTransform rectTransform)
        {
            var corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);
            return corners;
        }
    }
}
