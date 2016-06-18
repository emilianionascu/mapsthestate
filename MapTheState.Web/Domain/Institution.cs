using System.Collections;
using System.Collections.Generic;
using MapTheState.Web.Extensions;
using MapTheState.Web.Snapshots;
using Microsoft.Owin.BuilderProperties;

namespace MapTheState.Web.Domain
{
    public class Institution
    {
        public string DomainId { get; private set; }
        public string Name { get; private set; }
        public bool ExistsAsLegalEntity { get; private set; }
        public Address Address { get; private set; }
        public string Scope { get; private set; }
        public string TypeOfActivity { get; private set; }
        public string Website { get; private set; }
        public IList<Institution> SubordinatorOf { get; private set; }
        public IList<Institution> SubordinatedTo { get; private set; }
        public IList<Institution> CoordinatorOf { get; private set; }
        public IList<Institution> CoordinatedBy { get; private set; }
        public IList<Institution> AuthorityOver { get; private set; }
        public IList<Institution> UnderAuthorityOf { get; private set; }

        public static Institution FromSnapshots(InstitutionSnapshot institutionSnapshot)
        {
            return new Institution
            {
                DomainId = institutionSnapshot.DomainId,
                Name = institutionSnapshot.Name,
                Scope = institutionSnapshot.Scope,
                TypeOfActivity = institutionSnapshot.TypeOfActivity,
                Website = institutionSnapshot.Website,
                ExistsAsLegalEntity = institutionSnapshot.ExistsAsLegalEntity,
            };
        }

        public static Institution FromListOfCells(Dictionary<string, string> rowCells)
        {
            return new Institution()
            {
                DomainId = rowCells.SafeGet("A"),
                Name = rowCells.SafeGet("B"),
                ExistsAsLegalEntity = rowCells.SafeGet("C") == "da",
                Address = new Address
                {
                    Town = rowCells.SafeGet("D"),
                    County = rowCells.SafeGet("E"),
                    StreetAddress = rowCells.SafeGet("F"),
                    Email = rowCells.SafeGet("G"),
                    Telephone = rowCells.SafeGet("H"),
                },
                Website = rowCells.SafeGet("I"),
                Scope = rowCells.SafeGet("J"),
                TypeOfActivity = rowCells.SafeGet("K")
            };
        }
    }
}