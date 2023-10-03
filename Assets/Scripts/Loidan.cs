using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Loidan : MonoBehaviour
{
    public Button nextButton;
    public Button skipButton;

    private Sprite[] imageSprites;
    private int currentIndex = 0;
    public Image imageComponent; // Thêm trường này và kéo Image từ GameObject "ImageHolder"

    private void Start()
    {
        // Tải tất cả ảnh từ thư mục "Resources/Loidan"
        imageSprites = Resources.LoadAll<Sprite>("Loidan");

        nextButton.onClick.AddListener(ShowNextImage);
        skipButton.onClick.AddListener(ShowLastImage);

        // Hiển thị ảnh đầu tiên khi bắt đầu
        ShowImage(currentIndex);
    }

    private void ShowNextImage()
    {
        if (currentIndex < imageSprites.Length - 1)
        {
            currentIndex++;
            ShowImage(currentIndex);
        }
    }

    private void ShowLastImage()
    {
        if (imageSprites.Length > 0)
        {
            currentIndex = imageSprites.Length - 1;
            ShowImage(currentIndex);
        }
    }

    private void ShowImage(int index)
    {
        if (index >= 0 && index < imageSprites.Length)
        {
            imageComponent.sprite = imageSprites[index];
        }
    }
}
