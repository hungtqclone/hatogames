using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class ClockTrieuHoi : MonoBehaviour
{
    public Button countdownButton;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI coinText; // Thêm reference đến TextMeshProUGUI hiển thị số coin
    private bool canPress = true;

    private void Start()
    {
        countdownButton.onClick.AddListener(OnCountdownButtonClick);
        coinText.text = "50"; // Đặt giá trị mặc định ban đầu
    }

    private void OnCountdownButtonClick()
    {
        if (canPress)
        {
            StartCoroutine(StartCountdown());
        }
    }

    private IEnumerator StartCountdown()
    {
        canPress = false;

        countdownText.gameObject.SetActive(true);

        for (int i = 5; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.gameObject.SetActive(false);
        canPress = true; // Cho phép nhấn nút lại

        // Hiển thị mặc định là 50 coin sau khi đếm ngược xong
        coinText.text = "50";
    }
}
