using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class PersonManager : ManagerBase<Person, long>, IPersonManager
    {
        private readonly IDeletePerson r_DeletePerson;
        private readonly IGetPersonById r_GetPersonById;
        private readonly IGetPersonList r_GetPersonList;
        private readonly IInsertPerson r_InsertPerson;
        private readonly IUpdatePerson r_UpdatePerson;
        private readonly ISearchPerson r_SearchPerson;

        public PersonManager(
            IDeletePerson deletePerson,
            IGetPersonById getPersonById,
            IGetPersonList getPersonList,
            IInsertPerson insertPerson,
            IUpdatePerson updatePerson,
            ISearchPerson searchPerson)
        {
            r_DeletePerson = deletePerson;
            r_GetPersonById = getPersonById;
            r_GetPersonList = getPersonList;
            r_InsertPerson = insertPerson;
            r_UpdatePerson = updatePerson;
            r_SearchPerson = searchPerson;
        }

        public IProcessResult<Person> Delete(Person data)
        {
            if (data != null)
            {
                r_DeletePerson.Person = data;
                var result = r_DeletePerson.Execute();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person.");
            }
        }

        public async Task<IProcessResult<Person>> DeleteAsync(Person data)
        {
            if (data != null)
            {
                r_DeletePerson.Person = data;
                var result = await r_DeletePerson.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person.");
            }
        }

        public async Task<IProcessResult<Person>> DeleteAsync(Person data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeletePerson.Person = data;
                var result = await r_DeletePerson.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person.");
            }
        }

        public IProcessResult<Person> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Person>(StaticSource[id]);
                }
                else
                {
                    r_GetPersonById.PersonId = id;
                    var result = r_GetPersonById.Execute();
                    AddUpdateIfSuccess(result);
                    return result;
                }
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person identifier.");
            }
        }

        public async Task<IProcessResult<Person>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Person>(StaticSource[id]);
                }
                else
                {
                    r_GetPersonById.PersonId = id;
                    var result = await r_GetPersonById.ExecuteAsync();
                    AddUpdateIfSuccess(result);
                    return result;
                }
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person identifier.");
            }
        }

        public async Task<IProcessResult<Person>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Person>(StaticSource[id]);
                }
                else
                {
                    r_GetPersonById.PersonId = id;
                    var result = await r_GetPersonById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);
                    return result;
                }
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person identifier.");
            }
        }

        public IEnumerableProcessResult<Person> GetList()
        {
            var result = r_GetPersonList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Person>> GetListAsync()
        {
            var result = await r_GetPersonList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Person>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetPersonList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<Person> Insert(Person data)
        {
            if (data != null)
            {
                r_InsertPerson.Person = data;
                var result = r_InsertPerson.Execute();
                AddIfSuccess(result);
                return result;
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person.");
            }
        }

        public async Task<IProcessResult<Person>> InsertAsync(Person data)
        {
            if (data != null)
            {
                r_InsertPerson.Person = data;
                var result = await r_InsertPerson.ExecuteAsync();
                AddIfSuccess(result);
                return result;
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person.");
            }
        }

        public async Task<IProcessResult<Person>> InsertAsync(Person data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertPerson.Person = data;
                var result = await r_InsertPerson.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);
                return result;
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person.");
            }
        }

        public IProcessResult<Person> Update(Person data)
        {
            if (data != null)
            {
                r_UpdatePerson.Person = data;
                var result = r_UpdatePerson.Execute();
                UpdateIfSuccess(result);
                return result;
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person.");
            }
        }

        public async Task<IProcessResult<Person>> UpdateAsync(Person data)
        {
            if (data != null)
            {
                r_UpdatePerson.Person = data;
                var result = await r_UpdatePerson.ExecuteAsync();
                UpdateIfSuccess(result);
                return result;
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person.");
            }
        }

        public async Task<IProcessResult<Person>> UpdateAsync(Person data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdatePerson.Person = data;
                var result = await r_UpdatePerson.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);
                return result;
            }
            else
            {
                return new ProcessResult<Person>(ProcessResultStatus.Failed, "Invalid person.");
            }
        }

        public IEnumerableProcessResult<Person> Search(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return new EnumerableProcessResult<Person>(ProcessResultStatus.Failed, "Invalid search key.");
            }
            else
            {
                r_SearchPerson.SearchKey = searchKey;
                var result = r_SearchPerson.Execute();
                AddUpdateIfSuccess(result);

                return result;
            }
        }

        public async Task<IEnumerableProcessResult<Person>> SearchAsync(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return new EnumerableProcessResult<Person>(ProcessResultStatus.Failed, "Invalid search key.");
            }
            else
            {
                r_SearchPerson.SearchKey = searchKey;
                var result = await r_SearchPerson.ExecuteAsync();
                AddUpdateIfSuccess(result);

                return result;
            }
        }

        public async Task<IEnumerableProcessResult<Person>> SearchAsync(string searchKey, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return new EnumerableProcessResult<Person>(ProcessResultStatus.Failed, "Invalid search key.");
            }
            else
            {
                r_SearchPerson.SearchKey = searchKey;
                var result = await r_SearchPerson.ExecuteAsync(cancellationToken);
                AddUpdateIfSuccess(result);

                return result;
            }
        }
    }
}
