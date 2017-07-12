using LGU.Entities;
using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class PersonManager : IPersonManager
    {
        private readonly IDeletePerson DeleteProc;
        private readonly IGetPersonById GetByIdProc;
        private readonly IGetPersonList GetListProc;
        private readonly IInsertPerson InsertProc;
        private readonly IUpdatePerson UpdateProc;

        private static EntityCollection<Person, long> StaticSource { get; } = new EntityCollection<Person, long>();

        public PersonManager(
            IDeletePerson deleteProc,
            IGetPersonById getByIdProc,
            IGetPersonList getListProc,
            IInsertPerson insertProc,
            IUpdatePerson updateProc)
        {
            DeleteProc = deleteProc;
            GetByIdProc = getByIdProc;
            GetListProc = getListProc;
            InsertProc = insertProc;
            UpdateProc = updateProc;
        }

        private static void InvokeIfSuccess(IDataProcessResult<Person> result, Action expression)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                expression();
            }
        }

        public IDataProcessResult<Person> Delete(Person data)
        {
            if (data != null)
            {
                DeleteProc.Person = data;
                var result = DeleteProc.Execute();
                InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<Person>> DeleteAsync(Person data)
        {
            if (data != null)
            {
                DeleteProc.Person = data;
                var result = await DeleteProc.ExecuteAsync();
                InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<Person>> DeleteAsync(Person data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                DeleteProc.Person = data;
                var result = await DeleteProc.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }

        public IDataProcessResult<Person> GetById(long id)
        {
            if (id > 0)
            {
                GetByIdProc.PersonId = id;
                var result = GetByIdProc.Execute();
                InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<Person>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                GetByIdProc.PersonId = id;
                var result = await GetByIdProc.ExecuteAsync();
                InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<Person>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                GetByIdProc.PersonId = id;
                var result = await GetByIdProc.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }

        public IEnumerableDataProcessResult<Person> GetList()
        {
            return GetListProc.Execute();
        }

        public Task<IEnumerableDataProcessResult<Person>> GetListAsync()
        {
            return GetListProc.ExecuteAsync();
        }

        public Task<IEnumerableDataProcessResult<Person>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetListProc.ExecuteAsync(cancellationToken);
        }

        public IDataProcessResult<Person> Insert(Person data)
        {
            if (data != null)
            {
                InsertProc.Person = data;
                var result = InsertProc.Execute();
                InvokeIfSuccess(result, () => StaticSource.Add(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<Person>> InsertAsync(Person data)
        {
            if (data != null)
            {
                InsertProc.Person = data;
                var result = await InsertProc.ExecuteAsync();
                InvokeIfSuccess(result, () => StaticSource.Add(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<Person>> InsertAsync(Person data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                InsertProc.Person = data;
                var result = await InsertProc.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result, () => StaticSource.Add(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }

        public IDataProcessResult<Person> Update(Person data)
        {
            if (data != null)
            {
                UpdateProc.Person = data;
                var result = UpdateProc.Execute();
                InvokeIfSuccess(result, () => StaticSource.Update(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<Person>> UpdateAsync(Person data)
        {
            if (data != null)
            {
                UpdateProc.Person = data;
                var result = await UpdateProc.ExecuteAsync();
                InvokeIfSuccess(result, () => StaticSource.Update(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<Person>> UpdateAsync(Person data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                UpdateProc.Person = data;
                var result = await UpdateProc.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result, () => StaticSource.Update(result.Data));
                return result;
            }
            else
            {
                return new DataProcessResult<Person>(ProcessResultStatus.Failed);
            }
        }
    }
}
