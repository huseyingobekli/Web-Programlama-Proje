﻿namespace webprogramlama4.Models
{
    public enum RandevuDurum
    {
        Beklemede,
        Onaylandı,
        Tamamlandı,
        IptalEdildi
    }

    public class Randevu
    {
        public int randevuId { get; set; }
        public DateTime RandevuTarihSaat { get; set; }
        public int CalisanId { get; set; }
        public int musteriId { get; set; }
        public int islemId { get; set; }

        public Calisan Calisan { get; set; }
        public Musteri musteri { get; set; }
        public Islem Islem { get; set; }

        public RandevuDurum Durum { get; set; } = RandevuDurum.Beklemede;
    }


}

