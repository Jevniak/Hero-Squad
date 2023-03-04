using System;
using TMPro;
using UnityEngine;

namespace Systems
{
    public class FpsCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text textFpsCount;
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            textFpsCount.text = $"FPS: {(int)(1/Time.deltaTime)}";
        }
    }
}
