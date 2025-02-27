using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool isGameOver = false;

    [SerializeField]
    private TextMeshProUGUI textGoal;
    public int goal;

    [SerializeField]
    private GameObject btnRetry;

    [SerializeField]
    private Color green;
    [SerializeField]
    private Color red;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textGoal.SetText(goal.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
	        Application.Quit(); //게임 앱 종료
        }
    }

    public void DecreaseGoal() {
        goal--;
        textGoal.SetText(goal.ToString()); // 목표 개수 업데이트

        if(goal <= 0) {
            SetGameOver(true);
        }
    }
 
    public void SetGameOver(bool success) {
        if(isGameOver == false) {
            isGameOver = true;
            // 게임 배경 색깔 바꾸기
            Camera.main.backgroundColor = success ? green : red;
            Invoke("ShowRetryButton", 1f);
        }
    }

    void ShowRetryButton() {
        btnRetry.SetActive(true); // 리트 버튼 활성화
    }

    public void Retry() {
        SceneManager.LoadScene("SampleScene");
    }
}
