using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class ExamSetConverter : IExamSetConverter
    {
        private IExamSet GetData(DbDataReader reader)
        {
            return new ExamSet()
            {
                Id = reader.GetInt32("Id"),
                Description = reader.GetString("Description"),
                PassingScore = reader.GetInt32("PassingScore")
            };
        }

        public IEnumerableProcessResult<IExamSet> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IExamSet>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IExamSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExamSet>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IExamSet>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IExamSet>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IExamSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExamSet>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IExamSet>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IExamSet>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IExamSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExamSet>(ex);
            }
        }

        public IProcessResult<IExamSet> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IExamSet>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExamSet>(ex);
            }
        }

        public async Task<IProcessResult<IExamSet>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IExamSet>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExamSet>(ex);
            }
        }

        public async Task<IProcessResult<IExamSet>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IExamSet>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExamSet>(ex);
            }
        }

        public void InitializeDependency()
        {
            // TODO: Initialize Entity Managers
        }
    }
}
