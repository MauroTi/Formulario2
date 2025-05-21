using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Formulario2.Models;
using YourApp.Models;
using Microsoft.Data.SqlClient;

namespace Formulario2.Dao
{
    public class RelatorioDao
    {
        private readonly string _connString;

        public RelatorioDao()
        {
            // Monta o builder de configuração para ler appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Lê a connection string "ErpAlfa" e valida
            _connString = configuration.GetConnectionString("ErpAlfa")
                ?? throw new InvalidDataException(
                    "ConnectionStrings:ErpAlfa não encontrada em appsettings.json");
        }

        /// <summary>
        /// Testa se consegue abrir e fechar a conexão.
        /// </summary>
        public bool TestarConexao()
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                conn.Open();
                return conn.State == ConnectionState.Open;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Insere um novo relatório na tabela Relatorios (exemplo).
        /// </summary>
        public void InserirRelatorio(Relatorio model)
        {
            const string sql = @"
                INSERT INTO Relatorios
                    (OsNumero, DataOs, HoraOs, Contrato, Garantia, EventualPagamento,
                     Demonstracao, Equipamento, ClienteRazaoSocial, ClienteCnpj,
                     ClienteEndereco, ClienteCidade, UsuarioNome, UsuarioEmail,
                     UsuarioTelefone, UsuarioSalaAndar, DataAtendimento, HoraInicio,
                     HoraTermino, SerieCorreta, DefeitoRelatado, DefeitoConstatado,
                     Solucao, EquipParado, EquipComPendencia, EquipOk,
                     InformarPendencia, AssinaturaCliente, AssinaturaTecnico)
                VALUES
                    (@OsNumero, @DataOs, @HoraOs, @Contrato, @Garantia, @EventualPagamento,
                     @Demonstracao, @Equipamento, @ClienteRazaoSocial, @ClienteCnpj,
                     @ClienteEndereco, @ClienteCidade, @UsuarioNome, @UsuarioEmail,
                     @UsuarioTelefone, @UsuarioSalaAndar, @DataAtendimento, @HoraInicio,
                     @HoraTermino, @SerieCorreta, @DefeitoRelatado, @DefeitoConstatado,
                     @Solucao, @EquipParado, @EquipComPendencia, @EquipOk,
                     @InformarPendencia, @AssinaturaCliente, @AssinaturaTecnico)";

            using var conn = new SqlConnection(_connString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@OsNumero", model.OsNumero);
            cmd.Parameters.AddWithValue("@DataOs", model.DataOs);
            cmd.Parameters.AddWithValue("@HoraOs", model.HoraOs);
            cmd.Parameters.AddWithValue("@Contrato", model.Contrato);
            cmd.Parameters.AddWithValue("@Garantia", model.Garantia);
            cmd.Parameters.AddWithValue("@EventualPagamento", model.EventualPagamento);
            cmd.Parameters.AddWithValue("@Demonstracao", model.Demonstracao);
            cmd.Parameters.AddWithValue("@Equipamento", model.Equipamento);
            cmd.Parameters.AddWithValue("@ClienteRazaoSocial", model.ClienteRazaoSocial);
            cmd.Parameters.AddWithValue("@ClienteCnpj", model.ClienteCnpj);
            cmd.Parameters.AddWithValue("@ClienteEndereco", model.ClienteEndereco);
            cmd.Parameters.AddWithValue("@ClienteCidade", model.ClienteCidade);
            cmd.Parameters.AddWithValue("@UsuarioNome", model.UsuarioNome);
            cmd.Parameters.AddWithValue("@UsuarioEmail", model.UsuarioEmail);
            cmd.Parameters.AddWithValue("@UsuarioTelefone", model.UsuarioTelefone);
            cmd.Parameters.AddWithValue("@UsuarioSalaAndar", model.UsuarioSalaAndar);
            cmd.Parameters.AddWithValue("@DataAtendimento", model.DataAtendimento);
            cmd.Parameters.AddWithValue("@HoraInicio", model.HoraInicio);
            cmd.Parameters.AddWithValue("@HoraTermino", model.HoraTermino);
            cmd.Parameters.AddWithValue("@SerieCorreta", model.SerieCorreta);
            cmd.Parameters.AddWithValue("@DefeitoRelatado", model.DefeitoRelatado);
            cmd.Parameters.AddWithValue("@DefeitoConstatado", model.DefeitoConstatado);
            cmd.Parameters.AddWithValue("@Solucao", model.Solucao);
            cmd.Parameters.AddWithValue("@EquipParado", model.EquipParado);
            cmd.Parameters.AddWithValue("@EquipComPendencia", model.EquipComPendencia);
            cmd.Parameters.AddWithValue("@EquipOk", model.EquipOk);
            cmd.Parameters.AddWithValue("@InformarPendencia", model.InformarPendencia);
            cmd.Parameters.AddWithValue("@AssinaturaCliente", model.AssinaturaCliente);
            cmd.Parameters.AddWithValue("@AssinaturaTecnico", model.AssinaturaTecnico);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Busca todos os relatórios.
        /// </summary>
        public IEnumerable<Relatorio> ListarTodos()
        {
            var lista = new List<Relatorio>();
            const string sql = "SELECT * FROM Relatorios ORDER BY DataOs DESC";

            using var conn = new SqlConnection(_connString);
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();

            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lista.Add(new Relatorio
                {
                    OsNumero = rdr["OsNumero"].ToString(),
                    DataOs = Convert.ToDateTime(rdr["DataOs"]),
                    HoraOs = TimeSpan.Parse(rdr["HoraOs"].ToString()),
                    Contrato = rdr["Contrato"].ToString(),
                    Garantia = rdr["Garantia"].ToString(),
                    EventualPagamento = rdr["EventualPagamento"].ToString(),
                    Demonstracao = rdr["Demonstracao"].ToString(),
                    Equipamento = rdr["Equipamento"].ToString(),
                    ClienteRazaoSocial = rdr["ClienteRazaoSocial"].ToString(),
                    ClienteCnpj = rdr["ClienteCnpj"].ToString(),
                    ClienteEndereco = rdr["ClienteEndereco"].ToString(),
                    ClienteCidade = rdr["ClienteCidade"].ToString(),
                    UsuarioNome = rdr["UsuarioNome"].ToString(),
                    UsuarioEmail = rdr["UsuarioEmail"].ToString(),
                    UsuarioTelefone = rdr["UsuarioTelefone"].ToString(),
                    UsuarioSalaAndar = rdr["UsuarioSalaAndar"].ToString(),
                    DataAtendimento = Convert.ToDateTime(rdr["DataAtendimento"]),
                    HoraInicio = TimeSpan.Parse(rdr["HoraInicio"].ToString()),
                    HoraTermino = TimeSpan.Parse(rdr["HoraTermino"].ToString()),
                    SerieCorreta = rdr["SerieCorreta"].ToString(),
                    DefeitoRelatado = rdr["DefeitoRelatado"].ToString(),
                    DefeitoConstatado = rdr["DefeitoConstatado"].ToString(),
                    Solucao = rdr["Solucao"].ToString(),
                    EquipParado = Convert.ToBoolean(rdr["EquipParado"]),
                    EquipComPendencia = Convert.ToBoolean(rdr["EquipComPendencia"]),
                    EquipOk = Convert.ToBoolean(rdr["EquipOk"]),
                    InformarPendencia = rdr["InformarPendencia"].ToString(),
                    AssinaturaCliente = rdr["AssinaturaCliente"].ToString(),
                    AssinaturaTecnico = rdr["AssinaturaTecnico"].ToString()
                });
            }

            return lista;
        }
    }
}
