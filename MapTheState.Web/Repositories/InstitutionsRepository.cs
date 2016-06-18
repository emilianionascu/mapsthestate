using System.Linq;
using MapTheState.Web.Domain;
using MapTheState.Web.Snapshots;
using Neo4jClient;
using Newtonsoft.Json.Serialization;

namespace MapTheState.Web.Repositories
{
    public class InstitutionsRepository : IInstitutionsRepository
    {
        private readonly IGraphClient _graphClient;

        public InstitutionsRepository(IGraphClientFactory graphClientFactory)
        {
            _graphClient = graphClientFactory.Create();
            _graphClient.JsonContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        public void SaveInstitution(Institution institutionToSave)
        {
            var institutionSnapshot = new InstitutionSnapshot(institutionToSave);

            _graphClient.Cypher
                .Merge("(institution:Institution {DomainId: {domainId}})")
                .OnCreate()
                .Set("institution = {newInstitution}")
                .WithParams(new
                {
                    newInstitution = institutionSnapshot,
                    domainId = institutionSnapshot.DomainId
                })
                .ExecuteWithoutResults();
        }
    }
}