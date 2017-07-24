using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class ExamConverter : IExamConverter<SqlDataReader>
    {
        private readonly IApplicationManager r_ApplicationManager;
        private readonly IExamSetManager r_ExamSetManager;

        public ExamConverter(
            IApplicationManager applicationManager,
            IExamSetManager examSetManager)
        {
            r_ApplicationManager = applicationManager;
            r_ExamSetManager = examSetManager;
        }

        private Exam GetData(Application application, ExamSet set, SqlDataReader reader)
        {
            if (application != null)
            {
                return new Exam(application)
                {
                    Id = reader.GetInt64("Id"),
                    Date = reader.GetDateTime("Date"),
                    Set = set,
                    TotalScore = reader.GetInt32("TotalScore")
                };
            }
            else
            {
                return null;
            }
        }

        private Exam GetData(SqlDataReader reader)
        {
            var applicationResult = r_ApplicationManager.GetById(reader.GetInt64("ApplicationId"));
            var setResult = r_ExamSetManager.GetById(reader.GetInt32("SetId"));

            return GetData(applicationResult.Data, setResult.Data, reader);
        }

        private async Task<Exam> GetDataAsync(SqlDataReader reader)
        {
            var applicationResult = await r_ApplicationManager.GetByIdAsync(reader.GetInt64("ApplicationId"));
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"));

            return GetData(applicationResult.Data, setResult.Data, reader);
        }

        private async Task<Exam> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var applicationResult = await r_ApplicationManager.GetByIdAsync(reader.GetInt64("ApplicationId"), cancellationToken);
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"), cancellationToken);

            return GetData(applicationResult.Data, setResult.Data, reader);
        }

        public IEnumerableProcessResult<Exam> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Exam>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Exam>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Exam>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Exam>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Exam>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<Exam>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Exam>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Exam>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Exam>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<Exam>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Exam>(ex);
            }
        }

        public IProcessResult<Exam> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<Exam>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Exam>(ex);
            }
        }

        public async Task<IProcessResult<Exam>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<Exam>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Exam>(ex);
            }
        }

        public async Task<IProcessResult<Exam>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<Exam>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Exam>(ex);
            }
        }
    }
}
