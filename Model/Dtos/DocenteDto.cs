namespace Model.Dtos
{
    public class DocenteDto
    {
        public int DocenteId { get; set; }

        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {PrimerApellido}";
            }
        }
    }
}
