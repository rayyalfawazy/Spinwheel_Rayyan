using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrizeData : MonoBehaviour
{
    [SerializeField] private TMP_Text prizeNameText;

    private PrizeDataSO prizeDataSO;

    // Metode untuk menginisialisasi data dari Scriptable Object
    public void Initialize(PrizeDataSO data)
    {
        this.prizeDataSO = data;
        prizeNameText.text = $"${data.prizeValue.ToString()}";
    }
}
