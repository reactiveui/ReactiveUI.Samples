using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms.Reactive.Client.Services;

namespace WinForms.Reactive.Client.Tests.Fakes;

/// <summary>
/// This Fake implementation replace the time-based real implementation.
/// This service returns in 1 tick, making posssible to test time-not-aware scenarios.
/// </summary>
public class ItemsServiceFake : IItemsService
{
	public static List<ItemDto> ItemsMockResult { get; set; }=new List<ItemDto>();
	public static void AddItemMockResult(ItemDto item) => ItemsMockResult.Add(item);

	public Task<IEnumerable<ItemDto>> GetAll() => Task.FromResult<IEnumerable<ItemDto>>(ItemsMockResult);
}
