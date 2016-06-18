using MapTheState.Web.Domain;

namespace MapTheState.Web.Repositories
{
    public interface IInstitutionsRepository
    {
        void SaveInstitution(Institution institutionToSave);
    }
}