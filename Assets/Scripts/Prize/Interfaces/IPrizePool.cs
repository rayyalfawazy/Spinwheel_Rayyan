using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPrizePool
{
    void ResetPrizeColors();          // Reset semua warna ke default (putih)
    void HighlightPrize(int index, Color color); // Highlight hadiah tertentu
    int GetPrizeCount();              // Mendapatkan jumlah hadiah dalam pool
    PrizeData GetPrize(int index);    // Mengambil hadiah berdasarkan index
}