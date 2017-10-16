using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class ExamConverter : IExamConverter
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

        private IExam GetData(IApplication application, IExamSet set, DbDataReader reader)
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

        private IExam GetData(DbDataReader reader)
        {
            var applicationResult = r_ApplicationManager.GetById(reader.GetInt64("ApplicationId"));
            var setResult = r_ExamSetManager.GetById(reader.GetInt32("SetId"));

            return GetData(applicationResult.Data, setResult.Data, reader);
        }

        private async Task<IExam> GetDataAsync(DbDataReader reader)
        {
            var applicationResult = await r_ApplicationManager.GetByIdAsync(reader.GetInt64("ApplicationId"));
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"));

            return GetData(applicationResult.Data, setResult.Data, reader);
        }

        private async Task<IExam> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var applicationResult = await r_ApplicationManager.GetByIdAsync(reader.GetInt64("ApplicationId"), cancellationToken);
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"), cancellationToken);

            return GetData(applicationResult.Data, setResult.Data, reader);
        }

        public IEnumerableProcessResult<IExam> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IExam>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IExam>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExam>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IExam>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IExam>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IExam>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExam>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IExam>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IExam>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IExam>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExam>(ex);
            }
        }

        public IProcessResult<IExam> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IExam>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExam>(ex);
            }
        }

        public async Task<IProcessResult<IExam>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IExam>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExam>(ex);
            }
        }

        public async Task<IProcessResult<IExam>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IExam>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExam>(ex);
            }
        }
    }
}
