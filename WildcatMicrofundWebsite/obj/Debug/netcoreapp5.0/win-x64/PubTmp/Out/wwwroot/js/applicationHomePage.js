var dataTable;

var dt = new Date();
document.getElementById('date-time').innerHTML = dt;

$(document).ready(function () {
    loadList();
});

function loadList() {
    var enableFinishApplication = false;

    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/applicationHomePage",
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
                    if (data == "In Progress") {
                        enableFinishApplication = true;
                        return data;
                    } else {
                        enableFinishApplication = false;
                        return data;
                    }
                },
                "width": "25%"
            },
            {
                "data": "id",
                "render": function (data) {
                    if (enableFinishApplication) {
                        return `
                        <div class="text-center">
                            <a href="/ApplicationProfile/Home/Upsert?id=${data}"
                            class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                            <i class="far fa-edit"></i> 
                            Edit Business Name
                            </a>
                            <a href="/ApplicationProfile/Questions/Upsert?id=${data}"
                            class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                            <i class="far fa-edit"></i> 
                            Finish Application
                            </a>
                        </div>`;
                    } else {
                        return ` 
                        <div class="text-center">
                            <a href="/ApplicationProfile/Home/Upsert?id=${data}"style="cursor:pointer; width:30%;">Edit Business Name
                            </a>
                        </div>`;
                    }
                }, "width": "35%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}