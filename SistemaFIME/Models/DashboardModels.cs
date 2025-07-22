namespace SistemaFIME.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Titulo { get; set; } = "";
        public string Avatar { get; set; } = "";
        public bool EnLinea { get; set; }
        public int Rating { get; set; }
        public int NumeroEvaluaciones { get; set; }
        public List<string> Materias { get; set; } = new();
    }

    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Codigo { get; set; } = "";
        public string Carrera { get; set; } = "";
        public List<string> Profesores { get; set; } = new();
        public int NumeroEstudiantes { get; set; }
        public decimal Rating { get; set; }
    }

    public class Comentario
    {
        public int Id { get; set; }
        public string Autor { get; set; } = "";
        public string Avatar { get; set; } = "";
        public string Contenido { get; set; } = "";
        public DateTime Fecha { get; set; }
        public int Likes { get; set; }
        public bool MeGusta { get; set; }
    }
}