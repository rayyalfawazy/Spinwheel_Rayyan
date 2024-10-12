using UnityEngine;

public class SpinResultUI : MonoBehaviour
{
    [SerializeField] Transform resultPanel;

    private void OnEnable()
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

    private void DisplaySpinResult(PrizeData selectedPrize)
    {
        // Tambahkan logika untuk menampilkan hasil spin ke UI
    }
}
