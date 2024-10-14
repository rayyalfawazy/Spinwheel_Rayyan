using UnityEngine;
using UnityEngine.UI;

public class SpinButton : MonoBehaviour
{
    private Button spinButton;

    private void Awake()
    {
        spinButton = GetComponent<Button>();
        spinButton.onClick.AddListener(OnSpinButtonClicked); // Menambahkan listener ke onClick
    }

    private void OnSpinButtonClicked()
    {
        if (SpinManager.Instance != null)
        {
            if (!SpinManager.Instance.IsSpinning)
            {
                SpinManager.Instance.HandleSpin(); // Memanggil fungsi HandleSpin pada SpinManager saat tombol di klik
                SetButtonActive(false);
            }
        }
    }

    public void SetButtonActive(bool active)
    {
        spinButton.interactable = active;
    }
}

