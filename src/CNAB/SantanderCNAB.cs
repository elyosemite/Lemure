﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BoletoNetCore;

namespace Lemure.CNAB;

public class SantanderCNAB
{
	private readonly static string _filepath = Directory.GetCurrentDirectory();

	public static async Task ExecuteUseCase()
	{
		// Ler arquivo CNAB
		var files = new List<string>()
		{
			$"CNAB/FORN_BTPZ_75_130421P_CRI.TXT",
			$"CNAB/FORN_NI1Z_03_040723P_CRI.TXT",
			$"CNAB/FORN_NI1Z_01_060623P_MOV.TXT",
			$"CNAB/FORN_NI1Z_06_240723P_CRI.TXT",
			$"CNAB/FORN_NI1Z_05_220623P_MOV.TXT"
		};

		LoadFiles(files.AsEnumerable());
	}

	private static void LoadFiles(IEnumerable<string> files)
	{
		foreach (var file in files)
		{
			var filename = $"{_filepath}/{file}";

			using (var stream = File.OpenRead(filename))
			{
				var arquivoRetorno = new ArquivoRetorno(stream);
				Execute(arquivoRetorno.Boletos.Select(o => o.OcorrenciaParaRetornoRemessa));
			}
		}
	}

	private static void Execute(IEnumerable<string> type)
	{
		foreach (var item in type)
		{
			var message = GetDescriptionFromCode(item);
			PublishWebhook(message);
		}
	}

