using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using FluentAssertions;
using Microsoft.Reactive.Testing;
using NUnit.Framework;
using ReactiveUI;
using ReactiveUI.Testing;
using Splat;
using WinForms.Reactive.Client.Services;
using WinForms.Reactive.Client.Tests.Fakes;
using WinForms.Reactive.Client.ViewModels;

namespace WinForms.Reactive.Client.Tests.ViewModels;

public class ItemsViewModelTests
{
	[SetUp]
	public void Setup()
	{
		Locator.CurrentMutable.RegisterLazySingleton(() => new ItemsServiceFake(), typeof(IItemsService));
	}

	[Test]
	public void LoadItemsCommand_IsLoading() => new TestScheduler().With(scheduler =>
	{
		ItemsServiceFake.AddItemMockResult(new ItemDto(Guid.NewGuid(), "Name 1", new List<ItemTagDto>()));

		var vm = new ItemsViewModel(scheduler);

		Observable.Return(Unit.Default).InvokeCommand(vm.LoadItemsCommand);

		scheduler.AdvanceBy(1);
		vm.IsLoading.Should().BeTrue();

		scheduler.AdvanceBy(TimeSpan.FromSeconds(3).Ticks);
		vm.IsLoading.Should().BeFalse();
	});

	[Test]
	public void LoadItemsCommand_AutoRefresh_After_5_Minutes() => new TestScheduler().With(scheduler =>
	{
		ItemsServiceFake.AddItemMockResult(new ItemDto(Guid.NewGuid(), "Name 1", new List<ItemTagDto>()));

		var vm = new ItemsViewModel(scheduler);

		vm.Items.Count().Should().Be(0);

		vm.LoadItemsCommand.Subscribe();

		scheduler.AdvanceBy(TimeSpan.FromSeconds(5 * 60).Ticks);
		scheduler.AdvanceBy(2);

		vm.IsLoading.Should().BeTrue();
		scheduler.AdvanceBy(2);

		vm.Items.Count().Should().BeGreaterThan(0);
	});

	[Test]
	public void ItemsFiltered_FilteredBySearch() => new TestScheduler().With(scheduler =>
	{
		ItemsServiceFake.AddItemMockResult(new ItemDto(Guid.NewGuid(), "Name 1", new List<ItemTagDto>()));
		ItemsServiceFake.AddItemMockResult(new ItemDto(Guid.NewGuid(), "Another 2", new List<ItemTagDto>()));

		var vm = new ItemsViewModel(scheduler);

		Observable.Return(Unit.Default).InvokeCommand(vm.LoadItemsCommand);
		scheduler.AdvanceBy(2);

		scheduler.AdvanceBy(TimeSpan.FromMilliseconds(800).Ticks);
		scheduler.AdvanceBy(2);

		vm.ItemsFiltered.Count().Should().Be(2);

		vm.SearchStartsWith = "A";
		vm.SearchEndsWith = "2";

		scheduler.AdvanceBy(TimeSpan.FromMilliseconds(800).Ticks);
		scheduler.AdvanceBy(2);

		vm.ItemsFiltered.Count().Should().Be(1);
	});

	[Test]
	public void ShowDetailsCommand_ShouldNotExecuteWithoutSelectedItem() => new TestScheduler().With(scheduler =>
	{
		ItemsServiceFake.AddItemMockResult(new ItemDto(Guid.Empty, "Name 1", new List<ItemTagDto> {
			new ItemTagDto(Guid.NewGuid(), "Sub 1"),
			new ItemTagDto(Guid.NewGuid(), "Sub 2"),
			new ItemTagDto(Guid.NewGuid(), "Sub 3"),
		}));
		ItemsServiceFake.AddItemMockResult(new ItemDto(Guid.NewGuid(), "Another 2", new List<ItemTagDto>()));

		var vm = new ItemsViewModel(scheduler);

		Observable.Return(Unit.Default).InvokeCommand(vm.LoadItemsCommand);

		vm.SelectedItem.tagId.Should().BeNull();

		Observable.Return(Unit.Default).InvokeCommand(vm.ShowDetailsCommand);
		scheduler.AdvanceBy(2);

		vm.SelectedItemTags.Count().Should().Be(0);
	});

	[Test]
	public void SelectedItemTags_FromSelectedItem() => new TestScheduler().With(scheduler =>
	{
		ItemsServiceFake.AddItemMockResult(new ItemDto(Guid.Empty, "Name 1", new List<ItemTagDto> {
			new ItemTagDto(Guid.NewGuid(), "Sub 1"),
			new ItemTagDto(Guid.NewGuid(), "Sub 2"),
			new ItemTagDto(Guid.NewGuid(), "Sub 3"),
		}));
		ItemsServiceFake.AddItemMockResult(new ItemDto(Guid.NewGuid(), "Another 2", new List<ItemTagDto>()));

		var vm = new ItemsViewModel(scheduler);

		Observable.Return(Unit.Default).InvokeCommand(vm.LoadItemsCommand);

		vm.SelectedItem = (Guid.Empty, 0);

		scheduler.AdvanceBy(TimeSpan.FromMilliseconds(800).Ticks);
		scheduler.AdvanceBy(2);

		Observable.Return(Unit.Default).InvokeCommand(vm.ShowDetailsCommand);
		scheduler.AdvanceBy(2);

		vm.SelectedItemTags.Count().Should().Be(3);
	});

}
