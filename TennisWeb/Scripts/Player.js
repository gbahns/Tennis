$(function () {

	var vm = {
		id: ko.observable(),
		firstName: ko.observable(""),
		lastName: ko.observable(""),
		statusMessage: ko.observable(""),
		cancelEditMode: function () {
			this.editControlsVisible(false);
		},
		toggleEditMode: function () {
			this.editControlsVisible(!this.editControlsVisible());
		},
		saveChanges: function () {
			alert("Changes saved.");
			this.toggleEditMode();
		},
		editControlsVisible: ko.observable(false),
	};

	vm.editButtonVisible = ko.computed(function () {
		return !this.editControlsVisible();
	}, vm);

	vm.fullName = ko.computed(function () {
		return this.firstName() + " " + this.lastName();
	}, vm);

	vm.editButtonEnabled = ko.computed(function () {
		return this.fullName().trim().length > 0;
		//		return this.firstName().length > 0 || this.lastName().length > 0;
	}, vm);

	vm.editButtonText = ko.computed(function () {
		return this.editControlsVisible() ? "Done" : "Edit";
	}, vm);

	vm.modeText = ko.computed(function () {
		return "You are currently " + (this.editControlsVisible() ? "editing" : "viewing") + " this player.";
	}, vm);

	vm.id.subscribe(function (newValue) {
		vm.statusMessage("");
		vm.cancelEditMode();

		if (newValue=="" || isNaN(newValue)) {
			vm.firstName("");
			vm.lastName("");
			return;
		}

		//	$.getJSON("/Api/GetPlayer.aspx?id=1", null, function (json) {
		$.ajax({
			dataType: "json",
			url: "/Api/GetPlayer.aspx",
			data: { id: newValue },
			error: function (jqXHR, textStatus, errorThrown) {
				vm.statusMessage("GetPlayer failed ("+errorThrown+").");
			},
			success: function (data) {
				vm.statusMessage("");
				vm.id(data.Id);
				vm.firstName(data.FirstName);
				vm.lastName(data.LastName);
			}
		});
	});

	ko.applyBindings(vm);
});