using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class ExamSetConverter : IExamSetConverter<SqlDataReader>
    {
        private ExamSet GetData(SqlDataReader reader)
        {
            return new ExamSet()
            {
                Id = reader.GetInt32("Id"),
                Description = reader.GetString("Description"),
                PassingScore = reader.GetInt32("PassingScore")
            };
        }

        public IEnumerableProcessResult<ExamSet> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<ExamSet>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ExamSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ExamSet>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ExamSet>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<ExamSet>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ExamSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ExamSet>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ExamSet>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<ExamSet>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ExamSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ExamSet>(ex);
            }
        }

        public IProcessResult<ExamSet> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<ExamSet>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ExamSet>(ex);
            }
        }

        public async Task<IProcessResult<ExamSet>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<ExamSet>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ExamSet>(ex);
            }
        }

        public async Task<IProcessResult<ExamSet>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<ExamSet>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ExamSet>(ex);
            }
        }
    }
}
