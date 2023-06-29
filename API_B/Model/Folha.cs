namespace API_B.Model;

public class Folha
{
    public long Id { get; set; }
    public int? mes { get; set; }

    public int? ano { get; set; }
    public float? horas { get; set; }
    public float? valor { get; set; }

    public float? bruto { get; set; }

    public float? irrf { get; set; }

    public float? inss { get; set; }

    public float? fgts { get; set; }

    public float? liquido { get; set; }

    public string? nome { get; set; }

    public string? cpf { get; set; }
};
