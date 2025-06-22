using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace MMAR.ScrollSystem.Demo
{
    public class JumpTo : MonoBehaviour
    {
        [SerializeField] TMP_InputField inputField;
        public TweenType tweenType;
        public float duration = .3f;
        public UnityEvent<int,float, TweenType> jumpToEvent;

        public void JumpToInvoke()
        {
            if(inputField.text != "")
            {
                jumpToEvent.Invoke(int.Parse(inputField.text),duration, tweenType);
            }
        }
    }
}