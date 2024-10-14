using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinResultUI : MonoBehaviour
{
    [Header("Result UI")]
    public Transform resultPanel;
    public TMP_Text resultText;
    public Button claimButton;

    private void Start()
    {
        if (SpinManager.Instance != null)
        {
            SpinManager.Instance.OnSpinCompleted += DisplaySpinResult;
        }
    }

    private void OnDisable()
    {
        if (SpinManager.Instance != null)
        {
            SpinManager.Instance.OnSpinCompleted -= DisplaySpinResult;
        }
    }

    public void DisplaySpinResult(PrizeBox selectedPrize)
    {
        resultPanel.gameObject.SetActive(true);
        resultText.text = $"Anda mendapatakan ${selectedPrize.PrizeValue}";
    }

    public void HideSpinResult()
    {
        resultPanel.gameObject.SetActive(false);
    }
}