﻿using DPFP;
using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcessHelpers.HumanResource
{
    internal static class EmployeeFingerPrintSetProcessHelper
    {
        static EmployeeFingerPrintSetProcessHelper()
        {
            EmployeeManager = SystemRuntime.Services.GetService<IEmployeeManager>();
        }

        private static readonly IEmployeeManager EmployeeManager;

        private static EmployeeFingerPrintSet GetData(SqlDataReader reader)
        {
            var employeeResult = EmployeeManager.GetById(reader.GetInt64("Id"));

            if (employeeResult.Status == ProcessResultStatus.Success)
            {
                var result = new EmployeeFingerPrintSet(employeeResult.Data);
                result.LeftThumb.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftThumb"));
                result.LeftIndexFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftIndexFinger"));
                result.LeftMiddleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftMiddleFinger"));
                result.LeftRingFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftRingFinger"));
                result.LeftLittleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftLittleFinger"));
                result.RightThumb.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightThumb"));
                result.RightIndexFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightIndexFinger"));
                result.RightMiddleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightMiddleFinger"));
                result.RightRingFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightRingFinger"));
                result.RightLittleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightLittleFinger"));

                return result;
            }
            else
            {
                return null;
            }
        }

        private static async Task<EmployeeFingerPrintSet> GetDataAsync(SqlDataReader reader)
        {
            var employeeResult = await EmployeeManager.GetByIdAsync(reader.GetInt64("Id"));

            if (employeeResult.Status == ProcessResultStatus.Success)
            {
                var result = new EmployeeFingerPrintSet(employeeResult.Data);
                result.LeftThumb.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftThumb"));
                result.LeftIndexFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftIndexFinger"));
                result.LeftMiddleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftMiddleFinger"));
                result.LeftRingFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftRingFinger"));
                result.LeftLittleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftLittleFinger"));
                result.RightThumb.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightThumb"));
                result.RightIndexFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightIndexFinger"));
                result.RightMiddleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightMiddleFinger"));
                result.RightRingFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightRingFinger"));
                result.RightLittleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightLittleFinger"));

                return result;
            }
            else
            {
                return null;
            }
        }

        private static async Task<EmployeeFingerPrintSet> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var employeeResult = await EmployeeManager.GetByIdAsync(reader.GetInt64("Id"), cancellationToken);

            if (employeeResult.Status == ProcessResultStatus.Success)
            {
                var result = new EmployeeFingerPrintSet(employeeResult.Data);
                result.LeftThumb.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftThumb"));
                result.LeftIndexFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftIndexFinger"));
                result.LeftMiddleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftMiddleFinger"));
                result.LeftRingFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftRingFinger"));
                result.LeftLittleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("LeftLittleFinger"));
                result.RightThumb.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightThumb"));
                result.RightIndexFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightIndexFinger"));
                result.RightMiddleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightMiddleFinger"));
                result.RightRingFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightRingFinger"));
                result.RightLittleFinger.Data = FingerPrintScannerHelper.ConvertFromStream(reader.GetStream("RightLittleFinger"));

                return result;
            }
            else
            {
                return null;
            }
        }

        public static IEnumerableDataProcessResult<EmployeeFingerPrintSet> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<EmployeeFingerPrintSet>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<EmployeeFingerPrintSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<EmployeeFingerPrintSet>(ex);
            }
        }

        public static async Task<IEnumerableDataProcessResult<EmployeeFingerPrintSet>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<EmployeeFingerPrintSet>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableDataProcessResult<EmployeeFingerPrintSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<EmployeeFingerPrintSet>(ex);
            }
        }

        public static async Task<IEnumerableDataProcessResult<EmployeeFingerPrintSet>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<EmployeeFingerPrintSet>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableDataProcessResult<EmployeeFingerPrintSet>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<EmployeeFingerPrintSet>(ex);
            }
        }

        public static IDataProcessResult<EmployeeFingerPrintSet> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new DataProcessResult<EmployeeFingerPrintSet>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ex);
            }
        }

        public static async Task<IDataProcessResult<EmployeeFingerPrintSet>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new DataProcessResult<EmployeeFingerPrintSet>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ex);
            }
        }

        public static async Task<IDataProcessResult<EmployeeFingerPrintSet>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new DataProcessResult<EmployeeFingerPrintSet>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ex);
            }
        }
    }
}