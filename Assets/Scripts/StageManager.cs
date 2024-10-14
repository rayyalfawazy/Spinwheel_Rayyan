using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] private TMP_Text amountText;
    [SerializeField] private SpinResultUI spinResult;
    [SerializeField] private Button quitButton;

    private int prizeAmount;
    private IPrizePool prizePool;

    void Start()
    {
        prizePool = GetComponent<IPrizePool>();
        spinResult.claimButton.onClick.AddListener(ClaimPrize);
        quitButton.onClick.AddListener(Quit);
    }

    private void ClaimPrize()
    {
        prizeAmount += prizePool.GetPrize(SpinManager.Instance.TargetIndex).PrizeValue;
        amountText.text = $"Money: ${prizeAmount}";
        spinResult.HideSpinResult();
    }

    private void Quit()
    {
        Application.Quit();
    }
}
