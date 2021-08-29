var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    var enableJudgeApplication = false;

    dataTable = $('#DT_load').DataTable({

        "ajax": {
            "url": "/api/judgeApplicationsView",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "businessName", "width": "60%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return ` 
                        <div class="text-center">
                            <a href="/Judge/Home/Upsert?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width:100px; border-radius:5px;">
                            <i class="fas fa-balance-scale"></i>
                            Judge
                            </a>
                        </div>`;
                },
                "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}

