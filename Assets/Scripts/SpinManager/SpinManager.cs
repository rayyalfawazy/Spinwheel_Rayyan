using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinManager : MonoBehaviour
{
    public static SpinManager Instance { get; private set; } // Singleton implementation

    [Header("Spinner Settings")]
    [SerializeField] private Button spinButton;
    [SerializeField] private float spinDuration; // Durasi total perputaran
    [SerializeField] private float initialSpeed; // Kecepatan awal
    [SerializeField] private float finalSpeed;   // Kecepatan akhir saat berhenti

    private bool isSpinning = false;
    private IPrizePool prizePool;

    public event System.Action<PrizeData> OnSpinCompleted; // Observer pattern

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
            DontDestroyOnLoad(this.gameObject); // Persistent Singleton
        }
    }

    void Start()
    {
        prizePool = GetComponent<IPrizePool>(); // Dependency inversion
        HandleSpin();
    }

    private void HandleSpin()
    {
        spinButton.onClick.AddListener(() =>
        {
            if (!isSpinning)
            {
                StartCoroutine(SpinWheel());
            }
        });
    }

    private IEnumerator SpinWheel()
    {
        isSpinning = true;

        // Step 1: Pilih index target secara acak di awal spin
        int targetIndex = Random.Range(0, prizePool.GetPrizeCount());

        int currentIndex = 0;
        float spinDuration = this.spinDuration;
        float initialSpeed = this.initialSpeed;
        float finalSpeed = this.finalSpeed;
        int totalPrizeCount = prizePool.GetPrizeCount();

        int totalSpinCycles = Random.Range(3, 5); // Untuk membuat roda spin beberapa putaran penuh sebelum melambat
        int targetFullIndex = totalSpinCycles * totalPrizeCount + targetIndex; // Index total menuju target dengan beberapa putaran penuh

        // Step 2: Looping untuk spin, semakin lambat seiring waktu
        while (currentIndex < targetFullIndex)
        {
            prizePool.ResetPrizeColors(); // Reset warna
            prizePool.HighlightPrize(currentIndex % totalPrizeCount, Color.red); // Highlight prize yang saat ini aktif

            currentIndex++;

            // Menghitung kecepatan spin current speed
            float t = (float)currentIndex / targetFullIndex; // Normalisasi waktu berdasarkan index spin dan target akhir
            float currentSpeed = Mathf.Lerp(initialSpeed, finalSpeed, t); // Kecepatan melambat seiring waktu

            yield return new WaitForSeconds(currentSpeed);
        }

        // Step 3: Spin berhenti di targetIndex
        prizePool.ResetPrizeColors();
        prizePool.HighlightPrize(targetIndex, Color.red); // Highlight prize terpilih
        OnSpinCompleted?.Invoke(prizePool.GetPrize(targetIndex)); // Notify observers

        isSpinning = false;
    }
}