	private static string GetDescriptionFromCode(string code) =>
		code switch
		{
			"00" => "Crédito ou Débito Efetivado",
			"01" => "Insuficiência de Fundos - Débito Não Efetuado",
			"02" => "Crédito ou Débito Cancelado pelo Pagador/Credor",
			"03" => "Débito Autorizado pela Agência - Efetuado",
			"AA" => "Controle Inválido",
			"AB" => "Tipo de Operação Inválido",
			"AC" => "Tipo de Serviço Inválido",
			"AD" => "Forma de Lançamento Inválida",
			"AE" => "Tipo/Número de Inscrição Inválido (gerado na crítica ou para informar rejeição)",
			"AF" => "Código de Convênio Inválido",
			"AG" => "Agência/Conta Corrente/DV Inválido",
			"AH" => "Número Seqüencial do Registro no Lote Inválido",
			"AI" => "Código de Segmento de Detalhe Inválido",
			"AJ" => "Tipo de Movimento Inválido",
			"AK" => "Código da Câmara de Compensação do Banco do Favorecido/Depositário Inválido",
			"AL" => "Código do Banco do Favorecido ou Depositário Inválido",
			"AM" => "Agência Mantenedora da Conta Corrente do Favorecido Inválida",
			"AN" => "Conta Corrente/DV do Favorecido Inválido",
			"AO" => "Nome do Favorecido não Informado",
			"AP" => "Data Lançamento Inválida/Vencimento Inválido/Data de Pagamento não permitda.",
			"AQ" => "Tipo/Quantidade da Moeda Inválido",
			"AR" => "Valor do Lançamento Inválido/Divergente",
			"AS" => "Aviso ao Favorecido - Identificação Inválida",
			"AT" => "Tipo/Número de Inscrição do Favorecido/Contribuinte Inválido",
			"AU" => "Logradouro do Favorecido não Informado",
			"AV" => "Número do Local do Favorecido não Informado",
			"AW" => "Cidade do Favorecido não Informada",
			"AX" => "CEP/Complemento do Favorecido Inválido",
			"AY" => "Sigla do Estado do Favorecido Inválido",
			"AZ" => "Código/Nome do Banco Depositário Inválido",
			"BA" => "Código/Nome da Agência Depositário não Informado",
			"BB" => "Número do Documento Inválido(Seu Número)",
			"BC" => "Nosso Número Invalido",
			"BD" => "Inclusão Efetuada com Sucesso",
			"BE" => "Alteração Efetuada com Sucesso",
			"BF" => "Exclusão Efetuada com Sucesso",
			"BG" => "Bloqueado Pendente de Autorização",
			"B3" => "Bloqueado pelo cliente",
			"B4" => "Bloqueado pela captura de titulo da cobrança",
			"B8" => "Bloqueado pela Validação de Tributos",
			"CA" => "Código de barras - Código do Banco Inválido",
			"CB" => "Código de barras - Código da Moeda Inválido",
			"CC" => "Código de barras - Dígito Verificador Geral Inválido",
			"CD" => "Código de barras - Valor do Título Inválido",
			"CE" => "Código de barras - Campo Livre Inválido",
			"CF" => "Valor do Documento/Principal/menor que o minimo Inválido",
			"CH" => "Valor do Desconto Inválido",
			"CI" => "Valor de Mora Inválido",
			"CJ" => "Valor da Multa Inválido",
			"CK" => "Valor do IR Inválido",
			"CL" => "Valor do ISS Inválido",
			"CG" => "Valor do Abatimento inválido",
			"CM" => "Valor do IOF Inválido",
			"CN" => "Valor de Outras Deduções Inválido",
			"CO" => "Valor de Outros Acréscimos Inválido",
			"HA" => "Lote Não Aceito",
			"HB" => "Inscrição da Empresa Inválida para o Contrato",
			"HC" => "Convênio com a Empresa Inexistente/Inválido para o Contrato",
			"HD" => "Agência/Conta Corrente da Empresa Inexistente/Inválida para o Contrato",
			"HE" => "Tipo de Serviço Inválido para o Contrato",
			"HF" => "Conta Corrente da Empresa com Saldo Insuficiente",
			"HG" => "Lote de Serviço fora de Seqüência",
			"HH" => "Lote de Serviço Inválido",
			"HI" => "Arquivo não aceito",
			"HJ" => "Tipo de Registro Inválido",
			"HL" => "Versão de Layout Inválida",
			"HU" => "Hora de Envio Inválida",
			"IA" => "Pagamento exclusive em Cartório.",
			"IJ" => "Competência ou Período de Referencia ou Numero da Parcela invalido",
			"IL" => "Codigo Pagamento / Receita não numérico ou com zeros",
			"IM" => "Município Invalido",
			"IN" => "Numero Declaração Invalido",
			"IO" => "Numero Etiqueta invalido",
			"IP" => "Numero Notificação invalido",
			"IQ" => "Inscrição Estadual invalida",
			"IR" => "Divida Ativa Invalida",
			"IS" => "Valor Honorários ou Outros Acréscimos invalido",
			"IT" => "Período Apuração invalido",
			"IU" => "Valor ou Percentual da Receita invalido",
			"IV" => "Numero Referencia invalida",
			"SC" => "Validação parcial",
			"TA" => "Lote não Aceito - Totais do Lote com Diferença",
			"XB" => "Número de Inscrição do Contribuinte Inválido",
			"XC" => "Código do Pagamento ou Competência ou Número de Inscrição Inválido",
			"XF" => "Código do Pagamento ou Competência não Numérico ou igual á zeros",
			"YA" => "Título não Encontrado",
			"YB" => "Identificação Registro Opcional Inválido",
			"YC" => "Código Padrão Inválido",
			"YD" => "Código de Ocorrência Inválido",
			"YE" => "Complemento de Ocorrência Inválido",
			"YF" => "Alegação já Informada",
			"ZA" => "Transferencia Devolvida",
			"ZB" => "Transferencia mesma titularidade não permitida",
			"ZC" => "Código pagamento Tributo inválido",
			"ZD" => "Competência Inválida",
			"ZE" => "Título Bloqueado na base",
			"ZF" => "Sistema em Contingência - Título com valor maior que referência",
			"ZG" => "Sistema em Contingência - Título vencido",
			"ZH" => "Sistema em contingência - Título indexado",
			"ZI" => "Beneficiário divergente",
			"ZJ" => "Limite de pagamentos parciais excedido",
			"ZK" => "Título já liquidado",
			"ZT" => "Valor outras entidades inválido",
			"ZU" => "Sistema Origem Inválido",
			"ZW" => "Banco Destino não recebe DOC",
			"ZX" => "Banco Destino inoperante para DOC",
			"ZY" => "Código do Histórico de Credito Invalido",
			"ZV" => "Autorização iniciada no Internet Banking",
			"Z0" => "Conta com bloqueio",
			"Z1" => "Conta fechada. É necessário ativar a conta",
			"Z2" => "Conta com movimento controlado",
			"Z3" => "Conta cancelada",
			"Z4" => "Registro inconsistente (Título)",
			"Z5" => "Apresentação indevida (Título)",
			"Z6" => "Dados do destinatário inválidos",
			"Z7" => "Agência ou conta destinatária do crédito inválida",
			"Z8" => "Divergência na titularidade",
			"Z9" => "Conta destinatária do crédito encerrada",
			_ => $"Não existe correspondente para este código fornecido {code}"
		};

	private static void PublishWebhook(string message)
	{
		//Console.WriteLine("Enviando mensagem dia webhook...");
		Console.WriteLine(message);
	}
}
