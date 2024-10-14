using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrizeBox : MonoBehaviour
{
    [SerializeField] private TMP_Text prizeNameText;

    private int prizeValue;
    public int PrizeValue {  
        get { return prizeValue; }
        set { prizeValue = value; }
    }

    // Metode untuk menginisialisasi data dari Scriptable Object
    public void Initialize(int value)
    {
        PrizeValue = value;
        prizeNameText.text = $"${prizeValue}";
    }
}
