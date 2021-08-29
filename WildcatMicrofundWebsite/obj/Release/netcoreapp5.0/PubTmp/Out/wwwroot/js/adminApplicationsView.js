var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    var enableJudgeApplication = false;

    dataTable = $('#DT_load').DataTable({

        "ajax": {
            "url": "/api/adminApplicationsView",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "businessName", "width": "40%"
            },
            {
                "data": "status.statusDescription",
                "render": function (data) {
                    if (data == "Pending Review/Approval") {
                        enableJudgeApplication = true;
                        return data;
                    } else {
                        enableJudgeApplication = false;
                        return data;
                    }
                    return data;
                }, "width": "15%"
            },
            {
                "data": "applicationDate",
                "render": function (data) {
                    return moment(data).format('MM/DD/YYYY');
                }, "width": "20%"
            },
            {
                "data": "id",
                "render": function (data) {
                    if (enableJudgeApplication) {
                        return ` 
                        <div class="text-center">
                            <a href="/ApplicationProfile/Questions/Index?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width:100px; border-radius:5px;">
                            <i class="fas fa-balance-scale"></i>
                            Judge
                            </a>               
                        </div>`;
                    }
                    else {
                        return ` 
                        <div class="text-center">
                            <a href="/ApplicationProfile/Questions/Index?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px; border-radius:5px;">
                            <i class="far fa-edit"></i> 
                            Review
                            </a>               
                        </div>`;
                    }
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}