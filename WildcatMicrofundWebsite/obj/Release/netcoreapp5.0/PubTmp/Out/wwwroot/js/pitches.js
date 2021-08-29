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
                    var mom = moment(data).format('MM/DD/YYYY hh:mm a');
                    return `
                        <a href = "/Admin/PitchEvent/Details?id=${row['id']}"> ${mom} </a>`
                }, "width": "30%"
            },
            { "data": "cashFunds", "width": "10%" },
            { "data": "serviceFunds", "width": "15%" },

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
                            <a onClick=Archive('/api/pitchEvent/'+${data})
                            class="btn btn-danger text-white style="cursor:pointer; width: 80px;">
                            <i class="far fa-trash-alt"></i>
                            Archive
                            </a>
                        </div>`;
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}