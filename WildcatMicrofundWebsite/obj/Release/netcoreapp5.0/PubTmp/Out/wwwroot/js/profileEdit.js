var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/profileEdit/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "firstName", "width": "15%" },
            { "data": "lastName", "width": "15%" },
            { "data": "address1", "width": "15%" },
            { "data": "city", "width": "15%" },
            { "data": "county", "width": "15%" },
            { "data": "zip", "width": "15%" },
            { "data": "birthDate", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` 
                        <div class="text-center">
                            <a href="/UserProfile/Upsert?id=${data}"
                            class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                            <i class="far fa-edit"></i> 
                            Edit Profile
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