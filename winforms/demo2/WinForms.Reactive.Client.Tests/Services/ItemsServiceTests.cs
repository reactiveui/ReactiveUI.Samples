using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using WinForms.Reactive.Client.Services;
using FluentAssertions;

namespace WinForms.Reactive.Client.Tests.Services;

public class Tests
{
	private IItemsService _sut;

	[SetUp]
	public void Setup()
	{
		_sut = new ItemsService();
	}

	[Test]
	public async Task GetAll_ReturnsItems()
	{
		var items = await _sut.GetAll();

		items.Should().NotBeNull();
		items.Count().Should().BeGreaterThan(0);
	}
}
