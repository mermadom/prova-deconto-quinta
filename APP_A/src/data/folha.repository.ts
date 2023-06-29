import { PrismaClient } from "@prisma/client";
import { Folha } from "./../models/folha.model";

const prisma = new PrismaClient();

export class FolhaRepository {
  async listar(): Promise<Folha[]> {
    return await prisma.folha.findMany();
  }

  async cadastrar(folha: Folha): Promise<Folha> {
    const folhaCadastrado = prisma.folha.create({
      data: {
        mes: folha.mes,
        ano: folha.ano,
        horas: folha.horas,
        valor: folha.valor,
        nome : folha.nome,
        cpf : folha.cpf,
      },
    });
    return folhaCadastrado;
  }
}
