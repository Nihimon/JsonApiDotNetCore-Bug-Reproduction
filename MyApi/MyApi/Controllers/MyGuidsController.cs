using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCore.Services;

namespace MyApi.Controllers
{
	public class MyGuidsController : JsonApiController<MyGuid, Guid>
	{
		public MyGuidsController(IJsonApiContext jsonApiContext, IResourceService<MyGuid, Guid> resourceService)
			: base(jsonApiContext, resourceService)
		{ }
	}

	public class MyGuid : Identifiable<Guid>
	{
		private static Dictionary<Guid, MyGuid> Entities { get; } = new Dictionary<Guid, MyGuid>();

		public static MyGuid Create(MyGuid entity)
		{
			entity.Id = Guid.NewGuid();
			Entities.Add(entity.Id, entity);

			return entity;
		}

		public static IEnumerable<MyGuid> GetAll()
		{
			return Entities.Values;
		}

		public static MyGuid GetById(Guid id)
		{
			return Entities.Values.Where(x => x.Id == id).SingleOrDefault();
		}

		[Attr("test")]
		public string Test { get; set; }
	}

	public class MyGuidsService : IResourceService<MyGuid, Guid>
	{
		public Task<MyGuid> CreateAsync(MyGuid entity)
		{
			return Task.FromResult(MyGuid.Create(entity));
		}

		public Task<bool> DeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<MyGuid>> GetAsync()
		{
			return Task.FromResult(MyGuid.GetAll());
		}

		public Task<MyGuid> GetAsync(Guid id)
		{
			return Task.FromResult(MyGuid.GetById(id));
		}

		public Task<object> GetRelationshipAsync(Guid id, string relationshipName)
		{
			throw new NotImplementedException();
		}

		public Task<object> GetRelationshipsAsync(Guid id, string relationshipName)
		{
			throw new NotImplementedException();
		}

		public Task<MyGuid> UpdateAsync(Guid id, MyGuid entity)
		{
			throw new NotImplementedException();
		}

		public Task UpdateRelationshipsAsync(Guid id, string relationshipName, List<DocumentData> relationships)
		{
			throw new NotImplementedException();
		}
	}
}
