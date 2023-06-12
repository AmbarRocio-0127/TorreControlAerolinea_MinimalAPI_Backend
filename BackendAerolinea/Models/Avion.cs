namespace BackendAerolinea.Models
{
    public class Avion
    {
        public int Id { get; set; }
        public string NombreAvion_ { get; set; }
        public TimeSpan Horasalida_ { get; set; }
        public TimeSpan Horallegada_ { get; set; }
        public string Aeropuertosalida_ { get; set; }
        public string Aeropuertollegada_ { get; set; }
        public string StatusVuelo_ { get; set; }
        public int PasajerosLimite { get; set; }
        public int LimitePeso_ { get; set; }
    }


}
