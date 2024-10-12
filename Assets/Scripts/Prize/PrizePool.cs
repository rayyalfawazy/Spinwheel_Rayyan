using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizePool : MonoBehaviour, IPrizePool
{
    [Header("Prize Pools")]
    [SerializeField] private PrizeData prizePrefab;
    [SerializeField] private Transform spinPanel;
    [SerializeField] private int prizeToPool;
    [Header("Prize List")]
    [SerializeField] private List<PrizeDataSO> prizeDataSO;

    private List<PrizeData> _prizePools = new List<PrizeData>();

    void Start()
    {
        PrizePoolSetup(prizeToPool);
    }

    private void PrizePoolSetup(int poolAmount)
    {
        for (int i = 0; i < poolAmount; i++)
        {
            var prize = Instantiate(prizePrefab, spinPanel);
            prize.Initialize(prizeDataSO[Random.Range(0, prizeDataSO.Count)]);
            _prizePools.Add(prize);
        }
    }

    // Implementasi dari IPrizePool
    public int GetPrizeCount()
    {
        return _prizePools.Count;
    }

    public PrizeData GetPrize(int index)
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
