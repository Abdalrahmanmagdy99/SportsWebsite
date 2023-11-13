function EditTournament(id) {
    var EditTournamentName = document.getElementById("EditTournamentName");
    var EditTournamentDescription = document.getElementById("EditTournamentDescription");
    var EditTournamentVideoUrl = document.getElementById("EditTournamentVideoUrl");
    var TournamentId = document.getElementById("TournamentId");

    $.ajax(
        {
            type: 'Get',
            dataType: 'json',
            url: '/api/Tournament/GetTournamentDetailsById',
            data: { id: id },
            success: function (success) {
                TournamentId.value = success.tournamentId;
                EditTournamentName.value = success.name;
                EditTournamentDescription.value = success.description;
                EditTournamentVideoUrl.value = success.videoUrl;
            },
        }
    );
}






