using System.ComponentModel.DataAnnotations;

namespace MusicStore.DB.Enums
{
    public enum MusicTempo
    {
        [Display(Name = "Очень медленно, значительно, торжественно, тяжело")]
        Grave,
        [Display(Name = "Широко, очень медленно")]
        Largo,
        [Display(Name = "Протяжно")]
        Largamente,
        [Display(Name = "Медленно, спокойно")]
        Adagio,
        [Display(Name = "Медленно, слабо, тихо, скорее, чем largo")]
        Lento,
        [Display(Name = "Медленно, слабо, тихо, скорее, чем lento")]
        Lentamente,
        [Display(Name = "Довольно широко")]
        Larghetto,
        [Display(Name = "Очень спокойным шагом")]
        AndanteAssai,
        [Display(Name = "Довольно медленно, но подвижнее, чем adagio")]
        Adagietto,
        [Display(Name = "Умеренный темп, в характере шага")]
        Andante,
        [Display(Name = "Торжественным шагом")]
        AndanteMaestoso,
        [Display(Name = "Оживлённым шагом")]
        AndanteMosso,
        [Display(Name = "Удобно")]
        Comodo,
        [Display(Name = "Непринуждённо, не спеша")]
        Comodamente,
        [Display(Name = "Небыстрым шагом")]
        AndanteNonTroppo,
        [Display(Name = "Непринуждённо, не спеша")]
        AndanteConMoto,
        [Display(Name = "Скорее, чем andante, но медленнее, чем allegretto")]
        Andantino,
        [Display(Name = "Очень умеренно")]
        ModeratoAssai,
        [Display(Name = "Умеренно, сдержанно")]
        Moderato,
        [Display(Name = "С движением")]
        ConMoto,
        [Display(Name = "Умеренно оживлённо")]
        AllegrettoModerato,
        [Display(Name = "Медленнее, чем allegro, но скорее, чем andante")]
        Allegretto,
        [Display(Name = "Быстрее, чем allegretto")]
        AllegrettoMosso,
        [Display(Name = "Оживлённо")]
        Animato,
        [Display(Name = "Очень оживлённо")]
        AnimatoAssai,
        [Display(Name = "Умеренно быстро")]
        AllegroModerato,
        [Display(Name = "В темпе марша")]
        TempoDiMarcia,
        [Display(Name = "Скоро, но не слишком")]
        AllegroMaNonTroppo,
        [Display(Name = "Скоро, но спокойно")]
        AllegroTranquillo,
        [Display(Name = "Скорый темп")]
        Allegro,
        [Display(Name = "Весьма скоро")]
        AllegroMolto,
        [Display(Name = "Весьма скоро")]
        AllegroAssai,
        [Display(Name = "Весьма скоро, взволнованно")]
        AllegroAgitato,
        [Display(Name = "Очень скоро")]
        AllegroAnimato,
        [Display(Name = "Значительно скоро, почти vivo")]
        AllegroVivace,
        [Display(Name = "Живо")]
        Vivo,
        [Display(Name = "Очень живо")]
        Vivace,
        [Display(Name = "Быстро")]
        Presto,
        [Display(Name = "Очень быстро (предельно)")]
        Prestissimo
    }
}
