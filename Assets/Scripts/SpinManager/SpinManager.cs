using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpinManager : MonoBehaviour
{
    public static SpinManager Instance { get; private set; } // Singleton implementation

    [Header("Spinner Settings")]
    [SerializeField] private float spinDuration; // Durasi total perputaran
    [SerializeField] private float initialSpeed; // Kecepatan awal
    [SerializeField] private float finalSpeed;   // Kecepatan akhir saat berhenti

    private bool isSpinning = false;
    public bool IsSpinning { get { return isSpinning; } }

    private int targetIndex;
    public int TargetIndex { get { return targetIndex; } }

    private IPrizePool prizePool;

    public event System.Action<PrizeBox> OnSpinCompleted; // Observe Spin Complete
    
    private void Awake()
    {
        // Singleton initialization
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        prizePool = GetComponent<IPrizePool>(); 
    }

    public void HandleSpin()
    {
        StartCoroutine(SpinWheel());
    }

    private IEnumerator SpinWheel()
    {
        isSpinning = true;

        int currentIndex = 0; 
        float spinDuration = this.spinDuration; 
        float initialSpeed = this.initialSpeed; 
        float finalSpeed = this.finalSpeed;
        int totalPrizeCount = prizePool.GetPrizeCount();

        targetIndex = Random.Range(0, totalPrizeCount); // Index Target Pilihan

        int totalSpinCycles = Random.Range(3, 5);
        int targetFullIndex = totalSpinCycles * totalPrizeCount + targetIndex;

        while (currentIndex < targetFullIndex)
        {
            prizePool.ResetPrizeColors();
            prizePool.HighlightPrize(currentIndex % totalPrizeCount, Color.red);

            currentIndex++;

            float t = (float)currentIndex / targetFullIndex;
            float currentSpeed = Mathf.Lerp(initialSpeed, finalSpeed, t);

            yield return new WaitForSeconds(currentSpeed);
        }

        prizePool.ResetPrizeColors();
        prizePool.HighlightPrize(targetIndex, Color.red);
        OnSpinCompleted?.Invoke(prizePool.GetPrize(targetIndex));

        isSpinning = false;
    }
}