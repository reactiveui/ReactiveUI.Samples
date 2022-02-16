namespace WinForms.Reactive.Client.Services;

public record ItemDto(Guid ItemId, string Name, IEnumerable<ItemTagDto> Tags);
public record ItemTagDto(Guid ItemTagId, string Name);

/// <summary>
/// A dummy service that returns random data after 1 second to simulate real http/database delay response.
/// </summary>
public interface IItemsService
{
	/// <summary>
	/// Returns a random-lenght list of items.
	/// </summary>
	Task<IEnumerable<ItemDto>> GetAll();
}

public class ItemsService : IItemsService
{
	/*
	 * If you need DI in a service (ex. inject EntityFramework or another dependency), just use the Locator pattern.
	 * Default your service to `null` so it can be easy to mock it in unit tests.
	 * If you are not in unit tests, it will resolve the default registration.
	 *
	 * private readonly IYourService _yourService;

	 * public ItemsService(IYourService? yourService = null)	{
	 * 	_yourService = yourService ?? Splat.Locator.Current.GetService<IYourService>()!;
	 * }
	 *
	*/

	public async Task<IEnumerable<ItemDto>> GetAll()
	{
		await Task.Delay(1000);

		var numTags = new Random().Next(1, 100);
		var tags = new List<ItemDto>(numTags);

		Enumerable.Range(0, numTags).ToList().ForEach(i =>
		{
			var nItemTags = new Random().Next(1, 100);
			var itemTags = new List<ItemTagDto>(nItemTags);

			Enumerable.Range(0, nItemTags).ToList().ForEach(ii =>
			{
				var subTag = new ItemTagDto(Guid.NewGuid(), $"Sub {ii}");
				itemTags.Add(subTag);
			});

			var tag = new ItemDto(Guid.NewGuid(), $"Name {i}", itemTags);

			tags.Add(tag);
		});

		return tags;
	}
}
