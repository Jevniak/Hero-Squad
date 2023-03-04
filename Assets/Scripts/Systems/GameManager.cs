using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Systems
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private GameObject windowLose;
        [SerializeField] private Button buttonRestart;

        private void Awake()
        {
            Time.timeScale = 1;
            Instance = this;
            buttonRestart.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        }

        public void Lose()
        {
            windowLose.SetActive(true);
            Time.timeScale = 0;
        }
    }
}