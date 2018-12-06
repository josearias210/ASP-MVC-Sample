namespace Wonder.Core.Models
{
    public class Resultado<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public int Codigo { get; set; }
        public T Data { get; set; }

        public Resultado()
        {
            IsSuccess = true;
            Codigo = 200;
        }

        public static Resultado<T> GenerarError(string error, int codigo = 500)
        {
            var r = new Resultado<T>
            {
                Error = error,
                IsSuccess = false,
                Codigo = codigo,
            };
            return r;
        }

    }
}
