using TMPro;
using UnityEngine;

public class SpinResultUI : MonoBehaviour
{
    [Header("Result UI")]
    [SerializeField] Transform resultPanel;
    [SerializeField] TMP_Text resultText;

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
}