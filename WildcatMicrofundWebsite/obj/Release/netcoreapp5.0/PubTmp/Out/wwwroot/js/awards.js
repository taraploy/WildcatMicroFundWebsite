var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/awards",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "application.businessName", "width": "20%" },
            {
                "data": "awardDate",
                // Formatting the award date 
                "render": function (data) {
                    return moment(data).format('MM/DD/YYYY');
                },
                "width": "10%"
            },
            {
                "data": "awardAmount",
                // Formatting monetary value
                "render": $.fn.dataTable.render.number(',', '.', 0, '$'),
                "width": "10%"
            },
            { "data": "awardType", "width": "15%" },
            { "data": "comments", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/Admin/Awards/Details?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:80px;">
                                    <i class="far fa-file-alt"></i>
                                    Details
                                </a>                                                                        
                                <a href="/Admin/Awards/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:80px;">
                                    <i class="far fa-edit"></i>
                                    Update
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