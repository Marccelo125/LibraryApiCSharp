namespace LibraryApi.Models
{
    public class ResponseModel<T>
        // O <T> diz que podemos receber dados do tipo generico,
        // pois podemos ter tanto dados do tipo Author quanto
        // dados do tipo Book
    {
        public T? Data { get; set; }
        // T? - Dado generico e pode ser nulo (?)
        public string Message { get; set; } = string.Empty;
        // =string.Empty - Diz o valor padrão para a string, que é vazia "", se não passarmos nada
        public bool Status{ get; set; } = true;
    
    }
}
