var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "order": [[0, "asc"]],
        "ajax": {
            "url": "/api/pitchEvent",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "pitchDateTime",
                "render": function (data, type, row, meta) {
                    var mom = moment(data).format('MM/DD/YYYY');
                    return `
                        <a href = "/Admin/PitchEvent/Details?id=${row['id']}"> ${mom} </a>`
                }, "width": "20%"
            },
            { "data": "cashFunds", "width": "15%" },
            { "data": "serviceFunds", "width": "15%" },
            {
                "data": "status.statusDescription",
                "width": "20%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return ` 
                        <div class="text-center">
                            <a href="/Admin/PitchEvent/Upsert?id=${data}"
                            class="btn btn-success text-white" style="cursor:pointer; width:80px;">
                            <i class="far fa-edit"></i> 
                            Edit
                            </a>                            
                        </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}