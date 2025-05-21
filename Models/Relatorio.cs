using System;

namespace YourApp.Models
{
    public class Relatorio
    {
        // Dados da OS
        public string OsNumero { get; set; }
        public DateTime DataOs { get; set; }
        public TimeSpan HoraOs { get; set; }
        public string Contrato { get; set; }
        public string Garantia { get; set; }
        public string EventualPagamento { get; set; }
        public string Demonstracao { get; set; }
        public string Equipamento { get; set; }

        // Dados do Cliente
        public string ClienteRazaoSocial { get; set; }
        public string ClienteCnpj { get; set; }
        public string ClienteEndereco { get; set; }
        public string ClienteCidade { get; set; }

        // Dados do Usuário
        public string UsuarioNome { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioTelefone { get; set; }
        public string UsuarioSalaAndar { get; set; }

        // Atendimento
        public DateTime DataAtendimento { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public string SerieCorreta { get; set; }

        // Relato e Solução
        public string DefeitoRelatado { get; set; }
        public string DefeitoConstatado { get; set; }
        public string Solucao { get; set; }

        // Intervenções e Pendências
        public bool EquipParado { get; set; }
        public bool EquipComPendencia { get; set; }
        public bool EquipOk { get; set; }
        public string InformarPendencia { get; set; }

        // Assinaturas
        public string AssinaturaCliente { get; set; }
        public string AssinaturaTecnico { get; set; }
    }
}
