function EditTeam(id) {
    var EditTeamName = document.getElementById("EditTeamName");
    var EditTeamDescription = document.getElementById("EditTeamDescription");
    var EditWebsiteUrl = document.getElementById("EditWebsiteUrl");
    var EditFoundationDate = document.getElementById("EditFoundationDate");
    var TeamId = document.getElementById("TeamId");

    $.ajax(
        {
            type: 'Get',
            dataType: 'json',
            url: 'https://localhost:7251/api/Team/GetTeamDetailsById',
            data: { id: id },
            success: function (success) {
                TeamId.value = success.teamId;
                EditTeamName.value = success.name;
                EditTeamDescription.value = success.description;
                EditWebsiteUrl.value = success.websiteURL;

                var DateWithoutTime = success.foundationDate.split('T')[0];
                EditFoundationDate.value = DateWithoutTime;
            },
        }
    );
}
