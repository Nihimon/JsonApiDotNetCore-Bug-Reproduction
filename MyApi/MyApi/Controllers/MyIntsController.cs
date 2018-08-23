using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCore.Services;

namespace MyApi.Controllers
{
	public class MyIntsController : JsonApiController<MyInt, int>
	{
		public MyIntsController(IJsonApiContext jsonApiContext, IResourceService<MyInt, int> resourceService)
			: base(jsonApiContext, resourceService)
		{ }
	}

	public class MyInt : Identifiable<int>
	{
		private static Dictionary<int, MyInt> Entities { get; } = new Dictionary<int, MyInt>();
		private static int NextId { get; set; } = 1;

		public static MyInt Create(MyInt entity)
		{
			entity.Id = NextId++;
			Entities.Add(entity.Id, entity);

			return entity;
		}

		public static IEnumerable<MyInt> GetAll()
		{
			return Entities.Values;
		}

		public static MyInt GetById(int id)
		{
			return Entities.Values.Where(x => x.Id == id).SingleOrDefault();
		}

		[Attr("test")]
		public string Test { get; set; }
	}

	public class MyIntsService : IResourceService<MyInt>
	{
		public Task<MyInt> CreateAsync(MyInt entity)
		{
			return Task.FromResult(MyInt.Create(entity));
		}

		public Task<bool> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<MyInt>> GetAsync()
		{
			return Task.FromResult(MyInt.GetAll());
		}

		public Task<MyInt> GetAsync(int id)
		{
			return Task.FromResult(MyInt.GetById(id));
		}

		public Task<object> GetRelationshipAsync(int id, string relationshipName)
		{
			throw new NotImplementedException();
		}

		public Task<object> GetRelationshipsAsync(int id, string relationshipName)
		{
			throw new NotImplementedException();
		}

		public Task<MyInt> UpdateAsync(int id, MyInt entity)
		{
			throw new NotImplementedException();
		}

		public Task UpdateRelationshipsAsync(int id, string relationshipName, List<DocumentData> relationships)
		{
			throw new NotImplementedException();
		}
	}
}
