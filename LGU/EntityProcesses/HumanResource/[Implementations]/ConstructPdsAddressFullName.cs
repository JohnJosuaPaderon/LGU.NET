using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class ConstructPdsAddressFullName : IConstructPdsAddressFullName
    {
        public IPdsAddress PdsAddress { get; set; }

        public IProcessResult<string> Execute()
        {
            if (PdsAddress != null)
            {
                return new ProcessResult<string>(Construct());
            }
            else
            {
                return new ProcessResult<string>(ProcessResultStatus.Failed);
            }
        }

        public Task<IProcessResult<string>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<string>> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private string Construct()
        {
            var builder = new StringBuilder();
            var hasHouseNumber = PdsAddress.HouseNumber != null && PdsAddress.HouseNumber > 0;
            var hasBlockNumber = PdsAddress.BlockNumber != null && PdsAddress.BlockNumber > 0;
            var hasLotNumber = PdsAddress.LotNumber != null && PdsAddress.LotNumber > 0;
            var hasStreet = !string.IsNullOrWhiteSpace(PdsAddress.Street);
            var hasSubdivisionVillage = !string.IsNullOrWhiteSpace(PdsAddress.SubdivisionVillage);
            var hasBarangay = PdsAddress.Barangay != null;
            var hasZipCode = PdsAddress.ZipCode != null && PdsAddress.ZipCode > 0;

            if (hasHouseNumber)
            {
                builder.Append($"#{PdsAddress.HouseNumber}");

                if (
                    hasBlockNumber ||
                    hasLotNumber ||
                    hasStreet ||
                    hasSubdivisionVillage ||
                    hasBarangay ||
                    hasZipCode)
                {
                    builder.Append(" ");
                }
            }

            if (hasBlockNumber)
            {
                builder.Append($"Blk. {PdsAddress.BlockNumber}");

                if (
                    hasLotNumber ||
                    hasStreet ||
                    hasSubdivisionVillage ||
                    hasBarangay ||
                    hasZipCode)
                {
                    builder.Append(" ");
                }
            }

            if (hasLotNumber)
            {
                builder.Append($"Lot {PdsAddress.LotNumber}");

                if (
                    hasStreet ||
                    hasSubdivisionVillage ||
                    hasBarangay ||
                    hasZipCode)
                {
                    builder.Append(" ");
                }
            }

            if (hasStreet)
            {
                builder.Append(PdsAddress.Street.Trim());

                if (
                    hasSubdivisionVillage ||
                    hasBarangay ||
                    hasZipCode)
                {
                    builder.Append(", ");
                }
            }

            if (hasSubdivisionVillage)
            {
                builder.Append(PdsAddress.SubdivisionVillage.Trim());

                if (
                    hasBarangay ||
                    hasZipCode)
                {
                    builder.Append(", ");
                }
            }

            if (hasBarangay)
            {
                builder.Append(PdsAddress.Barangay.Name);

                if (PdsAddress.Barangay.CityMunicipality != null)
                {
                    builder.Append($", {PdsAddress.Barangay.CityMunicipality.Name}");

                    if (PdsAddress.Barangay.CityMunicipality.Province != null)
                    {
                        builder.Append($", {PdsAddress.Barangay.CityMunicipality.Province.Name}");
                    }
                }
            }

            return builder.ToString();
        }
    }
}
