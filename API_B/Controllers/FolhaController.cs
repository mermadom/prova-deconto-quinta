using Microsoft.AspNetCore.Mvc;
using API_B.Context;
using API_B.Model;

namespace API_B.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FolhaController : ControllerBase
{
    private readonly ILogger<FolhaController> _logger;
    private readonly FolhaContext contexto;

    public FolhaController(ILogger<FolhaController> logger, FolhaContext context)
    {
        _logger = logger;
        contexto = context;


    }
    [HttpGet("listar/")]
    public IEnumerable<Folha> GetListaGeral()
    {
        return contexto.Folhas;
    }

    [HttpGet("totais/")]
    public decimal GetListaTotais()
    {
        var folhas = contexto.Folhas;
        decimal total = 0;
        foreach (var folha  in folhas)
        {
            total = (decimal)(total + (decimal)folha.liquido);    
            Console.WriteLine(total);         
        }
        
        return total;
    }

    [HttpGet("medias/")]
    public string GetListaMedia()
    {
       var folhas = contexto.Folhas;
        decimal total = 0;
        int qtd = 0;
        decimal media = 0;
        
        foreach (var folha  in folhas)
        {
            total = (Decimal)(total + (decimal)folha.liquido);    
            qtd = qtd+1;     
        }
        media = total/qtd;
        String resposta = " Quantidade: "+qtd+"\n Total: "+total+"\n Media: "+media;
        return resposta;
    }

}
