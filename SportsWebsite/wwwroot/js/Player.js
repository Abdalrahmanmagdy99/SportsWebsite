function EditPlayer(id) {
    var EditPlayerName = document.getElementById("EditPlayerName");
    var EditPlayerBirthDate = document.getElementById("EditPlayerBirthDate");
    var PlayerId = document.getElementById("PlayerId");
    var TeamDropDown = document.getElementById("TeamIdDropDown");

    $.ajax(
        {
            type: 'Get',
            dataType: 'json',
            url: 'https://localhost:7251/api/Player/GetPlayerDetailsById',
            data: { id: id },
            success: function (success) {
                PlayerId.value = success.playerId;
                EditPlayerName.value = success.name;
                for (var i = 0; i < TeamDropDown.options.length; i++) {
                    var option = TeamDropDown.options[i];
                    if (option.value == success.teamId) {
                        option.selected = true;
                        break;
                    }
                    else {
                        option.selected = false;
                    }
                }
                var DateWithoutTime = success.foundationDate.split('T')[0];
                EditPlayerBirthDate.value = DateWithoutTime;
            },
        }
    );
}
