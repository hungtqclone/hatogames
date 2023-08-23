using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockTrieuHoi : MonoBehaviour
{
    public Button countdownButton;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI coinText;
    private bool canPress = true;
    private bool countdownFinished = true; // Thêm biến kiểm tra
    private bool isSummoning = false; // Biến kiểm tra triệu hồi

    //triệu hồi lính 
    public Animator characterAnimator;
    public float summonDistance = 5.0f; // Khoảng cách triệu hồi
    public Transform summonPosition; // Vị trí triệu hồi

    private void Start()
    {
        countdownButton.onClick.AddListener(OnCountdownButtonClick);
        coinText.text = "50"; // Đặt giá trị mặc định ban đầu
    }

    private void OnCountdownButtonClick()
    {
        if (canPress && countdownFinished && !isSummoning) // Kiểm tra cả countdownFinished và isSummoning
        {
            StartCoroutine(StartCountdown());
        }
    }

    private IEnumerator StartCountdown()
    {
        canPress = false;
        countdownFinished = false; // Bắt đầu countdown

        countdownText.gameObject.SetActive(true);

        for (int i = 5; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.gameObject.SetActive(false);
        canPress = true; // Cho phép nhấn nút lại
        countdownFinished = true; // Countdown hoàn thành

        // Triệu hồi nhân vật và di chuyển
        StartCoroutine(SummonAndMoveCharacter());
    }

    private IEnumerator SummonAndMoveCharacter()
    {
        isSummoning = true;

        // Triệu hồi nhân vật
        characterAnimator.SetTrigger("linhrunne"); // Kích hoạt Trigger trong Animator
        yield return new WaitForSeconds(2.0f); // Đợi thời gian animation triệu hồi

        // Di chuyển nhân vật đến vị trí yêu cầu
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = summonPosition.position; // Vị trí triệu hồi

        float elapsedTime = 0f;
        float moveDuration = 1.0f; // Thời gian di chuyển

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isSummoning = false;
    }
}
