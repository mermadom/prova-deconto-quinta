import { Request, Response } from "express";
import { FolhaRepository } from "../data/folha.repository";
import { Folha } from "../models/folha.model";
import axios from "axios";
import { Calculos } from "../utils/calculos";
import { RabbitMQService } from "../services/rabbitmq.service";

const repository = new FolhaRepository();
const service = new RabbitMQService();

export class FolhaController {
  async listar(request: Request, response: Response) {
    const folhas = await repository.listar();
    return response.status(200).json({
      message: "ok",
      data: folhas,
    });
  }

  async cadastrar(request: Request, response: Response) {
    let folha: Folha = request.body;
    folha = await repository.cadastrar(folha);
    let calculos = new Calculos();
    folha.bruto = calculos.calcularBruto(folha.horas, folha.valor);
    folha.inss = calculos.calcularINSS(folha.bruto);
    folha.irrf = calculos.calcularIRRF(folha.bruto);
    folha.fgts = calculos.calcularFGTS(folha.bruto);
    folha.liquido = calculos.calcularLiquido(
      folha.bruto,
      folha.inss,
      folha.irrf
    );

    service.enviar(JSON.stringify(folha));
    
    return response.status(201).json({
      message: "foia cadastrada!",
      data: folha,
    });
  }
}
