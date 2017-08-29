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
    public sealed class EmployeeFingerPrintSetConverter : IEmployeeFingerPrintSetConverter<SqlDataReader>
    {
        private readonly IEmployeeManager r_EmployeeManager;

        public EmployeeFingerPrintSetConverter(IEmployeeManager employeeManager)
        {
            r_EmployeeManager = employeeManager;
        }

        private IEmployeeFingerPrintSet GetData(IEmployee employee, SqlDataReader reader)
        {
            var leftThumb = reader.GetByteArray("LeftThumb");
            var leftIndexFinger = reader.GetByteArray("LeftIndexFinger");
            var leftMiddleFinger = reader.GetByteArray("LeftMiddleFinger");
            var leftRingFinger = reader.GetByteArray("LeftRingFinger");
            var leftLittleFinger = reader.GetByteArray("LeftLittleFinger");
            var rightThumb = reader.GetByteArray("RightThumb");
            var rightIndexFinger = reader.GetByteArray("RightIndexFinger");
            var rightMiddleFinger = reader.GetByteArray("RightMiddleFinger");
            var rightRingFinger = reader.GetByteArray("RightRingFinger");
            var rightLittleFinger = reader.GetByteArray("RightLittleFinger");

            var result = new EmployeeFingerPrintSet(employee);
            result.LeftThumb.RawData = leftThumb;
            result.LeftIndexFinger.RawData = leftIndexFinger;
            result.LeftMiddleFinger.RawData = leftMiddleFinger;
            result.LeftRingFinger.RawData = leftRingFinger;
            result.LeftLittleFinger.RawData = leftLittleFinger;
            result.RightThumb.RawData = rightThumb;
            result.RightIndexFinger.RawData = rightIndexFinger;
            result.RightMiddleFinger.RawData = rightMiddleFinger;
            result.RightRingFinger.RawData = rightRingFinger;
            result.RightLittleFinger.RawData = rightLittleFinger;

            result.LeftThumb.Data = FingerPrintScannerHelper.ExtractTemplate(leftThumb);
            result.LeftIndexFinger.Data = FingerPrintScannerHelper.ExtractTemplate(leftIndexFinger);
            result.LeftMiddleFinger.Data = FingerPrintScannerHelper.ExtractTemplate(leftMiddleFinger);
            result.LeftRingFinger.Data = FingerPrintScannerHelper.ExtractTemplate(leftRingFinger);
            result.LeftLittleFinger.Data = FingerPrintScannerHelper.ExtractTemplate(leftLittleFinger);
            result.RightThumb.Data = FingerPrintScannerHelper.ExtractTemplate(rightThumb);
            result.RightIndexFinger.Data = FingerPrintScannerHelper.ExtractTemplate(rightIndexFinger);
            result.RightMiddleFinger.Data = FingerPrintScannerHelper.ExtractTemplate(rightMiddleFinger);
            result.RightRingFinger.Data = FingerPrintScannerHelper.ExtractTemplate(rightRingFinger);
            result.RightLittleFinger.Data = FingerPrintScannerHelper.ExtractTemplate(rightLittleFinger);

            return result;
        }

        private IEmployeeFingerPrintSet GetData(SqlDataReader reader)
        {
            var employeeResult = r_EmployeeManager.GetById(reader.GetInt64("Id"));

            if (employeeResult.Status == ProcessResultStatus.Success)
            {
                return GetData(employeeResult.Data, reader);
            }
            else
            {
                return null;
            }
        }

        private async Task<IEmployeeFingerPrintSet> GetDataAsync(SqlDataReader reader)
        {
            var employeeResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("Id"));

            if (employeeResult.Status == ProcessResultStatus.Success)
            {
                return GetData(employeeResult.Data, reader);
            }
            else
            {
                return null;
            }
        }

        private async Task<IEmployeeFingerPrintSet> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var employeeResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("Id"), cancellationToken);

            if (employeeResult.Status == ProcessResultStatus.Success)
            {
                return GetData(employeeResult.Data, reader);
            }
            else
            {
                return null;
            }
        }

        public IEnumerableProcessResult<IEmployeeFingerPrintSet> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeFingerPrintSet>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmployeeFingerPrintSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeFingerPrintSet>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeFingerPrintSet>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeFingerPrintSet>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IEmployeeFingerPrintSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeFingerPrintSet>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeFingerPrintSet>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IEmployeeFingerPrintSet>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IEmployeeFingerPrintSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmployeeFingerPrintSet>(ex);
            }
        }

        public IProcessResult<IEmployeeFingerPrintSet> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IEmployeeFingerPrintSet>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeFingerPrintSet>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IEmployeeFingerPrintSet>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeFingerPrintSet>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IEmployeeFingerPrintSet>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ex);
            }
        }
    }
}
