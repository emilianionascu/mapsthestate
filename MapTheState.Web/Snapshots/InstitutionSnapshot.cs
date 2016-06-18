using MapTheState.Web.Domain;

namespace MapTheState.Web.Snapshots
{
    public class InstitutionSnapshot
    {
        public InstitutionSnapshot(Institution institution)
        {
            DomainId = institution.DomainId;
            Name = institution.Name;
            ExistsAsLegalEntity = institution.ExistsAsLegalEntity;
            Scope = institution.Scope;
            TypeOfActivity = institution.TypeOfActivity;
            Website = institution.Website;
        }

        public string DomainId { get; set; }
        public string Name { get; set; }
        public bool ExistsAsLegalEntity { get; set; }
        public string Scope { get; set; }
        public string TypeOfActivity { get; set; }
        public string Website { get; set; }
    }
}