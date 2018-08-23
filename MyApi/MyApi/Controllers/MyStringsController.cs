using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCore.Services;

namespace MyApi.Controllers
{
	public class MyStringsController : JsonApiController<MyString, string>
	{
		public MyStringsController(IJsonApiContext jsonApiContext, IResourceService<MyString, string> resourceService)
			: base(jsonApiContext, resourceService)
		{ }
	}

	public class MyString : Identifiable<string>
	{
		private static Dictionary<string, MyString> Entities { get; } = new Dictionary<string, MyString>();

		public static MyString Create(MyString entity)
		{
			entity.Id = Guid.NewGuid().ToString();
			Entities.Add(entity.Id, entity);

			return entity;
		}

		public static IEnumerable<MyString> GetAll()
		{
			return Entities.Values;
		}

		public static MyString GetById(string id)
		{
			return Entities.Values.Where(x => x.Id == id).SingleOrDefault();
		}

		public MyString()
		{
			this.Id = Guid.NewGuid().ToString();
		}

		[Attr("test")]
		public string Test { get; set; }
	}

	public class MyStringsService : IResourceService<MyString, string>
	{
		public Task<MyString> CreateAsync(MyString entity)
		{
			return Task.FromResult(MyString.Create(entity));
		}

		public Task<bool> DeleteAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<MyString>> GetAsync()
		{
			return Task.FromResult(MyString.GetAll());
		}

		public Task<MyString> GetAsync(string id)
		{
			return Task.FromResult(MyString.GetById(id));
		}

		public Task<object> GetRelationshipAsync(string id, string relationshipName)
		{
			throw new NotImplementedException();
		}

		public Task<object> GetRelationshipsAsync(string id, string relationshipName)
		{
			throw new NotImplementedException();
		}

		public Task<MyString> UpdateAsync(string id, MyString entity)
		{
			throw new NotImplementedException();
		}

		public Task UpdateRelationshipsAsync(string id, string relationshipName, List<DocumentData> relationships)
		{
			throw new NotImplementedException();
		}
	}
}
