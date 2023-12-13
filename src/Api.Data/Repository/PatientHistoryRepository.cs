using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Api.Data.Repository
{
    public class PatientHistoryRepository
    {
        private readonly string _connectionString;

        public PatientHistoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<PatientHistoryEntity>> GetPatientHistoryByCpfAsync(string cpf)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = @"
                SELECT PH.*
                FROM PatientHistory PH
                INNER JOIN Query Q ON PH.IdQuery = Q.IdQuery
                INNER JOIN Patient P ON Q.IdPatient = P.IdPatient
                INNER JOIN User U ON P.IdUser = U.IdUser
                WHERE U.CPF = @Cpf";

                var parameters = new { Cpf = cpf };
                var result = await connection.QueryAsync<PatientHistoryEntity>(query, parameters);

                return result;
            }
        }
    }
}
