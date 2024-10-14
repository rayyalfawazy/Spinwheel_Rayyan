using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizePool : MonoBehaviour, IPrizePool
{
    [Header("Prize Pools")]
    [SerializeField] private PrizeBox prizePrefab;
    [SerializeField] private Transform spinPanel;

    [Header("Prize List")]
    [SerializeField, Tooltip("Prize Data can be added with Integers")] 
    private List<int> prizeValues; // mengisi semua angka untuk penampungan Integer

    private List<PrizeBox> _prizePools = new List<PrizeBox>();

    void Start()
    {
        PrizePoolSetup(prizeValues.Count);
    }

    private void PrizePoolSetup(int poolAmount)
    {
        for (int i = 0; i < poolAmount; i++)
        {
            var prize = Instantiate(prizePrefab, spinPanel);
            prize.Initialize(prizeValues[i]);
            _prizePools.Add(prize);
        }
    }

    // Implementasi dari IPrizePool
    public int GetPrizeCount()
    {
        return _prizePools.Count;
    }

    public PrizeBox GetPrize(int index)
    {
        return _prizePools[index];
    }

    public void HighlightPrize(int index, Color color)
    {
        _prizePools[index].GetComponent<Image>().color = color;
    }

    public void ResetPrizeColors()
    {
        foreach (var prize in _prizePools)
        {
            prize.GetComponent<Image>().color = Color.white;
        }
    }
}
