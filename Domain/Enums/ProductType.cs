namespace POO_A3_Pet.Domain.Enums
{
    // A enumeração ProductType define dois tipos possíveis de produtos:
    // "Service" e "Product". O uso de enums ajuda a garantir que os valores
    // para o tipo de produto sejam limitados a um conjunto pré-definido e bem controlado.
    // A enumeração ajuda a garantir a **segurança de tipo** e melhora a legibilidade do código.
    public enum ProductType
    {
        // "Service" representa um tipo de produto relacionado a um serviço,
        // e é atribuído o valor 0, que é o valor padrão caso não seja especificado.
        Service = 0,

        // "Product" representa um tipo de produto físico, e é atribuído o valor 1.
        Product = 1
    }
}